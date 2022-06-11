using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Repository.DTOs;

namespace TimeSheet.Interfaces
{
    public interface IEmployeeService
    {
        EmployeeDTO GetByMail(string mail);

        void Create(EmployeeDTO employeeDTO);

        void DeleteByMale(string mail);

        void UpdateActivity(bool state, string mail);

        List<EmployeeDTO> GetAll();
    }
}
