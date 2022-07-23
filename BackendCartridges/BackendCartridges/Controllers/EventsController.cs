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
    public class EventsController
    {
        EventService _eventService;

        public EventsController(EventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return _eventService.GetEvents();
        }

        [HttpGet("{id}")]
        public Event Get(int id)
        {
            return _eventService.GetEvent(id);
        }

        [HttpPost]
        public int Add(Event evt)
        {
            _eventService.AddEvent(evt);
            return evt.Id;
        }

        [HttpDelete]
        public void Remove(Event evt)
        {
            _eventService.RemoveEvent(evt);
        }

        [HttpPut]
        public void Update(Event evt)
        {
            _eventService.UpdateEvent(evt);
        } 
    } 
}
