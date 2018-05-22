using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FollowMe.Forms
{
    public partial class Manager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["MasterPage"] != null)
            {
                MasterPage master = Session["MasterPage"] as MasterPage;
                this.MasterPageFile = master.MasterPageFile;
            }
        }

        protected void linkBtnReader_Click(object sender, EventArgs e)
        {
            Server.Transfer("Reader.aspx");

        }

        protected void linkBtnReaders_Click(object sender, EventArgs e)
        {
            Server.Transfer("Station.aspx");
        }

        protected void linkBtnNewProcess_Click(object sender, EventArgs e)
        {
            Server.Transfer("NewProcess.aspx");
        }

    }
}