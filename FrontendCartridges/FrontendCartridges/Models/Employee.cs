using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FrontendCartridges.Models
{
    [Table("Employees")]
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "Employee last name too long (32 character limit)")]
        public string LastName { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "Employee first name too long (32 character limit)")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "Employee middle name too long (32 character limit)")]
        public string MiddleName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Select a department")]
        public int DepartmentId { get; set; }

        public string FullName
        {
            get
            {
                return $"{LastName}, {FirstName} {MiddleName}";
            }
        }

        [JsonIgnore]
        public virtual IEnumerable<Event> Events { get; set; } = new List<Event>();

        //[JsonIgnore]
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
    }
}
