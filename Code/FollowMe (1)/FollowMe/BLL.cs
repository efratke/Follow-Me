using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace FollowMe
{
    class BLL
    {
        public List<SqlParameter> WriteListEPCToDB(TagDatabase tagdb , int TagsReaderId)
        {
            List<SqlParameter> l = new List<SqlParameter>();
            Dal d = new Dal();
            foreach (TagReadRecord tag in tagdb.TagList)
            {
                l = new List<SqlParameter>();
                l.Add(new SqlParameter("EPC", tag.EPC));
                l.Add(new SqlParameter("TagsReaderId", TagsReaderId));
                l.Add(new SqlParameter("Antena", tag.Antenna));
                l.Add(new SqlParameter("Time", DateTime.Now));
                d.WriteToDB("Reading", l);
            }
            return l;
        }
    }
}
