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

    public partial class StudentTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StudentTable()
        {
            this.AttendanceTables = new HashSet<AttendanceTable>();
            this.ExamMarksTables = new HashSet<ExamMarksTable>();
            this.FeeSubmissionTables = new HashSet<FeeSubmissionTable>();
            this.StudentAttendanceTables = new HashSet<StudentAttendanceTable>();
            this.StudentPromoteTables = new HashSet<StudentPromoteTable>();
            this.StudentSchoolLeavingTables = new HashSet<StudentSchoolLeavingTable>();
        }
    
        public int StudentID { get; set; }
        public int SessionID { get; set; }
        public int ProgramID { get; set; }
        public int ClassID { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime DateofBirth { get; set; }
        public string Gender { get; set; }
        public string ContactNo { get; set; }
        public string CNIC { get; set; }
        public string FNIC { get; set; }
        public string Photo { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime AdmissionDate { get; set; }
        public string PreviousSchool { get; set; }
        public Nullable<double> PreviousPercentage { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string Nationality { get; set; }
        public string Religion { get; set; }
        public string TribeorCaste { get; set; }
        public string FatherGuardiansOccupation { get; set; }
        public string FatherGuardianPostalAddress { get; set; }
        public string PhoneOffice { get; set; }
        public string PhoneResident { get; set; }
        public bool IsEnrolled { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime ApplyDate { get; set; }
        public bool IsShortList { get; set; }
        public bool IsApply { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AttendanceTable> AttendanceTables { get; set; }
        public virtual ClassTable ClassTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExamMarksTable> ExamMarksTables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FeeSubmissionTable> FeeSubmissionTables { get; set; }
        public virtual ProgramTable ProgramTable { get; set; }
        public virtual SessionTable SessionTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentAttendanceTable> StudentAttendanceTables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentPromoteTable> StudentPromoteTables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentSchoolLeavingTable> StudentSchoolLeavingTables { get; set; }
        public virtual UserTable UserTable { get; set; }
    }
}
