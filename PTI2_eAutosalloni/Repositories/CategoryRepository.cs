
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PTI2_eAutosalloni.Data;
using PTI2_eAutosalloni.Interfaces.Repositories;
using PTI2_eAutosalloni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTI2_eAutosalloni.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext context;

        public CategoryRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<Category> Create(Category entity)
        {
            context.Categories.Add(entity);
            await Save();
            return entity;
        }
        public async Task<bool> Delete(int id)
        {
            Category category = FindById(id);
            if(category != null)
            {
                context.Categories.Remove(category);
                return await Save();
            }
            else
            {
                return false;
            }
            
        }

        public List<Category> FindAll()
        {
            return context.Categories.ToList();
            
        }

        public Category FindById(int id)
        {
            return context.Categories.Find(id);
        }

        public bool isExists(int id)
        {
            return context.Categories.Any(q => q.Id == id);
        }

        public async Task<bool> Save()
        {
            var changes = await context.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<List<SelectListItem>> SelectListItems()
        {
            List<SelectListItem> categories = await context.Categories.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToListAsync();
            return categories;
        }

        public async Task<bool> Update(Category entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            return await Save();
        }
    }
}
