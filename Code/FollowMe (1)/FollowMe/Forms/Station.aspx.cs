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
        FollowMeDBEntities entity=new FollowMeDBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
           if (!IsPostBack)
            {
                InitReaders();
                 CheckBoxList1.DataSource =entity.ReaderSelect().ToArray();
                 CheckBoxList1.DataTextField = "Name";
                CheckBoxList1.DataValueField = "ReaderId";
                CheckBoxList1.DataBind();
                //Session["dtReaders"] = dtReaders;
            }
            //if (Session["dtReaders"] != null)
            {
              //  dtReaders = Session["dtReaders"] as DataTable;
                int i = 0;
                foreach (var row in entity.Readers.ToArray())
                {
                     CheckBoxList cb = new CheckBoxList();
                    cb.DataSource =entity.ActiveAntennaSelect(row.ReaderId).ToArray();
                    cb.DataTextField = "ActiveAntennas";
                    cb.DataValueField = "ReaderId";
                    cb.DataBind();
                   // Session["dt"] = dt;
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
            ddlReaders.DataSource = entity.Station.ToList();
            ddlReaders.DataTextField = "Name";
            ddlReaders.DataValueField = "StationId";
            ddlReaders.DataBind();
            int i = 0;
            foreach (var itemReader in CheckBoxList1.Items)
            {
                (((ListItem)itemReader).Selected) = false;
                CheckBoxList cbl = ((CheckBoxList)(phActiveAnt.FindControl(i.ToString())));
                if(cbl!=null)
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

                            if (flag == true)
                            {
                                entity.StationInsert(txtName.Text);
                                flag = false;
                                Written = true;
                            }
                            int StationId=entity.Station.OrderByDescending(s=>s.StationId).First().StationId+1;

                            entity.ConnectionDetailsInStationInsert(StationId, Convert.ToInt32(((ListItem)itemReader).Value), Convert.ToInt32(((ListItem)itemAnt).Text));
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
            ChangeVisible();
            DataTable dtAntennaAndReader;
            int stationId=Convert.ToInt32(ddlReaders.SelectedValue);
            var AntennaAndReader = entity.ConnectionDetailsInStation.Where(s => s.StationId == stationId).ToList();
            int i = 0;

            foreach (var itemReader in CheckBoxList1.Items)
            {
                if (AntennaAndReader[i].Antena.ToString() == ((ListItem)itemReader).Value)
                {
                    (((ListItem)itemReader).Selected) = true;
                    CheckBoxList cbl = ((CheckBoxList)(phActiveAnt.FindControl(i.ToString())));
                    foreach (var itemAnt in cbl.Items)
                    {
                        if (AntennaAndReader[i].Antena.ToString() == ((ListItem)itemAnt).Text)
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
            entity.StationDelete(Convert.ToInt32(Session["ddlReaders.SelectedValue"]));
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
