using Microsoft.AspNetCore.Mvc.Rendering;
using PTI2_eAutosalloni.Interfaces.Repositories;
using PTI2_eAutosalloni.Interfaces.Services;
using PTI2_eAutosalloni.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PTI2_eAutosalloni.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepo;
       

        public CategoryService(ICategoryRepository categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }

        public async Task<Category> Create(Category entity)
        {
           
            return await categoryRepo.Create(entity);
        } 
        
        public Category FindById(int Id)
        {
            return categoryRepo.FindById(Id);
        }
        public List<Category> FindAll()
        {
            return categoryRepo.FindAll();
        }
        public async Task<bool> Update(Category entity)
        {
            return await categoryRepo.Update(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await categoryRepo.Delete(id);
        }

        public bool isExists(int id)
        {
            return categoryRepo.isExists(id);
        }

        public async Task<List<SelectListItem>> SelectListItems()
        {
            return await categoryRepo.SelectListItems();
        }
    }
}
