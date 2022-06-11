using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Repository.Models;

namespace TimeSheet.Repository.DTOs
{
    class EmployeeTechnologyDTO
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int TechnologyId { get; set; }
        public string LevelOfExperience { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Technology Technology { get; set; }
    }
}
