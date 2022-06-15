using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Repository;
using TimeSheet.Repository.DTOs;
using TimeSheet.Repository.Models;

namespace TimeSheet.Service
{
    class TechnologyService
    {
        private IMapper _mapper;
        private TimeSheetEntryDbContext _context;

        public TechnologyService(IMapper mapper, TimeSheetEntryDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public void Create(EmployeeTechnologyDTO dto) {
            EmployeeTechnology et = _mapper.Map<EmployeeTechnology>(dto);

            _context.EmployeeTechnology.Add(et);
            _context.SaveChanges();
        }

        public void CreateLeaders(LeadershipDTO dto) {
            Leadership l = _mapper.Map<Leadership>(dto);

            _context.Leadership.Add(l);
            _context.SaveChanges();
        }

        public List<BranchOfficeDTO> GetAllOffice() {
            List<BranchOffice> ret = _context.BranchOffice.Include("TimeSheetEntry").ToList();

            return _mapper.Map<List<BranchOfficeDTO>>(ret);
        }

        public List<Technology> GetAll()
        {
            List<Technology> tech = _context.Technology.Include("EmployeeTechnology").AsNoTracking().ToList();

            return tech;
        }
    }
}
