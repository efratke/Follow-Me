using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace followMe.Forms
{
    public partial class Employee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //gvAllEmployees.DataSourceID = "SqlDataSource1";
            if (!IsPostBack)
            {

                //TODO   
                // dataל ddlAuthorization  לקשר את 
                
            }
        }


        public void NewEmployee(string Name, string Pass, int AuthorizationId)
        {
            //TODO   
            //לשמור את העובד החדש בDB
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text != "" && txtPass.Text != "")
                {
                    NewEmployee(txtName.Text, txtPass.Text, Convert.ToInt32(ddlAuthorization.SelectedValue));
                    Page.ClientScript.RegisterStartupScript(null, null, "alert('save succeed')");
                }
                else
                {
                    //TODO   הודעת שגיאה מתאימה 

                    pnlEmployee.Visible = false;
                    btnEmployee.Visible = true;
                    gvAllEmployees.Visible = false;
                    btnAllEmployees.Visible = true;
                }
            }
            catch (Exception)
            {

                //TODO   הודעת שגיאה מתאימה 

            }
        }




        protected void btnEmployee_Click(object sender, EventArgs e)
        {
            pnlEmployee.Visible = true;
            btnEmployee.Visible = false;
            gvAllEmployees.Visible = false;
            btnAllEmployees.Visible = false;
            gvAllEmployees.Visible = false;

        }


        protected void btnAllEmployees_Click(object sender, EventArgs e)
        {
            pnlEmployee.Visible = false;

            //TODO   
            // dataל gvAllEmployees  לקשר את  
             gvAllEmployees.Visible = true;
        }

        protected void btnAllGroup_Click(object sender, EventArgs e)
        {
            pnlEmployee.Visible = false;
            gvAllEmployees.Visible = false;
        }
    }
}
