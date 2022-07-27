using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BackendCartridges.Models
{
    public class Repair
    {
        public int Id { get; set; }
        public int MechanicId { get; set; }

        [NotMapped]
        public int CartridgeId { get; set; }

        [ForeignKey("MechanicId")]
        public virtual Mechanic Mechanic { get; set; }

        [JsonIgnore]
        public virtual Event Event { get; set; }
    }
}
