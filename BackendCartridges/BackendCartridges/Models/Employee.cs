using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BackendCartridges.Models
{
    [Table("Employees")]
    public class Employee
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public int DepartmentId { get; set; }

        [JsonIgnore]
        public virtual IEnumerable<Event> Events { get; set; } = new List<Event>();

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
    }
}
