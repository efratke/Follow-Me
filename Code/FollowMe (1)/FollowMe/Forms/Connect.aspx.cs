using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FollowMe.Forms
{
    public partial class Connect : System.Web.UI.Page
    {


        ConnectReaders cr;
        protected void initReader_Click(object sender, EventArgs e)
        {
            try
            {
                Img1.Visible = true;
                cr.initReader(sender, e);
                Init();
            }
            catch (Exception)
            {
                if (!String.IsNullOrEmpty(cr.ErrorMessage))
                    ClientScript.RegisterStartupScript(GetType(),
                  "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + cr.ErrorMessage + " ')</script>");
                else
                    ClientScript.RegisterStartupScript(GetType(),
             "Message", "<SCRIPT LANGUAGE='javascript'>alert('unknown error accourate ')</script>");

                Img1.Visible = false;

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Application["connectReaders"] != null)
            {
                cr = Application["connectReaders"] as ConnectReaders;
            }
            Init();
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["MasterPage"] != null)
            {
                MasterPage master = Session["MasterPage"] as MasterPage;
                this.MasterPageFile = master.MasterPageFile;
            }
        }
        protected void Init()
        {
            initReader.Text = cr.StartRead;

            //dt.Columns.Remove("TagsReaderId");
            if (initReader.Text.CompareTo("Disconnect") == 0)
            {
                lblReaders.Visible = true;
                gvReaders.Visible = true;
                tmrCount.Enabled = true;
                tmrCount.Interval = 100000000;
                //gvReaders.DataSource = cr.DtReaders;
                //gvReaders.DataBind();

                // if (cr.listTags != null)
                {
                    //lblTags.Visible = true;
                    //gvTags.DataSource = cr.listTags;
                    //gvTags.DataBind();
                }
            }
            else
            {
                tmrCount.Enabled = false;
                lblTags.Visible = false;
            }
        }

        protected void tmrCount_Tick(object sender, EventArgs e)
        {
            lblTags.Text = "Count tags detected: " + cr.countEPC;
            lblTags.Visible = true;

        }

    }
}