using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FrontendCartridges.Models
{
    [Table("Events")]
    public class Event
    {
        public int Id { get; set; }
        public int CartridgeId { get; set; }
        public DateTime EventDate { get; set; }
        public int StatusId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Select Employee")]
        public int EmployeeId { get; set; }

        public int FromDepartmentId { get; set; }
        public int ToDepartmentId { get; set; }
        public int? RepairId { get; set; }

        [ForeignKey("CartridgeId")]
        public virtual Cartridge Cartridge { get; set; }

        [ForeignKey("StatusId")]
        public virtual Status Status { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        [ForeignKey("FromDepartmentId")]
        public virtual Department FromDepartment { get; set; }

        [ForeignKey("ToDepartmentId")]
        public virtual Department ToDepartment { get; set; }

        //[JsonIgnore]
        [ForeignKey("RepairId")]
        public virtual Repair Repair { get; set; }

    }
}
