//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HF_super_mart.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Supplier
    {
        public int Supplier_Id { get; set; }
        public Nullable<int> Store_Id { get; set; }
        public string Phone_Number { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    
        public virtual Store Store { get; set; }
    }
}
