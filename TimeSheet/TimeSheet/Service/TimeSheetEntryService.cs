using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Interfaces;
using TimeSheet.Repository;
using TimeSheet.Repository.DTOs;
using TimeSheet.Repository.Models;

namespace TimeSheet.Service
{
    class TimeSheetEntryService : ITimeSheet
    {
        private IMapper _mapper;
        private TimeSheetEntryDbContext _context;

        public TimeSheetEntryService(IMapper mapper, TimeSheetEntryDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public void Create(TimeSheetEntryDTO dto)
        {
            throw new NotImplementedException();
        }

        public List<TimeSheetEntryDTO> GetAll()
        {
            List<TimeSheetEntry> ret = _context.TimeSheetEntry.Include("BranchOffice").Include("Employee").Include("Project").AsNoTracking().ToList();

            return _mapper.Map<List<TimeSheetEntryDTO>>(ret);
        }

        public TimeSheetEntryDTO GetForDate(string date)
        {
            TimeSheetEntry ret = _context.TimeSheetEntry.Where( p => p.Date.ToString() == date).FirstOrDefault();

            return _mapper.Map<TimeSheetEntryDTO>(ret);
        }
    }
}
