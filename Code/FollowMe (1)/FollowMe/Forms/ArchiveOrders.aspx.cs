using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FollowMe.Forms
{
    public partial class ArchiveOrders : System.Web.UI.Page
    {
        DataTable dtArchiveOrders;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //TODO   
                // dataל ddlProcess + ddlCustomer לקשר את 
                
            }
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["MasterPage"] != null)
            {
                //MasterPage master = Session["MasterPage"] as MasterPage;
                //this.MasterPageFile = master.MasterPageFile;
            }
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            //TODO 
            Session["dtArchiveOrders"] = dtArchiveOrders;
        }

        protected void btnDate_Click(object sender, EventArgs e)
        {
            tblDates.Visible = true;
            btnOk.Visible = true;
            pnlShow.Visible = false;
        }

        protected void btnAll_Click(object sender, EventArgs e)
        {
            //TODO 
            //dtArchiveOrders = 
            gvShow.DataSource = dtArchiveOrders;
            gvShow.DataBind();
             Session["dtArchiveOrders"] = dtArchiveOrders;
           pnlShow.Visible = true;
            tblDates.Visible = false;
            btnOk.Visible = false;
        }

        protected void btnFrom_Click(object sender, EventArgs e)
        {
            clnStart.Visible = true;
            clnEnd.Visible = false;
        }

        protected void btnTo_Click(object sender, EventArgs e)
        {
            clnEnd.Visible = true;
            clnStart.Visible = false;
        }

        protected void clnStart_OnSelectionChanged(object sender, EventArgs e)
        {
            txtFrom.Text = clnStart.SelectedDate.ToShortDateString();
            clnStart.Visible = false;
        }

        protected void clnEnd_OnSelectionChanged(object sender, EventArgs e)
        {
            txtTo.Text = clnEnd.SelectedDate.ToShortDateString();
            clnEnd.Visible = false;
        }

        //protected void ddlProcess_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (ddlCustomer.SelectedIndex == -1)
        //    {
        //        dtArchiveOrders = Session["dtArchiveOrders"] as DataTable;
        //        DataView dv = new DataView(dtArchiveOrders);
        //        string sinun = string.Format("ProcessId={0} ", ddlProcess.SelectedValue);
        //        dv.RowFilter = sinun;
        //        gvShow.DataSource = dv;
        //        gvShow.DataBind();
        //    }
        //    else
        //    {
        //        Sinun();
        //    }
        //}

        protected void ddlCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ddlCustomer.SelectedIndex == -1)
            //{
            dtArchiveOrders = Session["dtArchiveOrders"] as DataTable;
            DataView dv = new DataView(dtArchiveOrders);
            string sinun = string.Format("CustomerId={0} ", ddlCustomer.SelectedValue);
            dv.RowFilter = sinun;
            gvShow.DataSource = dv;
            gvShow.DataBind();
            //}
            //else
            //{
            //    Sinun();
            //}
        }
        //protected void Sinun()
        //{
        //    dtArchiveOrders = Session["dtArchiveOrders"] as DataTable;
        //    DataView dv = new DataView(dtArchiveOrders);
        //    string sinun = string.Format("ProcessId={0} and CustomerId={1}", ddlProcess.SelectedValue, ddlCustomer.SelectedValue);
        //    dv.RowFilter = sinun;
        //    gvShow.DataSource = dv;
        //    gvShow.DataBind();
        //}



        protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShow.PageIndex = e.NewPageIndex;
        }
    }
}