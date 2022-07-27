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
    public class RepairsController
    {
        RepairService _repairService;

        public RepairsController(RepairService repairService)
        {
            _repairService = repairService;
        }

        [HttpGet]
        public IEnumerable<Repair> Get()
        {
            return _repairService.GetRepairs();
        }

        [HttpGet("{id}")]
        public Repair Get(int id)
        {
            return _repairService.GetRepair(id);
        }

        [HttpPost]
        public int Add(Repair repair)
        {
            _repairService.AddRepair(repair);
            return repair.Id;
        }

        [HttpDelete]
        public void Remove(Repair repair)
        {
            _repairService.RemoveRepair(repair);
        }

        [HttpPut]
        public void Update(Repair repair)
        {
            _repairService.UpdateRepair(repair);
        }

        [HttpPost("writeoff")]
        public void WriteOff(Repair repair)
        {
            _repairService.WriteOff(repair);
        }
    }
}
