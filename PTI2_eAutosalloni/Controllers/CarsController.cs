using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PTI2_eAutosalloni.Data;
using PTI2_eAutosalloni.Interfaces.Services;
using PTI2_eAutosalloni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTI2_eAutosalloni.Controllers
{
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IVehicleService _vehicleService;


        public CarsController(ApplicationDbContext context, IVehicleService vehicleService)
        {
            _context = context;
            _vehicleService = vehicleService;
        }

        public async Task<IActionResult> Index()
        {
            List<Vehicle> products = await _vehicleService.FindAll();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Index(string search, string price, string category, string brand,string engine)
        {
            ViewData["Emertimi"] = new SelectList(_context.Vehicles, "Model", "Model");
            ViewData["Cmimi"] = new SelectList(_context.Vehicles, "Price", "Price");
            ViewData["Kategoria"] = new SelectList(_context.Categories, "Name", "Name");
            ViewData["Brandi"] = new SelectList(_context.Brands, "Name", "Name");
            ViewData["Motorri"] = new SelectList(_context.Vehicles, "Engine", "Engine");


            ViewData["GetPunetor"] = search;

            var punetor = from x in _context.Vehicles select x;
            punetor = _context.Vehicles.Include(p => p.Category).Include(p => p.Brand);

            if (!String.IsNullOrEmpty(search) || !String.IsNullOrEmpty(price) || !String.IsNullOrEmpty(category) || !String.IsNullOrEmpty(brand) || !String.IsNullOrEmpty(engine)) 
            {
                if(!String.IsNullOrEmpty(search))
                {
                    punetor = punetor.Where(x => x.Model.Contains(search));
                }
                if (!String.IsNullOrEmpty(price))
                {
                    punetor = punetor.Where(x => x.Price.ToString().Contains(price));

                }
                if (!String.IsNullOrEmpty(category))
                {
                    punetor = punetor.Where(x => x.Category.Name.Contains(category));

                }
                if (!String.IsNullOrEmpty(brand))
                {
                    punetor = punetor.Where(x => x.Brand.Name.Contains(brand));

                }
                if (!String.IsNullOrEmpty(engine))
                {
                    punetor = punetor.Where(x => x.Engine.Contains(engine));

                }
            }

            return View(await punetor.AsNoTracking().ToListAsync());
        }

    }
}
