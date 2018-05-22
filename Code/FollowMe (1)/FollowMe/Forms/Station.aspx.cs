using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace FollowMe.Forms
{
    public partial class Station : System.Web.UI.Page
    {
        DataTable dtReaders;
        DataTable dtStation;
        Dal dal;
        protected void Page_Load(object sender, EventArgs e)
        {
            dal = new Dal();
            if (!IsPostBack)
            {
                InitReaders();
                dtReaders = dal.GetTable("Readers");
                CheckBoxList1.DataSource = dtReaders;
                CheckBoxList1.DataTextField = "Name";
                CheckBoxList1.DataValueField = "ReaderId";
                CheckBoxList1.DataBind();
                Session["dtReaders"] = dtReaders;
            }
            if (Session["dtReaders"] != null)
            {
                dtReaders = Session["dtReaders"] as DataTable;
                int i = 0;
                foreach (DataRow row in dtReaders.Rows)
                {
                    List<SqlParameter> param = new List<SqlParameter>();
                    param.Add(new SqlParameter("@Id", row["ReaderId"].ToString()));
                    DataTable dt = new DataTable();
                    dt = dal.GetTable("ActiveAntennas", param);
                    CheckBoxList cb = new CheckBoxList();
                    cb.DataSource = dt;
                    cb.DataTextField = "ActiveAntennas";
                    cb.DataValueField = "ReaderId";
                    cb.DataBind();
                    Session["dt"] = dt;
                    cb.RepeatDirection = RepeatDirection.Horizontal;
                    cb.ID = i.ToString();
                    phActiveAnt.Controls.Add(cb);
                    i++;

                }
            }
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["MasterPage"] != null)
            {
                MasterPage master = Session["MasterPage"] as MasterPage;
                this.MasterPageFile = master.MasterPageFile;
            }
        }
        private void InitReaders()
        {
            dtStation = dal.GetTable("Station");
            ddlReaders.DataSource = dtStation;
            ddlReaders.DataTextField = "Name";
            ddlReaders.DataValueField = "StationId";
            ddlReaders.DataBind();
            int i = 0;
            foreach (var itemReader in CheckBoxList1.Items)
            {
                (((ListItem)itemReader).Selected) = false;
                CheckBoxList cbl = ((CheckBoxList)(phActiveAnt.FindControl(i.ToString())));
                foreach (var itemAnt in cbl.Items)
                {
                    (((ListItem)itemAnt).Selected) = false;
                }
                i++;
            }
            txtName.Text = "";
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {

            bool flag = false;
            bool Written = false;
            int indexRdr = 0;
            List<SqlParameter> l;
            CheckBoxList cbl1 = Session["readers"] as CheckBoxList;
            foreach (var itemReader in CheckBoxList1.Items)
            {
                if ((((ListItem)itemReader).Selected) == true)
                {
                    CheckBoxList cbl = ((CheckBoxList)(phActiveAnt.FindControl(indexRdr.ToString())));
                    flag = true;

                    foreach (var itemAnt in cbl.Items)
                    {
                        if ((((ListItem)itemAnt).Selected) == true)
                        {

                            l = new List<SqlParameter>();
                            if (flag == true)
                            {
                                l.Add(new SqlParameter("Name", txtName.Text));
                                dal.WriteToDB("Station", l);
                                l.Clear();
                                flag = false;
                                Written = true;
                            }
                            l.Add(new SqlParameter("StationId",
                                (int)dal.ReadScalar("select top 1 StationId from Station order by StationId desc")));
                            l.Add(new SqlParameter("ReaderId", ((ListItem)itemReader).Value));
                            l.Add(new SqlParameter("Antenna", ((ListItem)itemAnt).Text));
                            dal.WriteToDB("ConnectionDetailsInStation", l);
                        }
                    }
                }
                indexRdr++;
            }
            if (Written == false)
            {
                ClientScript.RegisterStartupScript(GetType(),
                    "Message", "<SCRIPT LANGUAGE='javascript'>alert(' Please select reader and at least one antena for reader! ')</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert(' Written ')</script>");
                ChangeVisible();
                InitReaders();
            }
            if (Session["edit"] != null)
            {
                DeleteStation();
                Session["edit"] = null;
            }
            this.DataBind();
        }

        protected void lnkNew_Click(object sender, EventArgs e)
        {
            ChangeVisible();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Session["edit"] = true;
            txtName.Text = ddlReaders.SelectedItem.Text;
            ChangeVisible(); dal = new Dal();
            DataTable dtAntennaAndReader;
            List<SqlParameter> l = new List<SqlParameter>();
            l.Add(new SqlParameter("StationId", Convert.ToInt32(ddlReaders.SelectedValue)));
            dtAntennaAndReader = dal.GetTable("ConnectionDetailsInStation", l);
            int i = 0;

            foreach (var itemReader in CheckBoxList1.Items)
            {
                if (dtAntennaAndReader.Rows[i]["StationId"].ToString() == ((ListItem)itemReader).Value)
                {
                    (((ListItem)itemReader).Selected) = true;
                    CheckBoxList cbl = ((CheckBoxList)(phActiveAnt.FindControl(i.ToString())));
                    foreach (var itemAnt in cbl.Items)
                    {
                        if (dtAntennaAndReader.Rows[i]["Antenna"].ToString() == ((ListItem)itemAnt).Text)
                        {
                            (((ListItem)itemAnt).Selected) = true;
                        }
                    }
                }
            }
        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ChangeVisible();
            InitReaders();
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            DeleteStation();
        }

        protected void DeleteStation()
        {

            dal = new Dal();
            List<SqlParameter> l = new List<SqlParameter>();
            l.Add(new SqlParameter("StationId", Session["ddlReaders.SelectedValue"]));
            dal.DeleteInDB("Station", l);
            InitReaders();
        }

        protected void ChangeVisible()
        {
            Label1.Visible = !(Label1.Visible);
            ddlReaders.Visible = !(ddlReaders.Visible);
            btnDel.Visible = !(btnDel.Visible);
            btnEdit.Visible = !(btnEdit.Visible);
            lnkNew.Visible = !(lnkNew.Visible);
            pnlNew.Visible = !(pnlNew.Visible);
        }

        protected void ddlReaders_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ddlReaders.SelectedValue"] = Convert.ToInt32(ddlReaders.SelectedValue);
        }
    }
}