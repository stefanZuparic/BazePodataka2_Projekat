using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Repository.Models;
using TimeSheet.Repository.DTOs;


namespace TimeSheet.Maper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<Client, ClientDTO>().ReverseMap();
            CreateMap<BranchOffice, BranchOfficeDTO>().ReverseMap();
            CreateMap<EmployeeTechnology, EmployeeTechnologyDTO>().ReverseMap();
            CreateMap<Leadership, LeadershipDTO>().ReverseMap();
            CreateMap<Project, ProjectDTO>().ReverseMap();
            CreateMap<PublichHoliday, PublicHolidayDTO>().ReverseMap();
            CreateMap<Technology, TechnologyDTO>().ReverseMap();
            CreateMap<TimeSheetEntry, TimeSheetEntryDTO>().ReverseMap();
        }
    }
}
