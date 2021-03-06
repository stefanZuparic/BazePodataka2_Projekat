using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Repository.Models;

namespace TimeSheet.Repository.DTOs
{
    public class LeadershipDTO
    {
        public int Id { get; set; }
        public int? ProjectId { get; set; }
        public int? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Project Project { get; set; }
    }
}
