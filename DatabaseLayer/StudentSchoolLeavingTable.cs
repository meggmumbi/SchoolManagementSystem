//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class StudentSchoolLeavingTable
    {
        public int SchoolLeavingID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> SudentID { get; set; }
        public Nullable<int> ClassID { get; set; }
        public Nullable<System.DateTime> LeavingDate { get; set; }
        public string LeavingReason { get; set; }
        public string LeavingComments { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    
        public virtual ClassTable ClassTable { get; set; }
        public virtual StudentTable StudentTable { get; set; }
        public virtual UserTable UserTable { get; set; }
    }
}
