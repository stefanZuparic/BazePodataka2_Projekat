using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TimeSheet.Repository.Models
{
    public partial class TimeSheetEntry
    {
        [Key]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int? ProjectId { get; set; }
        public int? BranchOfficeId { get; set; }
        [StringLength(150)]
        public string Description { get; set; }
        public double? Hours { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }
        [StringLength(10)]
        public string OwertimeType { get; set; }

        [ForeignKey(nameof(BranchOfficeId))]
        [InverseProperty("TimeSheetEntry")]
        public virtual BranchOffice BranchOffice { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty("TimeSheetEntry")]
        public virtual Employee Employee { get; set; }
        [ForeignKey(nameof(ProjectId))]
        [InverseProperty("TimeSheetEntry")]
        public virtual Project Project { get; set; }
    }
}
