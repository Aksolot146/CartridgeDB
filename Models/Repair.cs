using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FrontendCartridges.Models
{
    public class Repair
    {
        public int Id { get; set; }
        public int CartridgeId { get; set; }
        //public DateTime BeginDate { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Select Mechanic")]
        public int MechanicId { get; set; }
        //public int EventId { get; set; }

        //[ForeignKey("CartridgeId")]
        //public virtual Cartridge Cartridge { get; set; }

        [ForeignKey("MechanicId")]
        public virtual Mechanic Mechanic { get; set; }

        [JsonIgnore]
        //[ForeignKey("EventId")]
        public virtual Event Event { get; set; }
    }
}
