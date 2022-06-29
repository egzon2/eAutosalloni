using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PTI2_eAutosalloni.Data;
using PTI2_eAutosalloni.Interfaces.Services;
using PTI2_eAutosalloni.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PTI2_eAutosalloni.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IVehicleService _vehicleService;
        private readonly ApplicationDbContext _context;
        private readonly IVehicleImageService _vehicleImageService;
        public HomeController(ILogger<HomeController> logger, IVehicleService productService, ApplicationDbContext context, IVehicleImageService vehicleImageService)
        {
            _logger = logger;
            _vehicleService = productService;
            _context = context;
            _vehicleImageService = vehicleImageService;
        }

        public async Task<IActionResult> Index()
        {
            List<Vehicle> productList = await _vehicleService.FindAll();
            ViewData["Recently"] = productList.OrderByDescending(x => x.Year).Take(6).ToList();
            ViewBag.VehicleImages = await _vehicleImageService.FindAll(1);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> IndexDetails(int Id)
        {
            Vehicle product = await _vehicleService.FindById(Id);
            if (product != null)
            {
                ViewBag.VehicleImages = await _vehicleImageService.FindAll(Id);
                return View(product);
            }
            else
            {
                return NotFound();
            }

        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
