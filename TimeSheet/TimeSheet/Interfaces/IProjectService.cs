using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Repository.DTOs;
using TimeSheet.Repository.Models;

namespace TimeSheet.Interfaces
{
    public interface IProjectService
    {
        List<Project> GetByClientId(int clientId);

        ProjectDTO GetById(int id);

        Project Create(ProjectDTO projectDTO);

        void DeleteById(int id);

        void UpdateActivity(bool state, int id);

        List<ProjectDTO> GetAll();
    }
}
