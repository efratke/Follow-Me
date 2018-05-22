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
    public partial class Owner : System.Web.UI.Page
    {
        Dal dal;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (PreviousPage != null)
                {
                    Session["PreviousPage"] = PreviousPage;
                    if (PreviousPage.ToString().Equals("ASP.Orders_aspx"))
                    {
                        ChangeVisible();
                    }

                }
            }
            gvShowOwners.DataSourceID = "SqlDataSource1";
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

            RequiredFieldValidator RequiredFieldValidator1 = new RequiredFieldValidator();
            RequiredFieldValidator1.ErrorMessage = "You must enter data!";
            RequiredFieldValidator1.ControlToValidate = "txtName";
            //my.Controls.Add(RequiredFieldValidator1);
            dal = new Dal();

            List<SqlParameter> l = new List<SqlParameter>();
            l.Add(new SqlParameter("@company", (txtCompany.Text)));
            l.Add(new SqlParameter("Pass", (txtPass.Text)));
            //בדיקה שאין שם חברה וקוד זהה במערכת
            object o = dal.ReadScalar("CheckPass", l);
            if (o == null)
            {
                l.Clear();
                l = new List<SqlParameter>();
                l.Add(new SqlParameter("FirstName", (txtName.Text)));
                l.Add(new SqlParameter("LastName", (txtLName.Text)));
                l.Add(new SqlParameter("Pass", (txtPass.Text)));
                l.Add(new SqlParameter("Company", (txtCompany.Text)));
                l.Add(new SqlParameter("Address", (txtAddress.Text)));
                l.Add(new SqlParameter("Phone", txtPhone.Text));
                dal.WriteToDB("Owners", l);
                if (Session["PreviousPage"] == null)
                {
                    ChangeVisible();
                }
                else
                {
                    if (Session["PreviousPage"].ToString().Equals("ASP.tags_aspx"))
                    {
                        Server.Transfer("Tags.aspx");
                    }
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(),
                                      "Message", "<SCRIPT LANGUAGE='javascript'>alert(' הסיסמה נמצאת בשימוש משתמש אחר, נא לבחור סיסמה אחרת! ')</script>");
            }
        }

        protected void btnNewOwner_Click(object sender, EventArgs e)
        {
            ChangeVisible();
            txtName.Text = "";
            txtLName.Text = "";
            txtPass.Text = "";
            txtCompany.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            txtValidPass.Text = "";
        }
        protected void ChangeVisible()
        {
            pnlNewOwner.Visible = !(pnlNewOwner.Visible);
            pnlShow.Visible = !(pnlShow.Visible);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ChangeVisible();
        }
    }
}