using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendCartridges.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendCartridges.Services
{
    public class DepartmentService
    {
        private readonly ApplicationContext _context;

        public DepartmentService(ApplicationContext context) 
        {
            _context = context;
        }

        public IEnumerable<Department> GetDepartments() 
        {
            return _context.Departments.ToList();
        }

        public Department GetDepartment(int id)
        {
            return _context.Departments.FirstOrDefault(x => x.Id == id);
        }

        public void AddDepartment(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }

        public void RemoveDepartment(int id)
        {
            Department department = GetDepartment(id);
            _context.Departments.Remove(department);
            _context.SaveChanges();
        }

        public void UpdateDepartment(Department department)
        {
            _context.Departments.Update(department);
            _context.SaveChanges();
        }
    }
}
