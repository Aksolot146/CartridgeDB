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
    public class CartridgesController
    {
        CartridgeService _cartridgeService;

        public CartridgesController(CartridgeService cartridgeService)
        {
            _cartridgeService = cartridgeService;
        }

        [HttpGet]
        public IEnumerable<Cartridge> Get()
        {
            return _cartridgeService.GetCartridges();
        }

        [HttpGet("{id}")]
        public Cartridge Get(int id)
        {
            return _cartridgeService.GetCartridge(id);
        }

        [HttpPost]
        public int Add(Cartridge cartridge)
        {
            _cartridgeService.AddCartridge(cartridge);
            return cartridge.Id;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _cartridgeService.DeleteCartridge(id);
        }

        [HttpPut]
        public void Update(Cartridge cartridge)
        {
            _cartridgeService.UpdateCartridge(cartridge);
        }

        [HttpGet("checkUniquebarcode/{barcode}")]
        public bool CheckUniqueBarcode(int barcode)
        {
            return _cartridgeService.CheckUniqueBarcode(barcode);
        }

        [HttpGet("statusbybarcode/{barcode}")]
        public int StatusByBarcode(int barcode)
        {
            return _cartridgeService.StatusByBarcode(barcode);
        }

        [HttpGet("bybarcode/{barcode}")]
        public Cartridge GetByBarcode(int barcode)
        {
            return _cartridgeService.GetByBarcode(barcode);
        }
    }
}
