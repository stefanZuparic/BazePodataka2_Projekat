using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Repository.DTOs;

namespace TimeSheet.Interfaces
{
    public interface ITimeSheet
    {
        List<TimeSheetEntryDTO> GetAll();
       
        List<TimeSheetEntryDTO> GetForDate(string date);

        void Create(TimeSheetEntryDTO dto);

    }
}
