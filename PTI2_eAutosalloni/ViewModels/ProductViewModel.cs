using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PTI2_eAutosalloni.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Model { get; set; }
    }
}
