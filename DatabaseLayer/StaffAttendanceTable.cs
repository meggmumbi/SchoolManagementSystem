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

    public partial class StaffAttendanceTable
    {
        public int StaffAttendanceID { get; set; }
        public int StaffID { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime AttendDate { get; set; }
        [DataType(DataType.Time)]
        public System.TimeSpan AttendTime { get; set; }
        [DataType(DataType.Time)]
        public System.TimeSpan ComingTime { get; set; }
        [DataType(DataType.Time)]
        public System.TimeSpan ClosingTime { get; set; }
    
        public virtual StaffTable StaffTable { get; set; }
    }
}
