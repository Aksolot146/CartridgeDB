using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BackendCartridges.Models
{
    [Table("Mechanics")]
    public class Mechanic
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        [JsonIgnore]
        public virtual IEnumerable<Repair> Repairs { get; set; } = new List<Repair>();
    }
}
