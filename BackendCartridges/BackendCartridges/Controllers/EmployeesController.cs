using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendCartridges.Models;
using BackendCartridges.Services;

namespace BackendCartridges.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController
    {
        EmployeeService _employeeService;

        public EmployeesController(EmployeeService employeeService) 
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _employeeService.GetEmployees();
        }

        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return _employeeService.GetEmployee(id);
        }

        [HttpPost]
        public int Add(Employee employee)
        {
            _employeeService.AddEmployee(employee);
            return employee.Id;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _employeeService.DeleteEmployee(id);
        }

        [HttpPut]
        public void Update(Employee employee)
        {
            _employeeService.UpdateEmployee(employee);
        }
    }
}
