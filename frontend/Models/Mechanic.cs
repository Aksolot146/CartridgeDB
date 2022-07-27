using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FrontendCartridges.Models
{
    [Table("Mechanics")]
    public class Mechanic
    {
        public int Id { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "Mechanic last name too long (32 character limit)")]
        public string LastName { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "Mechanic last name too long (32 character limit)")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "Mechanic last name too long (32 character limit)")]
        public string MiddleName { get; set; }

        public string FullName
        {
            get
            {
                return $"{LastName}, {FirstName} {MiddleName}";
            }
        }

        //public int RepairsID { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<Repair> Repairs { get; set; } = new List<Repair>();
    }
}
