using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PTI2_eAutosalloni.Data;
using PTI2_eAutosalloni.Interfaces.Services;
using PTI2_eAutosalloni.Models;
using PTI2_eAutosalloni.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PTI2_eAutosalloni.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VehicleController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IVehicleService _vehicleService;
        private readonly ICategoryService categoryService;
        private readonly IBrandService _brandService;
        private readonly IVehicleImageService _vehicleImageService;
        private readonly IMapper _mapper;


        public VehicleController(ApplicationDbContext context, IMapper mapper, IBrandService brandService, IVehicleService productService, ICategoryService categoryService, IVehicleImageService productImageService)
        {
            this.context = context;
            _mapper = mapper;
            _brandService = brandService;
            _vehicleService = productService;
            this.categoryService = categoryService;
            _vehicleImageService = productImageService;
        }
        public async Task<IActionResult> Index()
        {
            List<Vehicle> products = await _vehicleService.FindAll();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            List<SelectListItem> selectListItems = await categoryService.SelectListItems();
            ViewBag.Categories = selectListItems;
            List<SelectListItem> selectListItems2 = await _brandService.SelectListItems();
            ViewBag.Brands = selectListItems2;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(VehicleViewModel model1)
        {
            if (ModelState.IsValid)
            {
                var product = await _vehicleService.Create(model1);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model1);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(int Id)
        {
            List<SelectListItem> selectListItems = await categoryService.SelectListItems();
            ViewBag.Categories = selectListItems;
            List<SelectListItem> selectListItems2 = await _brandService.SelectListItems();
            ViewBag.Brands = selectListItems2;

            Vehicle product = await _vehicleService.FindById(Id);

            if(product != null)
            {
                VehicleViewModel model = _mapper.Map<VehicleViewModel>(product);
                return View(model);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(VehicleViewModel model1)
        {
            if (ModelState.IsValid)
            {
                var result = await _vehicleService.Update(model1);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model1);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int Id)
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

        public async Task<IActionResult> Delete(int Id)
        {
            var result = await _vehicleService.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}
