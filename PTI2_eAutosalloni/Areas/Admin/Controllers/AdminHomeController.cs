using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTI2_eAutosalloni.Data;
using PTI2_eAutosalloni.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTI2_eAutosalloni.Areas.Admin.Controllers
{
    [Area("Admin")]
   // [Authorize(Roles = "Admin")]
    public class AdminHomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminHomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            DashboardViewModel dashboard = new DashboardViewModel();
            dashboard.vehicle_count = _context.Vehicles.Count();
            dashboard.customer_count = _context.Customers.Count();
            dashboard.category_count = _context.Categories.Count();
            return View(dashboard);
        }
    }
}
