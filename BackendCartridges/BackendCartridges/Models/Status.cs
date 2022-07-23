using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BackendCartridges.Models
{
    [Table("Statuses")]
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public virtual IEnumerable<Event> Events { get; set; } = new List<Event>();
    }
}
