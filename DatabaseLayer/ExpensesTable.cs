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
    using System.ComponentModel.DataAnnotations;

    public partial class ExpensesTable
    {
        public int ExpensesID { get; set; }
        public int ExpensesTypeID { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime ExpenseDate { get; set; }
        public double Amount { get; set; }
        public string Reason { get; set; }
        public int UserID { get; set; }
    
        public virtual ExpensesTypeTable ExpensesTypeTable { get; set; }
        public virtual UserTable UserTable { get; set; }
    }
}
