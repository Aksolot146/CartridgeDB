using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BackendCartridges.Models
{
    [Table("Departments")]
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public virtual IEnumerable<Event> FromEvents { get; set; } = new List<Event>();

        [JsonIgnore]
        public virtual IEnumerable<Event> ToEvents { get; set; } = new List<Event>();

        [JsonIgnore]
        public virtual IEnumerable<Employee> Employees { get; set; } = new List<Employee>();
    }
}
