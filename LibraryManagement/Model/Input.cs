//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryManagement.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Input
    {
        public string ID { get; set; }
        public Nullable<System.DateTime> DateInput { get; set; }
        public string IDObjects { get; set; }
        public Nullable<int> Count { get; set; }
        public Nullable<double> InputPrice { get; set; }
        public Nullable<double> OutputPrice { get; set; }
        public string Status { get; set; }
    
        public virtual Object Object { get; set; }
    }
}
