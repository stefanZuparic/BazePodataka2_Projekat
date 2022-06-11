using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Repository.Models;

namespace TimeSheet.Repository.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public double HoursPerWeek { get; set; }
        public double MoneyPerHouse { get; set; }
        public int IsActive { get; set; }
        public virtual ICollection<EmployeeTechnology> EmployeeTechnology { get; set; }
        public virtual ICollection<Leadership> Leadership { get; set; }
        public virtual ICollection<TimeSheetEntry> TimeSheetEntry { get; set; }
    }
}
