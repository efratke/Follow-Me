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
    public partial class Reader : System.Web.UI.Page
    {
        Dal dal;
        FollowMeDBEntities ef = new FollowMeDBEntities();
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
        private List<int> GetSelectedAntennaList()
        {
            System.Web.UI.WebControls.CheckBox[] antennaBoxes = { Ant1CheckBox, Ant2CheckBox, Ant3CheckBox, Ant4CheckBox };
            List<int> ant = new List<int>();
            for (int antIdx = 0; antIdx < antennaBoxes.Length; antIdx++)
            {
                System.Web.UI.WebControls.CheckBox antBox = antennaBoxes[antIdx];
                if (antBox.Visible && antBox.Enabled && antBox.Checked)
                {
                    int antNum = antIdx + 1;
                    ant.Add(antNum);
                }
            }
            if (0 == ant.Count)
            {
                throw new ArgumentException("Please select at least one antenna");
            }
            return ant;
        }


        protected void btnOk_Click(object sender, EventArgs e)
        {
            List<int> ant;
            try
            {
                ant = GetSelectedAntennaList();
                 ef.ReaderInsert(txtName.Text, txtArea.Text, txtIp.Text);
                System.Web.UI.WebControls.CheckBox[] antennaBoxes = { Ant1CheckBox, Ant2CheckBox, Ant3CheckBox, Ant4CheckBox };
                ef.ActiveAntennasInsert((Ant1CheckBox.Checked ? 1 : 0), (Ant2CheckBox.Checked ? 2 : 0), (Ant3CheckBox.Checked ? 3 : 0), (Ant4CheckBox.Checked ? 4 : 0));
                ClientScript.RegisterStartupScript(GetType(),
                   "completed", "<SCRIPT LANGUAGE='javascript'>alert(' action completed! ')</script>");
            
                if (Session["edit"] != null)
                {
                    DeleteReader(gvReaders.SelectedRow.Cells[1].Text);
                    Session["edit"] = null;
                }
                ChangeVisible();
                this.DataBind();
            }
            catch (ArgumentException ex)
            {
                ClientScript.RegisterStartupScript(GetType(),
                  "error", "<SCRIPT LANGUAGE='javascript'>alert(' error in save ')</script>");
            
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ChangeVisible();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (gvReaders.SelectedIndex == -1)
            {
                ClientScript.RegisterStartupScript(GetType(),
                    "Error", "<SCRIPT LANGUAGE='javascript'>alert(' You  must choose reader to edit! ')</script>");
            }
            else
            {
                Session["edit"] = true;
                txtName.Text = gvReaders.SelectedRow.Cells[2].Text;
                txtArea.Text = gvReaders.SelectedRow.Cells[3].Text;
                txtIp.Text = gvReaders.SelectedRow.Cells[4].Text;
                ChangeVisible();
                dal = new Dal();
                DataTable dtAntennaAndReader;
                int readerId = Convert.ToInt32(gvReaders.SelectedRow.Cells[1].Text);
                var listConn= ef.ActiveAntenna.Where(x => x.ReaderId == readerId).Select(x => x.ActiveAntennas).ToList();
                bool[] ant = { false, false, false, false };
                foreach (var item in listConn)
                {
                ant[Convert.ToInt32(item.Value) - 1] = true;
                }

                Ant1CheckBox.Checked = ant[0];
                Ant2CheckBox.Checked = ant[1];
                Ant3CheckBox.Checked = ant[2];
                Ant4CheckBox.Checked = ant[3];
            }
        }

        protected void lnkNew_Click(object sender, EventArgs e)
        {
            txtArea.Text = "";
            txtIp.Text = "";
            txtName.Text = "";
            Ant1CheckBox.Checked = false;
            Ant2CheckBox.Checked = false;
            Ant3CheckBox.Checked = false;
            Ant4CheckBox.Checked = false;
            ChangeVisible();
        }


        protected void btnDel_Click(object sender, EventArgs e)
        {
            if (gvReaders.SelectedIndex == -1)
            {
                ClientScript.RegisterStartupScript(GetType(),
                    "Error", "<SCRIPT LANGUAGE='javascript'>alert(' You  must choose reader to edit! ')</script>");
            }
            else
            {
                DeleteReader(gvReaders.SelectedRow.Cells[1].Text);
                gvReaders.DataBind();
            }
        }

        protected void DeleteReader(string id)
        {
            ef.ReaderDelete(Convert.ToInt32(id));
               }



        protected void ChangeVisible()
        {
            foreach (System.Web.UI.Control item in Panel1.Controls)
            {
                try
                {
                    item.Visible = !(item.Visible);
                }
                catch { }
            }

        }

    }
}