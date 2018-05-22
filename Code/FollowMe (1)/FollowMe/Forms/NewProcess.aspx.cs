using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
//using Efrat.Dal.EntitiesData;
namespace FollowMe.Forms
{
    public partial class NewProcess : System.Web.UI.Page
    {

        DataTable dtReaders;
        DataTable dtColors;
        Dal dal;
        static int i = 0;
        ucStation uc;
        List<ucStation> lUcStation;
        public List<ucStation> LUcStation
        {
            get
            {
                if (Session["lUcStation"] == null)
                {
                    Session["lUcStation"] = new List<ucStation>();
                }
                return (List<ucStation>)Session["lUcStation"];
            }
            set { Session["lUcStation"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dal = new Dal();
                dtReaders = dal.GetTable("Station");
                ddlReaders.DataSource = dtReaders;
                ddlReaders.DataTextField = "Name";
                ddlReaders.DataValueField = "StationId";
                ddlReaders.DataBind();



                dtColors = dal.GetTable("Colors");
                ddlColor.DataSource = dtColors;
                ddlColor.DataTextField = "ColorName";
                ddlColor.DataValueField = "ColorId";
                ddlColor.DataBind();
                Session["dtColors"] = dtColors;
            }
            else
            {
                updateView();
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
        ucStation UcStation;
        void updateView()
        {
            List<ucStation> lEzer = new List<ucStation>();
            foreach (ucStation item in LUcStation)
            {
                UcStation = this.LoadControl("~/ucStation.ascx") as ucStation;
                UcStation.TypeId = item.TypeId;
                UcStation.Type = item.Type;
                UcStation.Time = item.Time;
                UcStation.Details = item.Details;
                UcStation.OnCancel += new Cancellation(UcStation_OnCancel);
                pnlStation.Controls.Add(UcStation);
                lEzer.Add(UcStation);
            }
            LUcStation = lEzer;
        }

        void UcStation_OnCancel(ucStation uc)
        {
            LUcStation.Remove(uc);
            Session["lUcStation"] = LUcStation;
            pnlStation.Controls.Remove(uc);
        }

        protected void btnChoose_Click(object sender, EventArgs e)
        {
            if (String.Compare(btnChoose.Text, "Choosed") == 0)
            {
                btnOk.Visible = true;
                ddlReaders.Enabled = false;
                btnChoose.Text = "Add station";
                uc = this.LoadControl("~/ucStation.ascx") as ucStation;
                uc.TypeId = Convert.ToInt32(ddlReaders.SelectedValue);
                uc.Type = ddlReaders.SelectedItem.ToString();
                uc.OnCancel += new Cancellation(UcStation_OnCancel);
                pnlStation.Controls.Add(uc);
                LUcStation.Add(uc);
            }
            else
            {
                btnOk.Visible = false;
                ddlReaders.Enabled = true;
                btnChoose.Text = "Choosed";
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            if (LUcStation == null)
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert(' You  must choose least one station! ')</script>");
            }
            else
            {
                dal = new Dal();
                List<SqlParameter> lParam = new List<SqlParameter>();
                lParam.Add(new SqlParameter("Name", txtProcess.Text));
                bool flag = true;
                int id = 0;
                if (Session["dtColors"] != null)
                    dtColors = Session["dtColors"] as DataTable;
                for (int i = 0; flag == true && i < dtColors.Rows.Count; i++)
                {
                    if (((string)dtColors.Rows[i][1]).CompareTo(txtColor.Text) == 0)
                    {
                        flag = false;
                        id = (int)dtColors.Rows[i][0];
                    }
                }
                if (flag)
                {
                    List<SqlParameter> lParam1 = new List<SqlParameter>();
                    lParam1.Add(new SqlParameter("ColorName", txtColor.Text));
                    dal.WriteToDB("Colors", lParam1);
                    id = (int)dal.ReadScalar("select top 1 ColorId from Colors order by ColorId desc");
                }
                lParam.Add(new SqlParameter("ColorId", id));
                dal.WriteToDB("Processes", lParam);
                foreach (ucStation item in LUcStation)
                {
                    lParam.Clear();
                    lParam = new List<SqlParameter>();
                    lParam.Add(new SqlParameter("Station", item.TypeId));
                    lParam.Add(new SqlParameter("Minutes", item.Time));
                    lParam.Add(new SqlParameter("MoreDetails", item.Details));
                    dal.WriteToDB("ProcessDetails", lParam);
                }
                if (Session["edit"] != null)
                {
                    bool edit = (bool)Session["edit"];
                    if (edit)
                    {
                        if (Session["gvr"] != null)
                        {
                            GridViewRow gvr = Session["gvr"] as GridViewRow;
                            gvProcess.DeleteRow(gvr.RowIndex);
                            Session["edit"] = null;
                        }
                    }
                }
                ChangeVisible();
                Session["lUcStation"] = LUcStation;
                gvProcess.DataBind();

            }
        }


        protected void ddlColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtColor.Text = ddlColor.SelectedItem.Text;
        }

        protected void gvProcess_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow gvr = gvProcess.Rows[e.NewSelectedIndex];
            Session["gvr"] = gvr;
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            // ClientScript.RegisterStartupScript(GetType(),  "Message", "<SCRIPT LANGUAGE='javascript'>alert(' Do you want to create a process based on existing process? ')</script>");
            //pnlEdit.Visible = ViewEdit();

            {
                pnlEdit.Visible = true;
                gvProcess.Visible = false;
                btnEdit.Enabled = false;
                btnNew.Enabled = false;
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            bool succed = ViewEdit();
            Session["edit"] = succed;
            pnlEdit.Visible = succed;
        }

        protected bool ViewEdit()
        {
            if (gvProcess.SelectedIndex == -1)
            {
                ClientScript.RegisterStartupScript(GetType(),
                  "Message", "<SCRIPT LANGUAGE='javascript'>alert(' You must select editing process ')</script>");
                return false;
            }
            else
            {
                btnEdit.Enabled = false;
                btnNew.Enabled = false;
                gvProcess.Visible = false;
                if (Session["gvr"] != null)
                {
                    GridViewRow gvr = Session["gvr"] as GridViewRow;
                    txtProcess.Text = gvr.Cells[2].Text;
                    bool flag = true;
                    if (Session["dtColors"] != null)
                    {
                        dtColors = Session["dtColors"] as DataTable;
                        for (int i = 0; flag == true && i < dtColors.Rows.Count; i++)
                        {
                            if (((int)dtColors.Rows[i][0]) == Convert.ToInt32((gvr.Cells[3].Text)))
                            {
                                flag = false;
                                ddlColor.SelectedIndex = i;
                            }
                        }
                    }
                    txtColor.Text = gvr.Cells[3].Text;
                    dal = new Dal();
                    List<SqlParameter> l = new List<SqlParameter>();
                    l.Add(new SqlParameter("ProcessId", Convert.ToInt32(gvr.Cells[1].Text)));
                    DataTable dtProcessDetails = dal.GetTable("ProcessDetails", l);
                    pnlStation.Controls.Clear();
                    for (int i = 0; i < dtProcessDetails.Rows.Count; i++)
                    {
                        uc = this.LoadControl("~/ucStation.ascx") as ucStation;
                        uc.TypeId = (int)(dtProcessDetails.Rows[i]["ProcessDetailId"]);
                        uc.Type = dtProcessDetails.Rows[i]["Station"].ToString();
                        uc.Time = dtProcessDetails.Rows[i]["Minutes"].ToString();
                        uc.Details = dtProcessDetails.Rows[i]["More details"].ToString();
                        uc.OnCancel += new Cancellation(UcStation_OnCancel);
                        pnlStation.Controls.Add(uc);
                        LUcStation.Add(uc);
                    }
                    btnOk.Visible = true;
                }
            }
            return true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ChangeVisible();
        }

        private void ChangeVisible()
        {
            pnlEdit.Visible = false;
            pnlStation.Controls.Clear();
            LUcStation.Clear();
            gvProcess.Visible = true;
            txtColor.Text = "";
            txtProcess.Text = "";
            ddlColor.SelectedIndex = 0;
            btnEdit.Enabled = true;
            btnNew.Enabled = true;
        }
    }
}