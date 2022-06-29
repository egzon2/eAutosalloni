using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PTI2_eAutosalloni.Models
{
    public class VehicleImage
    {
        [Key]
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public byte[] VehicleImg { get; set; }
    }
}
