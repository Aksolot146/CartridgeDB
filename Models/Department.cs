using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace FrontendCartridges.Models
{
    [Table("Departments")]
    public class Department
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(32, ErrorMessage = "Department name too long (32 character limit)")]
        public string Name { get; set; }

        [JsonIgnore]
        public virtual IEnumerable<Event> FromEvents { get; set; } = new List<Event>();

        [JsonIgnore]
        public virtual IEnumerable<Event> ToEvents { get; set; } = new List<Event>();

        [JsonIgnore]
        public virtual IEnumerable<Employee> Employees { get; set; } = new List<Employee>();
    }
}
