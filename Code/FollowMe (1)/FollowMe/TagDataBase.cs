using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Text;
using System.IO;
using System.Threading;
using ThingMagic;
using System.Timers;
using ZeroconfService;
using System.Data.SqlClient;

namespace FollowMe
{
    [Serializable]
    public class TagDatabase
    {
        /// <summary>
        /// TagReadData model (backs data grid display)
        /// </summary>
        List<TagReadRecord> _tagList = new List<TagReadRecord>();

        /// <summary>
        /// EPC index into tag list
        /// </summary>
        Dictionary<string, TagReadRecord> EpcIndex = new Dictionary<string, TagReadRecord>();
        public TagDatabase()
        {
            //_tagList.RaiseListChangedEvents = false;
        }

        public List<TagReadRecord> TagList
        {
            get { return _tagList; }
        }

        public void Clear()
        {
            EpcIndex.Clear();
            //_tagList.Clear();
            // Clear doesn't fire notifications on its own
           // _tagList.ResetBindings();
        }

        public void Add()
        {
            
        }

    }

}