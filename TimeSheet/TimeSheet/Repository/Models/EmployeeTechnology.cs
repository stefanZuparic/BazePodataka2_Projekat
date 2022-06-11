using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TimeSheet.Repository.Models
{
    public partial class EmployeeTechnology
    {
        [Key]
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? TechnologyId { get; set; }
        [StringLength(20)]
        public string LevelOfExperience { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty("EmployeeTechnology")]
        public virtual Employee Employee { get; set; }
        [ForeignKey(nameof(TechnologyId))]
        [InverseProperty("EmployeeTechnology")]
        public virtual Technology Technology { get; set; }
    }
}
