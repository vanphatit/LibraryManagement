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
    
    public partial class Staff
    {
        public int ID { get; set; }
        public string DisplayName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int IDGender { get; set; }
        public string Zalo { get; set; }
        public Nullable<int> IDPosition { get; set; }
        public string MoreInfo { get; set; }
        public Nullable<System.DateTime> ContractDate { get; set; }
    
        public virtual Gender Gender { get; set; }
        public virtual Position Position { get; set; }
    }
}
