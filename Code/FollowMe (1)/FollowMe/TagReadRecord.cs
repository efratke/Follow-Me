using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.IO;
using System.Threading;
using ThingMagic;
using System.Timers;
using ZeroconfService;

namespace FollowMe
{
    public class TagReadRecord : INotifyPropertyChanged
    {
        protected TagReadData RawRead;

        /// <summary>
        /// Merge new tag read with existing one
        /// </summary>
        /// <param name="data">New tag read</param>
        public void Update(TagReadData newData)
        {
            int count = newData.ReadCount;
            newData.ReadCount += ReadCount;
            RawRead = newData;  
        }

        public DateTime TimeStamp
        {
            get { return RawRead.Time; }
        }
        public int ReadCount
        {
            get { return RawRead.ReadCount; }
        }
        public int Antenna
        {
            get { return RawRead.Antenna; }
        }
         public string EPC
        {
            get { return RawRead.EpcString; }
        }
#region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            if (null != PropertyChanged)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion
    }
      
}