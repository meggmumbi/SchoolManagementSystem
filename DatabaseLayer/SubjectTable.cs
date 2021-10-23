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

    public partial class SubjectTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SubjectTable()
        {
            this.SessionProgrameSubjectSettingTables = new HashSet<SessionProgrameSubjectSettingTable>();
        }
    
        public int SubjectID { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime RegDate { get; set; }
        public string Description { get; set; }
        public int TotalMarks { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SessionProgrameSubjectSettingTable> SessionProgrameSubjectSettingTables { get; set; }
        public virtual UserTable UserTable { get; set; }
    }
}
