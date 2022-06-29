
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using PTI2_eAutosalloni.Interfaces.Services;
using PTI2_eAutosalloni.Models;

namespace PTI2_eAutosalloni.Areas.Admin.Controllers
{
    [Area("Admin")]
    // [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
       
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;       
        }
        public IActionResult Index()
        {
            List<Category> categories = categoryService.FindAll().ToList();
            return View(categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category model)
        {
            if (ModelState.IsValid)
            {
                await categoryService.Create(model);
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
            Category category = categoryService.FindById(Id);
            if(category != null)
            {             
                return View(category);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Update(Category model)
        {
            if (ModelState.IsValid)
            {
                await categoryService.Update(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
        public async Task<IActionResult> Delete(int Id)
        {
            bool result = await categoryService.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}
