using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FrontendCartridges.Models
{
    [Table("CartridgeTypes")]
    public class CartridgeType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "Employee last name too long (32 character limit)")]
        public string Vender { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "Employee last name too long (32 character limit)")]
        public string Model { get; set; }

        [Required]
        [StringLength(128, ErrorMessage = "Employee last name too long (32 character limit)")]
        public string PartNumber { get; set; }

        public string FullName
        {
            get
            {
                return $"{Vender} {Model} {PartNumber}";
            }
        }

        [JsonIgnore]
        public virtual IEnumerable<Cartridge> Cartridges { get; set; } = new List<Cartridge>();
    }
}
