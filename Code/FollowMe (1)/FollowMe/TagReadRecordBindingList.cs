using System;
using System;
using System.Collections.Generic;
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
using System.Data.SqlClient;
namespace FollowMe
{
    public class TagReadRecordBindingList
    {
        //protected override Comparison<TagReadRecord> GetComparer(PropertyDescriptor prop)
        //{
        //    Comparison<TagReadRecord> comparer = null;
        //    switch (prop.Name)
        //    {
        //        case "ReadCount":
        //            comparer = new Comparison<TagReadRecord>(delegate(TagReadRecord a, TagReadRecord b)
        //            {
        //                return a.ReadCount - b.ReadCount;
        //            });
        //            break;
        //        case "Antenna":
        //            comparer = new Comparison<TagReadRecord>(delegate(TagReadRecord a, TagReadRecord b)
        //            {
        //                return a.Antenna - b.Antenna;
        //            });
        //            break;
        //        case "EPC":
        //            comparer = new Comparison<TagReadRecord>(delegate(TagReadRecord a, TagReadRecord b)
        //            {
        //                return String.Compare(a.EPC, b.EPC);
        //            });
        //            break;
        //    }
        //    return comparer;
        //}
    }
}
