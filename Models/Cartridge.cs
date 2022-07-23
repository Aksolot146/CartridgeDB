using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FrontendCartridges.Models
{
    [Table("Cartridges")]
    public class Cartridge
    {
        public int Id { get; set; }

        //[Required]
        [Range(1, int.MaxValue, ErrorMessage = "Select a cartridge type")]
        public int TypeId { get; set; }

        [Required]
        public int Barcode { get; set; }

        public string FullName
        {
            get
            {
                return $"{Type?.FullName}";
            }
        }

        //public int EventsID { get; set; }
        //[JsonIgnore]
        public virtual IEnumerable<Event> Events { get; set; } = new List<Event>();

        //public int RepairsID { get; set; }
        //[JsonIgnore]
        //public virtual IEnumerable<Repair> Repairs { get; set; } = new List<Repair>();

        [ForeignKey("TypeId")]
        public virtual CartridgeType Type { get; set; }

        [JsonIgnore]
        [Range(typeof(bool), "true", "true", ErrorMessage = "This barcode already exists")]
        public bool IsUniqueBarcode { get; set; }
    }
}
