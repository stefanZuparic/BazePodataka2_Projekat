using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Repository.Models;

namespace TimeSheet.Repository.DTOs
{
    public class BranchOfficeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual ICollection<TimeSheetEntry> TimeSheetEntry { get; set; }

    }
}
