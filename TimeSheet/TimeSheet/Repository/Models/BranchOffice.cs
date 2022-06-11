using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TimeSheet.Repository.Models
{
    public partial class BranchOffice
    {
        public BranchOffice()
        {
            TimeSheetEntry = new HashSet<TimeSheetEntry>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Address { get; set; }

        [InverseProperty("BranchOffice")]
        public virtual ICollection<TimeSheetEntry> TimeSheetEntry { get; set; }
    }
}
