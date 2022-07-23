using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendCartridges.Models;

namespace BackendCartridges.Services
{
    public class CartridgeTypeService
    {
        private readonly ApplicationContext _context;

        public CartridgeTypeService(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<CartridgeType> GetCartridgeTypes()
        {
            return _context.CartridgeTypes.ToList();
        }

        public CartridgeType GetCartridgeType(int id)
        {
            return _context.CartridgeTypes.FirstOrDefault(x => x.Id == id);
        }

        public void AddCartridgeType(CartridgeType cartridgeType)
        {
            _context.CartridgeTypes.Add(cartridgeType);
            _context.SaveChanges();
        }

        public void DeleteCartridgeType(int id)
        {
            CartridgeType cartridgeType = GetCartridgeType(id);
            _context.CartridgeTypes.Remove(cartridgeType);
            _context.SaveChanges();
        }

        public void UpdateCartridgeType(CartridgeType cartridgeType)
        {
            _context.CartridgeTypes.Update(cartridgeType);
            _context.SaveChanges();
        }
    }
}
