//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Efrat.Dal
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reading
    {
        public int ReadingId { get; set; }
        public Nullable<int> Antena { get; set; }
        public string EPC { get; set; }
        public Nullable<int> REderId { get; set; }
        public Nullable<System.DateTime> Time { get; set; }
    }
}
