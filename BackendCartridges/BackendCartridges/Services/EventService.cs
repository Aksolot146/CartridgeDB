﻿using System;
using System.Collections.Generic;
using System.Linq;
using BackendCartridges.Models;

namespace BackendCartridges.Services
{
    public class EventService
    {
        private readonly ApplicationContext _context;

        public EventService(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Event> GetEvents()
        {
            return _context.Events.ToList();
        }

        public Event GetEvent(int id)
        {
            return _context.Events.FirstOrDefault(x => x.Id == id);
        }

        public void AddEvent(Event evt)
        {
            evt.EventDate = DateTime.Now;

            if (evt.EmployeeId == 0)
            {
                evt.EmployeeId = 1;
            }

            if (evt.FromDepartmentId == 0)
            {
                evt.FromDepartmentId = 1;
            }

            if (evt.ToDepartmentId == 0)
            {
                evt.ToDepartmentId = 1;
            }

            _context.Events.Add(evt);
            _context.SaveChanges();
        }

        public void RemoveEvent(Event evt)
        {
            _context.Events.Remove(evt);
            _context.SaveChanges();
        }

        public void UpdateEvent(Event evt)
        {
            _context.Events.Update(evt);
            _context.SaveChanges();
        }
    }
}
