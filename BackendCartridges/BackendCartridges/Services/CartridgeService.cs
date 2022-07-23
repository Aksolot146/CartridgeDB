using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BackendCartridges.Models;

namespace BackendCartridges.Services
{
    public class CartridgeService
    {
        private readonly ApplicationContext _context;

        public CartridgeService(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Cartridge> GetCartridges()
        {
            _context.CartridgeTypes.Load();
            _context.Events.Load();
            _context.Departments.Load();
            _context.Statuses.Load();

            return _context.Cartridges.ToList();
        }

        public Cartridge GetCartridge(int id)
        {
            return _context.Cartridges
                .Include(x => x.Type)
                .Include(x => x.Events).ThenInclude(x => x.Repair).ThenInclude(x => x.Mechanic)
                .Include(x => x.Events).ThenInclude(x => x.Employee)
                .Include(x => x.Events).ThenInclude(x => x.FromDepartment)
                .Include(x => x.Events).ThenInclude(x => x.ToDepartment)
                .Include(x => x.Events).ThenInclude(x => x.Status)
                .FirstOrDefault(x => x.Id == id);
        }

        public void AddCartridge(Cartridge cartridge)
        {
            _context.Cartridges.Add(cartridge);
            _context.SaveChanges();

            Event evt = new Event()
            {
                CartridgeId = cartridge.Id,
                EventDate = DateTime.Now,
                StatusId = 1,
                EmployeeId = 1,
                FromDepartmentId = 1,
                ToDepartmentId = 1
            };

            _context.Events.Add(evt);
            _context.SaveChanges();
        }

        public void DeleteCartridge(int id)
        {
            Cartridge cartridge = GetCartridge(id);
            _context.Cartridges.Remove(cartridge);
            _context.SaveChanges();
        }

        public void UpdateCartridge(Cartridge cartridge)
        {
            cartridge.Type = null;
            _context.Cartridges.Update(cartridge);
            _context.SaveChanges();
        }

        public bool CheckUniqueBarcode(int barcode)
        {
            return !_context.Cartridges.Any(x => x.Barcode == barcode);
        }

        public int StatusByBarcode(int barcode)
        {
            return _context.Events.Where(x => x.Cartridge.Barcode == barcode)
                .OrderByDescending(x => x.EventDate)
                .Select(x => x.StatusId)
                .FirstOrDefault();
        }

        public Cartridge GetByBarcode(int barcode)
        {
            return _context.Cartridges.Include(x => x.Type)
                .FirstOrDefault(x => x.Barcode == barcode);
        }
    }
}
