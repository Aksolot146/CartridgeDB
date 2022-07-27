using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendCartridges.Models;

namespace BackendCartridges.Services
{
    public class MechanicService
    {
        private readonly ApplicationContext _context;

        public MechanicService(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Mechanic> GetMechanics()
        {
            return _context.Mechanics.ToList();
        }

        public Mechanic GetMechanic(int id)
        {
            return _context.Mechanics.FirstOrDefault(x => x.Id == id);
        }

        public void AddMechanic(Mechanic mechanic)
        {
            _context.Mechanics.Add(mechanic);
            _context.SaveChanges();
        }

        public void DeleteMechanic(int id)
        {
            Mechanic mechanic = GetMechanic(id);
            _context.Mechanics.Remove(mechanic);
            _context.SaveChanges();
        }

        public void UpdateMechanic(Mechanic mechanic)
        {
            _context.Mechanics.Update(mechanic);
            _context.SaveChanges();
        }
    }
}
