using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TimeSheet.Repository.Models
{
    public partial class Project
    {
        public Project()
        {
            Leadership = new HashSet<Leadership>();
            TimeSheetEntry = new HashSet<TimeSheetEntry>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(20)]
        public string Name { get; set; }
        [StringLength(150)]
        public string Description { get; set; }
        [StringLength(5)]
        public string IsActive { get; set; }
        public int? ClinetId { get; set; }

        [ForeignKey(nameof(ClinetId))]
        [InverseProperty(nameof(Client.Project))]
        public virtual Client Clinet { get; set; }
        [InverseProperty("Project")]
        public virtual ICollection<Leadership> Leadership { get; set; }
        [InverseProperty("Project")]
        public virtual ICollection<TimeSheetEntry> TimeSheetEntry { get; set; }
    }
}
