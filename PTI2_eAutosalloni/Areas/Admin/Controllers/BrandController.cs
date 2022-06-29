using Microsoft.AspNetCore.Mvc;
using PTI2_eAutosalloni.Interfaces.Services;
using PTI2_eAutosalloni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTI2_eAutosalloni.Areas.Admin.Controllers
{
    [Area("Admin")]
    // [Authorize(Roles = "Admin")]
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        public IActionResult Index()
        {
            List<Brand> brands = _brandService.FindAll().ToList();
            return View(brands);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Brand model)
        {
            if (ModelState.IsValid)
            {
                await _brandService.Create(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
        [HttpGet]
        public IActionResult Update(int Id)
        {
            Brand brands = _brandService.FindById(Id);
            if (brands != null)
            {
                return View(brands);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Update(Brand model)
        {
            if (ModelState.IsValid)
            {
                await _brandService.Update(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
        public async Task<IActionResult> Delete(int Id)
        {
            bool result = await _brandService.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}
