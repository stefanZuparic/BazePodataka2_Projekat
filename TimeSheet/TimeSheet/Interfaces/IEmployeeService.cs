using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Repository.DTOs;
using TimeSheet.Repository.Models;

namespace TimeSheet.Interfaces
{
    public interface IEmployeeService
    {
        EmployeeDTO GetByMail(string mail);

        Employee Create(EmployeeDTO employeeDTO);

        void DeleteByMale(string mail);

        void UpdateActivity(bool state, string mail);

        List<EmployeeDTO> GetAll();
    }
}
