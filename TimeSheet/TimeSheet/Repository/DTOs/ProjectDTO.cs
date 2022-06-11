using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Repository.Models;

namespace TimeSheet.Repository.DTOs
{
    public class ProjectDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string IsActive { get; set; }
        public int? ClinetId { get; set; }
        public virtual Client Clinet { get; set; }
        public virtual ICollection<Leadership> Leadership { get; set; }
        public virtual ICollection<TimeSheetEntry> TimeSheetEntry { get; set; }
    }
}
