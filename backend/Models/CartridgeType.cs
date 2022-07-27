using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BackendCartridges.Models
{
    [Table("CartridgeTypes")]
    public class CartridgeType
    {
        public int Id { get; set; }
        public string Vender { get; set; }
        public string Model { get; set; }
        public string PartNumber { get; set; }
        
        [JsonIgnore]
        public virtual IEnumerable<Cartridge> Cartridges { get; set; } = new List<Cartridge>();
    }
}
