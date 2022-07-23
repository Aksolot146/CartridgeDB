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
    public class StatusesController
    {
        StatusService _statusService;

        public StatusesController(StatusService statusService)
        {
            _statusService = statusService;
        }

        [HttpGet]
        public IEnumerable<Status> Get()
        {
            return _statusService.GetStatuses();
        }

        [HttpGet("{id}")]
        public Status Get(int id)
        {
            return _statusService.GetStatus(id);
        }
    }
}