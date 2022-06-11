using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Repository.DTOs
{
    class EmployeeTechnologyDTO
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int TechnologyId { get; set; }
        public string LevelOfExperience { get; set; }
    }
}
