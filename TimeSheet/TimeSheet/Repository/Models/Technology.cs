using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TimeSheet.Repository.Models
{
    public partial class Technology
    {
        public Technology()
        {
            EmployeeTechnology = new HashSet<EmployeeTechnology>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(20)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Description { get; set; }

        [InverseProperty("Technology")]
        public virtual ICollection<EmployeeTechnology> EmployeeTechnology { get; set; }
    }
}
