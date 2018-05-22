using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace FollowMe.Forms
{
    public partial class Orders : System.Web.UI.Page
    {
        DataTable dtProcess;
        DataTable dtOwners;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!User.IsInRole("mannager") && !User.IsInRole("employee"))
                {
                   // Server.Transfer("FollowMe.aspx");
                }
                //TODO   
                // dataל gvProcess לקשר את 
                
                //gvProcess.DataSource =new Object();
                //gvProcess.DataBind();
                //gvProcess.Columns[0].ControlStyle.Width = 0;

                //TODO   
                // dataל dtOwners לקשר את 
               
                dtOwners=new DataTable() ;
                ddlOwners.DataSource = dtOwners;
                ddlOwners.DataTextField = "Company";
                ddlOwners.DataValueField = "OwnerId";
                ddlOwners.DataBind();
                if (PreviousPage != null)
                {
                    Panel2.Visible = true;
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

        protected void btnOk_Click(object sender, EventArgs e)
        {
            GridViewRow gvr = Session["gvr"] as GridViewRow;
            if (gvr != null)
            {
                int process = Convert.ToInt32(gvr.Cells[1].Text);
                string color = gvr.Cells[3].Text;
                int price = Convert.ToInt32(txtAmount.Text) * Convert.ToInt32(gvr.Cells[4].Text);
                //dal = new Dal();
                //List<SqlParameter> l = new List<SqlParameter>();
                //l.Add(new SqlParameter("Date", DateTime.Now));
                //l.Add(new SqlParameter("OwnerId", Convert.ToInt32(ddlOwners.SelectedValue)));
                //l.Add(new SqlParameter("Shipper", ""));
                //l.Add(new SqlParameter("Price", price));
                //l.Add(new SqlParameter("Color", color));
                //l.Add(new SqlParameter("Process", process));
                //l.Add(new SqlParameter("Amount", Convert.ToInt32(txtAmount.Text)));
                //l.Add(new SqlParameter("firstEPC", (txtFirstEpc.Text)));
                //l.Add(new SqlParameter("lastEPC", CalculationLastEpc((txtFirstEpc.Text), Convert.ToInt32(txtAmount.Text) - 1)));
                //dal.WriteToDB("OrderDetails", l);
                //MessageBox.Show("  Invitation was The payment is  " + price);

                if (Session["edit"] != null)
                {
                    GridViewRow gvrOrder = Session["gvrOrder"] as GridViewRow;
                    DeleteOrder(Convert.ToInt32((gvrOrder.Cells[1].Text)));
                    Session["edit"] = null;
                }
                btnVisible();
                gvOrders.DataBind();
                ChangeVisible();
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(),
                 "Message", "<SCRIPT LANGUAGE='javascript'>alert(' Choose washing process! ')</script>");
            }
        }


        protected void gvProcess_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow gvr = gvProcess.Rows[e.NewSelectedIndex];
            Session["gvr"] = gvr;
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            btnVisible();
            ChangeVisible();
            txtAmount.Text = "";
            txtFirstEpc.Text = "";
            gvProcess.SelectedIndex = -1;
         }

        private void btnVisible()
        {
            pnlbtn.Visible = false;
            gvOrders.SelectedIndex = -1;

        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            btnVisible();
            GridViewRow gvr = Session["gvrOrder"] as GridViewRow;
            DeleteOrder(Convert.ToInt32((gvr.Cells[1].Text)));
            Panel1.Visible = false;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            btnVisible();
            Session["edit"] = true;
            ChangeVisible();
            GridViewRow gvr = Session["gvrOrder"] as GridViewRow;
            for (int i = 0; i < ddlOwners.Items.Count; i++)
            {
                if (ddlOwners.Items[i].Value == gvr.Cells[2].Text)
                {
                    ddlOwners.SelectedIndex = i;
                }
            }
            for (int i = 0; i < gvProcess.Rows.Count; i++)
            {
                if ((gvProcess.Rows[i].Cells[1].Text) == gvr.Cells[5].Text)
                {
                    gvProcess.SelectedIndex = i;
                }
            }
            txtFirstEpc.Text = gvr.Cells[10].Text;
            txtAmount.Text = gvr.Cells[8].Text;
            Panel2.Visible = true;
        }

        protected void DeleteOrder(int id)
        {
            //dal = new Dal();
            //List<SqlParameter> l = new List<SqlParameter>();
            //l.Add(new SqlParameter("OrderId", id));
            //dal.DeleteInDB("Order", l);
            //gvOrders.DataBind();
        }

        protected void ChangeVisible()
        {
            pnlNew.Visible = !(pnlNew.Visible);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ChangeVisible();

        }

        protected void gvOrders_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow gvr = gvOrders.Rows[e.NewSelectedIndex];
            Session["gvrOrder"] = gvr;
            pnlbtn.Visible = true;
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            Server.Transfer("Owner.aspx");
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            Panel2.Visible = true;
        }

        protected void btnFinish_Click(object sender, EventArgs e)
        {
             
            GridViewRow gvr = Session["gvrOrder"] as GridViewRow;
            //dal = new Dal();
            //List<SqlParameter> l = new List<SqlParameter>();
            //l.Add(new SqlParameter("OrderId", Convert.ToInt32(gvr.Cells[1].Text)));
            //l.Add(new SqlParameter("OwnerId", Convert.ToInt32(gvr.Cells[2].Text)));
            //l.Add(new SqlParameter("Amount", Convert.ToInt32(gvr.Cells[8].Text)));
            //l.Add(new SqlParameter("OrderDate", Convert.ToDateTime(gvr.Cells[4].Text)));
            //l.Add(new SqlParameter("FinishDate", DateTime.Now));
            //dal.WriteToDB("ArchiveOrders", l);

            //l.Clear();
            //l.Add(new SqlParameter("OrderId", Convert.ToInt32(gvr.Cells[1].Text)));
            //dal.DeleteInDB("Orders", l);
            btnVisible();
            gvOrders.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            btnVisible();
            if (Session["gvrOrder"] != null)
            {
                GridViewRow gvr = Session["gvrOrder"] as GridViewRow;
                pnlSearch.Visible = true;
                DataTable dtStation = new DataTable();
                dtStation = new DataTable();
                dtStation.Columns.Add("Station", typeof(string));
                dtStation.Columns.Add("Amount", typeof(int));
                DataTable dtItems = new DataTable();
                //TODO   
                
                //dtItems =// ("select firstEPC,Amount from OrderDetails where OrderId=" + gvr.Cells[1].Text);
                Label4.Text = "  Total items:  " + dtItems.Rows[0]["Amount"].ToString();
                string firstEPC = dtItems.Rows[0]["firstEPC"].ToString();
                DataTable dtEPC = new DataTable();


                char[] strfirstEPC = firstEPC.ToArray();
                bool flag = true;
                for (int i = 0; flag && i < Convert.ToInt32(dtItems.Rows[0]["Amount"]); i++)
                {
                    //TODO 
                    List<SqlParameter> l = new List<SqlParameter>();
                    l.Add(new SqlParameter("EPC", new String(strfirstEPC)));
                    bool found = false;
                    String Station = null;
                    try
                    {
                        //Station = (String)(dal.GetTable("ReadingForOrderId", l)).Rows[0][1];
                    }
                    catch
                    {
                        ClientScript.RegisterStartupScript(GetType(),
                                        "Message", "<SCRIPT LANGUAGE='javascript'>alert(' תהליך הכיבוס טרם החל! ')</script>");
                        pnlSearch.Visible = false;
                        flag = false;
                    }
                    if (flag == true)
                    {

                        for (int x = 0; x < dtStation.Rows.Count && found == false; x++)
                        {
                            if (Station.CompareTo(dtStation.Rows[x]["Station"]) == 0)
                            {
                                dtStation.Rows[x]["Amount"] = ((int)dtStation.Rows[x]["Amount"]) + 1;
                                found = true;
                            }
                        }
                        if (found == false)
                        {
                            DataRow dr = dtStation.NewRow();
                            dr["Station"] = Station;
                            dr["Amount"] = 1;
                            dtStation.Rows.Add(dr);
                        }
                        strfirstEPC = CalculationLastEpc(new String(strfirstEPC), 1);
                        ////for (int j = strfirstEPC.Length - 1; j >= 0 && flag; j--)
                        ////{
                        ////    int num = (int)(strfirstEPC[j]);
                        ////    if (num == 102)
                        ////    {
                        ////        strfirstEPC[j] = '0';
                        ////    }
                        ////    else if (num == 57)
                        ////    {
                        ////        strfirstEPC[j] = 'a';
                        ////        flag = false;
                        ////    }
                        ////    else
                        ////    {
                        ////        strfirstEPC[j] = (char)(num + 1);
                        ////        flag = false;
                        ////    }
                        ////}
                    }
                }
                if (flag == true)
                {
                    gvStations.DataSource = dtStation;
                    gvStations.AutoGenerateColumns = false;
                    gvStations.EmptyDataText = "There are currently no data to display";
                    gvStations.PageSize = 5;
                    gvStations.DataBind();
                }
            }

            //else
            //{
            //   
            //}
        }
        protected void btnOk1_Click(object sender, EventArgs e)
        {
            pnlSearch.Visible = false;
        }

        protected char[] CalculationLastEpc(string firstEPC, int Amount)
        {
            char[] strfirstEPC = firstEPC.ToArray();
            bool flag;
            for (int i = 0; i < Amount; i++)
            {
                flag = true;
                for (int j = strfirstEPC.Length - 1; j >= 0 && flag; j--)
                {
                    int num = (int)(strfirstEPC[j]);
                    if (num == 102)
                    {
                        strfirstEPC[j] = '0';
                    }
                    else if (num == 57)
                    {
                        strfirstEPC[j] = 'a';
                        flag = false;
                    }
                    else
                    {
                        strfirstEPC[j] = (char)(num + 1);
                        flag = false;
                    }
                }
            }
            return strfirstEPC;
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            Server.Transfer("FollowMe.aspx");
        }
        protected void btnArchiveOrders_Click(object sender, EventArgs e)
        {
            Server.Transfer("ArchiveOrders.aspx");
        }
    }
}