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
    public class ProjectService : IProjectService
    {
        private IMapper _mapper;
        private TimeSheetEntryDbContext _context;

        public ProjectService(IMapper mapper, TimeSheetEntryDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Project Create(ProjectDTO projectDTO)
        {
            Project project = _mapper.Map<Project>(projectDTO);

            _context.Project.Add(project);
            _context.SaveChanges();
            return project;
        }

        public void DeleteById(int id)
        {
            Project project = _context.Project.Find(id);

            if (project != null)
            {
                _context.Project.Remove(project);
                _context.SaveChanges();
            }
        }

        public List<ProjectDTO> GetAll()
        {
            List<Project> projects = _context.Project.Include("Clinet").AsNoTracking().Include(l => l.Leadership).ThenInclude(Leadership => Leadership.Employee).AsNoTracking().Include("TimeSheetEntry").AsNoTracking().ToList();

            return _mapper.Map<List<ProjectDTO>>(projects);
        }


        public List<Project> GetByClientId(int clientId)
        {
            List<Project> projects = _context.Project.Where( p => p.ClinetId == clientId).ToList();

            return projects;
        }

        public ProjectDTO GetById(int id)
        {
            Project project = _context.Project.Find(id);

            return _mapper.Map<ProjectDTO>(project);
        }

        public void UpdateActivity(bool state, int id)
        {
            Project project = _context.Project.Find(id);

            project.IsActive = state == true ? "YES" : "NO";

            _context.SaveChanges();
        }
    }
}
