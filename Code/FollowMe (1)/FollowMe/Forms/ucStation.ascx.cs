using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FollowMe.Forms
{
    public delegate void Cancellation(ucStation uc);
    public partial class ucStation : System.Web.UI.UserControl
    {

        public event Cancellation OnCancel;

        public string Type
        {
            get
            {
                return lblStation.Text;
            }
            set
            {
                lblStation.Text = value;
            }
        }
        private int typeId;
        public int TypeId
        {
            get
            {
                return typeId;
            }
            set
            {
                typeId = value;
            }
        }

        public string Time
        {
            get { return (txtTime.Text); }
            set
            {
                txtTime.Text = value.ToString();

            }
        }

        public string Details
        {
            get
            {
                return txtMoreDetailes.Text;
            }
            set
            {
                txtMoreDetailes.Text = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public ucStation()
        {

        }

        protected void btnCancelStat_Click(object sender, EventArgs e)
        {
            if (OnCancel != null)
                OnCancel(this);
        }
    }
}