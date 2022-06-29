using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTI2_eAutosalloni.ViewModels
{
    public class VehicleImageViewModel
    {
        public int VehicleID { get; set; }
        public List<IFormFile> Images { get; set; }
    }
}
