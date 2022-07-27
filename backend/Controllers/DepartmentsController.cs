using BackendCartridges.Models;
using BackendCartridges.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;

namespace BackendCartridges.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentsController
    {
        DepartmentService _departmentService;

        public DepartmentsController(DepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public IEnumerable<Department> Get()
        {
            return _departmentService.GetDepartments();
        }

        [HttpGet("{id}")]
        public Department Get(int id)
        {
            return _departmentService.GetDepartment(id);
        }

        [HttpPost]
        public int Post(Department department)
        {
            _departmentService.AddDepartment(department);
            return department.Id;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _departmentService.RemoveDepartment(id);
        }

        [HttpPut]
        public void Put(Department department)
        {
            _departmentService.UpdateDepartment(department);
        }
    }
}
