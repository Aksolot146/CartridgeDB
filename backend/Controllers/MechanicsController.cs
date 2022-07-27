using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BackendCartridges.Models;
using BackendCartridges.Services;

namespace BackendCartridges.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MechanicsController
    {
        MechanicService _mechanicService;

        public MechanicsController(MechanicService mechanicService)
        {
            _mechanicService = mechanicService;
        }

        [HttpGet]
        public IEnumerable<Mechanic> Get()
        {
            return _mechanicService.GetMechanics();
        }

        [HttpGet("{id}")]
        public Mechanic Get(int id)
        {
            return _mechanicService.GetMechanic(id);
        }

        [HttpPost]
        public int Add(Mechanic mechanic)
        {
            _mechanicService.AddMechanic(mechanic);
            return mechanic.Id;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _mechanicService.DeleteMechanic(id);
        }

        [HttpPut]
        public void Update(Mechanic department)
        {
            _mechanicService.UpdateMechanic(department);
        }
    }
}
