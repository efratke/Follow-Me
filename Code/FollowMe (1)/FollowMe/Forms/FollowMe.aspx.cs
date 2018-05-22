using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace FollowMe.Forms
{
    public partial class FollowMe : System.Web.UI.Page
    {
        //Dal dal;
        DataTable dtOrders;
        DataTable dtShow;
        string empty = "/";
        DataTable dtAllStsation;

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (User.IsInRole("mannager") || User.IsInRole("employee"))
            //{
            //    Label4.Visible = false;
            //    phEnter.Visible = false;
            //    pnlCustomers.Visible = true;
            //}
            if (IsPostBack)
            {
                if (Session["dtOrders"] != null)
                    dtOrders = Session["dtOrders"] as DataTable;
                if (Session["dtShow"] != null)
                {
                    dtShow = Session["dtShow"] as DataTable;
                }
            }
            else
            {
                if (Session["company"] != null && Session["pass"] != null)
                {
                    company = Session["company"] as string;
                    txtName.Text = company;
                    pass = Session["pass"] as string;
                    txtPass.Text = pass;
                    View();
                }
            }
        }
        string company;
        string pass;
        protected void btnEnter_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(),
                       "completed", "<SCRIPT LANGUAGE='javascript'>alert(' You must choose customer! ')</script>");
            }
            else
                View();
        }
        protected void View() 
        {
            FollowMeDBEntities ef=new FollowMeDBEntities();
           company= ef.company(txtName.Text).FirstOrDefault();
            if (company == null)
            {
                 ClientScript.RegisterStartupScript(GetType(),
                   "completed", "<SCRIPT LANGUAGE='javascript'>alert(' Company name does not exist in the database! ')</script>");
             }
            else
            {
                btnEnter.Visible = false;
                Label4.Visible = false;
                if (txtPass.Text == "")
                    txtPass.Text = Session["pass"] as string;
                 pass = (string)(ef.Pass(txtPass.Text,txtName.Text)).FirstOrDefault();
                if (pass == null)
                {
                    ClientScript.RegisterStartupScript(GetType(),
                 "", "<SCRIPT LANGUAGE='javascript'>alert(' Password is incorrect! ')</script>");
                             }
                else
                {
                    Session["company"] = txtName.Text;
                    if (Session["pass"] == null)
                        Session["pass"] = txtPass.Text;
                    phEnter.Visible = false;
                    List<Int32?> lOrderId = ef.OrderIdSelect(txtPass.Text, txtName.Text).ToList();
                    dtOrders = new DataTable();
                    dtOrders.Columns.Add("OrderId");
                    
                    for (int i = 0; i < lOrderId.Count; i++)
                    {
                        dtOrders.Rows.Add(dtOrders.NewRow());
                        dtOrders.Rows[i][0] = lOrderId[0].Value;
                    }
                    dtOrders.Columns.Add("ProcessId");
                    dtOrders.Columns.Add("ProcessName");
                    dtOrders.Columns.Add("ColorId");
                    for (int i = 0; i < dtOrders.Rows.Count; i++)
                    {
                        dtOrders.Rows[i][1] = ef.ProcessIdSelect(Convert.ToInt32(dtOrders.Rows[i][0])).ToList()[0];
                        dtOrders.Rows[i][2] = ef.ProcessIdSelect(Convert.ToInt32(dtOrders.Rows[i][0])).ToList()[1];
                        dtOrders.Rows[i][3] = ef.ProcessIdSelect(Convert.ToInt32(dtOrders.Rows[i][0])).ToList()[2];
                    }
                    dtShow = new DataTable();
                    dtShow.Columns.Add("process", typeof(string));
                    dtShow.Columns.Add("color", typeof(string));
                    dtShow.Columns.Add("timeStart", typeof(string));
                    dtShow.Columns.Add("minutePast", typeof(string));
                    dtShow.Columns.Add("minuteEnd", typeof(string));
                    dtShow.Columns.Add("station", typeof(string));
                    dtShow.Columns.Add("nextStation", typeof(string));
                    dtShow.Columns.Add("status", typeof(string));
                    Session["dtShow"] = dtShow;
                    Session["dtOrders"] = dtOrders;
                    Label3.Visible = true;
                    tmrTime.Interval = 10000;
                    tmrTime.Enabled = true;
                    //tmrTime.Tick += new EventHandler<EventArgs>(tmrTime_Tick);
                    //this.Controls.Add(tmrTime);
                    //Show();
                    if (User.IsInRole("mannager") || User.IsInRole("employee"))
                    {
                        btnBack.Visible = true;
                        gvShowOwners.Visible = false;
                        Label5.Visible = false;
                    }
                }
            }
        }

        

        protected void tmrTime_Tick(object sender, EventArgs e)
        {
            Show();
        }

        protected void Show()
        {
            if (dtShow == null)
            {
                dtShow = new DataTable();
            }
            if (dtShow.Rows != null)
            {
                dtShow.Rows.Clear();
            }
            FollowMeDBEntities ef = new FollowMeDBEntities();
            dtAllStsation = new DataTable();
            dtAllStsation.Columns.Add("id", typeof(int));
            dtAllStsation.Columns.Add("station", typeof(string));
            for (int i = 0; i < dtOrders.Rows.Count; i++)
            {
                DataRow dr = dtShow.NewRow();
                DataRow dr1 = dtAllStsation.NewRow();
                dr["process"] = dtOrders.Rows[i][2];
                dr["color"] = dtOrders.Rows[i][3];
                var reader = ef.ReadingSelect(Convert.ToInt32(dtOrders.Rows[i][0]));
         
            }
            Session["dtAllStsation"] = dtAllStsation;
            gvSohw.DataSource = dtShow;
            gvSohw.EmptyDataText = "There are currently no data to display";
            gvSohw.PageSize = 5;
            gvSohw.DataBind();
            gvSohw.Visible = true;
            Label3.Visible = false;
            //tmrTime.Interval = 60000;
        }

        protected void gvSohw_OnSelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            if (gvSohw.Rows[e.NewSelectedIndex].Cells[6].Text.CompareTo("Inactive") != 0)
            {
                if (Session["dtAllStsation"] != null)
                    dtAllStsation = Session["dtAllStsation"] as DataTable;
                string selectedStation = gvSohw.Rows[e.NewSelectedIndex].Cells[6].Text;
                string selectedStation1 = gvSohw.Rows[e.NewSelectedIndex].Cells[5].Text;
                gvStation.DataSource = dtAllStsation.Rows[e.NewSelectedIndex]["station"];
                gvStation.PageSize = 5;
                gvStation.DataBind();
                gvStation.Visible = true;
                for (int i = 0; i < ((DataTable)dtAllStsation.Rows[e.NewSelectedIndex]["station"]).Rows.Count; i++)
                {
                    if (empty.Equals(selectedStation) == false)
                        if (((DataTable)dtAllStsation.Rows[e.NewSelectedIndex]["station"]).Rows[i][0].Equals(selectedStation1))
                        {
                            gvStation.SelectedIndex = i;
                        }
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

        protected string TimeToString(TimeSpan time)
        {
            return time.Hours + ":" + time.Minutes;
        }


        protected void btnBack_Click(object sender, EventArgs e)
        {
            btnBack.Visible = false;
            gvShowOwners.Visible = true;
            Label5.Visible = true;
            btnEnter.Visible = true;
            gvSohw.Visible = false;
            gvStation.Visible = false;
        }

        protected void gvSohw_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow gvr = gvShowOwners.Rows[e.NewSelectedIndex];
            txtName.Text = gvr.Cells[5].Text;
            Session["pass"] = gvr.Cells[4].Text;
        }


    }
}