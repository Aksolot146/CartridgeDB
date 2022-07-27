using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendCartridges.Models;
using BackendCartridges.Services;


namespace BackendCartridges.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartridgeTypesController
    {
        CartridgeTypeService _cartridgeTypeService;

        public CartridgeTypesController(CartridgeTypeService cartridgeTypeService)
        {
            _cartridgeTypeService = cartridgeTypeService;
        }

        [HttpGet]
        public IEnumerable<CartridgeType> Get()
        {
            return _cartridgeTypeService.GetCartridgeTypes();
        }

        [HttpGet("{id}")]
        public CartridgeType Get(int id)
        {
            return _cartridgeTypeService.GetCartridgeType(id);
        }

        [HttpPost]
        public int Add(CartridgeType cartridgeType)
        {
            _cartridgeTypeService.AddCartridgeType(cartridgeType);
            return cartridgeType.Id;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _cartridgeTypeService.DeleteCartridgeType(id);
        }

        [HttpPut]
        public void Update(CartridgeType cartridgeType)
        {
            _cartridgeTypeService.UpdateCartridgeType(cartridgeType);
        }
    }
}
