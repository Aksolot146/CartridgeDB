using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BackendCartridges.Models
{
    [Table("Cartridges")]
    public class Cartridge
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public int Barcode { get; set; }

        public virtual IEnumerable<Event> Events { get; set; } = new List<Event>();

        [ForeignKey("TypeId")]
        public virtual CartridgeType Type { get; set; }
    }
}
