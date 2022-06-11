using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Repository.Models;

namespace TimeSheet.Repository.DTOs
{
    public class TimeSheetEntryDTO
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public int BranchOfficeId { get; set; }
        public string Description { get; set; }
        public double? Hours { get; set; }
        public DateTime Date { get; set; }
        public string OwertimeType { get; set; }
        public virtual BranchOffice BranchOffice { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Project Project { get; set; }
    }
}
