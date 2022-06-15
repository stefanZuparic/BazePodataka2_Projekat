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
            TimeSheetEntry ret = _mapper.Map<TimeSheetEntry>(dto);

            _context.TimeSheetEntry.Add(ret);
            _context.SaveChanges();
        }

        public List<TimeSheetEntryDTO> GetAll()
        {
            List<TimeSheetEntry> ret = _context.TimeSheetEntry.Include("BranchOffice").Include("Employee").Include("Project").AsNoTracking().ToList();

            return _mapper.Map<List<TimeSheetEntryDTO>>(ret);
        }

        public List<TimeSheetEntryDTO> GetForDate(string date)
        {
            List<TimeSheetEntry> ret = _context.TimeSheetEntry.Where( p => p.Date.ToString() == date).Include("Employee").Include("Project").Include("BranchOffice").AsNoTracking().ToList();

            return _mapper.Map<List<TimeSheetEntryDTO>>(ret);
        }

        public void DeleteById(int id) {
            TimeSheetEntry ret = _context.TimeSheetEntry.Find(id);

            _context.TimeSheetEntry.Remove(ret);
            _context.SaveChanges();
        }

        public double GetHoursForDate(string date, int id) {
            List<TimeSheetEntry> pom = _context.TimeSheetEntry.Where(p => p.Date.ToString() == date && p.EmployeeId == id).Include("Employee").Include("Project").Include("BranchOffice").AsNoTracking().ToList();
            double ret = 0;

            foreach (TimeSheetEntry p in pom) {
                ret += (double)p.Hours;
            }


            return ret;
        }

        public List<TimeSheetEntryDTO> GetAllEntryForProjectId(int id)
        {
            List<TimeSheetEntry> ret = _context.TimeSheetEntry.Where(p => p.ProjectId == id).Include("Employee").Include("Project").Include("BranchOffice").AsNoTracking().ToList();

            return _mapper.Map<List<TimeSheetEntryDTO>>(ret);
        }

        public List<TimeSheetEntryDTO> GetSalaryEmployee(int id)
        {
            List<TimeSheetEntry> ret = _context.TimeSheetEntry.Where(p => p.EmployeeId == id).Include("Employee").Include("Project").Include("BranchOffice").AsNoTracking().ToList();

            return _mapper.Map<List<TimeSheetEntryDTO>>(ret);
        }
    }
}
