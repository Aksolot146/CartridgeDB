using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendCartridges.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendCartridges.Services
{
    public class EmployeeService
    {
        private readonly ApplicationContext _context;

        public EmployeeService(ApplicationContext context)
        {
            _context = context; 
        }

        public IEnumerable<Employee> GetEmployees()
        {
            _context.Departments.Load();
            return _context.Employees.ToList();
        }

        public Employee GetEmployee(int id)
        {
            return _context.Employees.FirstOrDefault(x => x.Id == id);
        }

        public void AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            Employee employee = GetEmployee(id);
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }

        public void UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee); 
            _context.SaveChanges();
        }
    }
}
