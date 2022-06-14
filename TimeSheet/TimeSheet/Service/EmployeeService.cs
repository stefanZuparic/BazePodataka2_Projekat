﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Interfaces;
using TimeSheet.Maper;
using TimeSheet.Repository;
using TimeSheet.Repository.DTOs;
using TimeSheet.Repository.Models;

namespace TimeSheet.Service
{
    public class EmployeeService : IEmployeeService
    { 
        private IMapper _mapper;
        private TimeSheetEntryDbContext _context;

        public EmployeeService(IMapper mapper , TimeSheetEntryDbContext context) 
        {
            _mapper = mapper;
            _context = context;
        }

        public Employee Create(EmployeeDTO employeeDTO)
        {
            Employee employee = _mapper.Map<Employee>(employeeDTO);

            _context.Employee.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public void DeleteByMale(string mail)
        {
            Employee employee = _context.Employee.FirstOrDefault(e => e.Email == mail);

            if (employee != null) {
                _context.Employee.Remove(employee);
                _context.SaveChanges();
            }
        }

        public List<EmployeeDTO> GetAll()
        {
            List<Employee> employee = _context.Employee.Include("Leadership").Include("TimeSheetEntry").Include( p => p.EmployeeTechnology).ThenInclude(EmployeeTechnology => EmployeeTechnology.Technology).AsNoTracking().ToList();

            return _mapper.Map<List<EmployeeDTO>>(employee);
        }

        public List<Employee> GetAllEmployee()
        {
            List<Employee> employee = _context.Employee.Include("Leadership").Include("TimeSheetEntry").Include(p => p.EmployeeTechnology).ThenInclude(EmployeeTechnology => EmployeeTechnology.Technology)
                .AsNoTracking().ToList();

            return employee;
        }

        public EmployeeDTO GetById(int id)
        {
            Employee employee = _context.Employee.Find(id);

            return _mapper.Map<EmployeeDTO>(employee);
        }

        public EmployeeDTO GetByMail(string mail)
        {
            Employee employee = _context.Employee.FirstOrDefault(e => e.Email == mail);

            return _mapper.Map<EmployeeDTO>(employee);
        }

        public Employee GetByMailEmployee(string mail)
        {
            Employee employee = _context.Employee.FirstOrDefault(e => e.Email == mail);

            return employee;
        }

        public void UpdateActivity(bool state, string mail)
        {
            Employee employee = _context.Employee.FirstOrDefault(e => e.Email == mail);

            employee.IsActive = state == true ? 1 : 0;

            _context.SaveChanges();
        }
    }
}
