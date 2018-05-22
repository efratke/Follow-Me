using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Adapters;
using System.Web.UI.WebControls.Expressions;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Text;
using System.IO;
using System.Threading;
using ThingMagic;
using System.Timers;
using ZeroconfService;
namespace FollowMe
{
    public class ConnectReaders
    {
        private static string startRead;

        public string StartRead
        {
            get { return startRead; }
            set { startRead = value; }
        }
        DataTable dtReaders;

        public DataTable DtReaders
        {
            get { return dtReaders; }
            set { dtReaders = value; }
        }

        string errorMessage;
        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; }
        }
        int row;
        public static Reader reader = null;
        Reader rdr = null;
        Reader.Region regionToSet = new Reader.Region();
        TagDatabase tagdb = new TagDatabase();
        public string countEPC = "0";

        public ConnectReaders()
        {

            try
            {
                Dal dal = new Dal();
                dtReaders = dal.ReadTable("SELECT TagsReaderId,Ip FROM TagsReader");
            }
            catch (Exception e)
            {
            }

        }
        public void initReader(object sender, EventArgs e)
        {
            if (startRead.Equals("Disconnect"))
            {
                try
                {
                    startRead = "Connect";
                }
                finally
                {
                    
                }
            }
            else if (startRead.Equals("Connect"))
            {
                try
                {
                    for (row = 0; row < dtReaders.Rows.Count; row++)
                    {
                        initReader_Body(sender, e);
                        startToRead();

                    }

                    row = 0;
                    startRead = "Disconnect";

                }
                catch (Exception)
                {
                    ErrorMessage = "connect failed ";
                    throw new Exception();
                }

            }

        }
        private void initReader_Body(object sender, EventArgs e)
        {
            try
            {
                reader.Destroy();
                }
            catch {
                ErrorMessage = "connect failed ";
               
            }

            try
            {
                if (dtReaders.Rows[row][1] == "")
                    throw new IOException();
               

                ///Assign  reader to rdr
                reader = rdr; //(Reader)rdr;
                reader.Connect();
               
                regionToSet = (Reader.Region)reader.ParamGet("/reader/region/id");
                Reader.Region[] regions;
                if (reader is LlrpReader || reader is RqlReader)
                {
                    regions = new Reader.Region[] { regionToSet };
                }
                else
                {
                    regions = (Reader.Region[])reader.ParamGet("/reader/region/supportedRegions");
                }
                if (reader is SerialReader)
                {
                    if (!(reader.ParamGet("/reader/version/model").ToString().Equals("M6e")))
                    {
                        reader.ParamSet("/reader/tagReadData/reportRssiInDbm", true);
                    }
                }
                
            }

            catch (System.IO.IOException)
            {
               
                    ErrorMessage="Reader not connected on " + (string)dtReaders.Rows[row][1];
               
            }
            catch (ReaderException ex)
            {
                ErrorMessage="Error connecting to reader: " + ex.Message;
            }
            catch (System.UnauthorizedAccessException)
            {
                ErrorMessage="Access to " + ((string)dtReaders.Rows[row][1]) + " denied. Please check if another program is accessing this port";
            }

        }

        delegate void del();
        TagFilter selectionOnEPC = null;

        protected void startToRead()
        {
            bool triedStart = false;  // Did we go into the "Connect" clause?

            try
            {
               
                triedStart = true;
                startRead = "Disconnect";
                reader.TagRead += PrintTagRead;
                reader.StartReading();


            }
            catch (Exception exp)
            {

               
            }
        }



        /// <summary>
        /// Function that save the Tag Data inDB;
        /// </summary>
        /// <param name="read"></param>
        void PrintTagRead(Object sender, TagReadDataEventArgs e)
        {
            tagdb.Add();
            BLL bll = new BLL();
            countEPC = tagdb.TagList.Count.ToString();
             bll.WriteListEPCToDB(tagdb, ((int)dtReaders.Rows[row][0]));
           
        }

    }
}