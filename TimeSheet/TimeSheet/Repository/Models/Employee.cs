using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TimeSheet.Repository.Models
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeTechnology = new HashSet<EmployeeTechnology>();
            Leadership = new HashSet<Leadership>();
            TimeSheetEntry = new HashSet<TimeSheetEntry>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Address { get; set; }
        public int? Phone { get; set; }
        [StringLength(50)]
        public string Role { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
        public double? HoursPerWeek { get; set; }
        public double? MoneyPerHouse { get; set; }
        public int? IsActive { get; set; }

        [InverseProperty("Employee")]
        public virtual ICollection<EmployeeTechnology> EmployeeTechnology { get; set; }
        [InverseProperty("Employee")]
        public virtual ICollection<Leadership> Leadership { get; set; }
        [InverseProperty("Employee")]
        public virtual ICollection<TimeSheetEntry> TimeSheetEntry { get; set; }
    }
}
