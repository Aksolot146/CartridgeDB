using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendCartridges.Models;

namespace BackendCartridges.Services
{
    public class RepairService
    {
        private readonly ApplicationContext _context;
        private readonly EventService _eventService;

        public RepairService(ApplicationContext context, EventService eventService)
        {
            _context = context;
            _eventService = eventService;
        }

        public IEnumerable<Repair> GetRepairs()
        {
            return _context.Repairs.ToList();
        }

        public Repair GetRepair(int id)
        {
            return _context.Repairs.FirstOrDefault(x => x.Id == id);
        }

        public void AddRepair(Repair repair)
        {
            AddRepair(repair, 1);
        }

        public void WriteOff(Repair repair)
        {
            AddRepair(repair, 4);
        }

        private void AddRepair(Repair repair, int statusId)
        {
            if (repair.MechanicId == 0)
            {
                repair.MechanicId = 1;
            }

            _context.Repairs.Add(repair);

            _context.SaveChanges();

            Event evt = new();
            evt.CartridgeId = repair.CartridgeId;
            evt.StatusId = statusId;
            evt.RepairId = repair.Id;

            _eventService.AddEvent(evt);
        }

        public void RemoveRepair(Repair repair)
        {
            _context.Repairs.Remove(repair);
            _context.SaveChanges();
        }

        public void UpdateRepair(Repair repair)
        {
            _context.Repairs.Update(repair);
            _context.SaveChanges();
        }
    }
}
