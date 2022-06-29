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
    public class BrandRepository:IBrandRepository
    {
        private readonly ApplicationDbContext context;

        public BrandRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<Brand> Create(Brand entity)
        {
            context.Brands.Add(entity);
            await Save();
            return entity;
        }
        public async Task<bool> Delete(int id)
        {
            Brand brand = FindById(id);
            if (brand != null)
            {
                context.Brands.Remove(brand);
                return await Save();
            }
            else
            {
                return false;
            }

        }

        public List<Brand> FindAll()
        {
            return context.Brands.ToList();

        }

        public Brand FindById(int id)
        {
            return context.Brands.Find(id);
        }

        public bool isExists(int id)
        {
            return context.Brands.Any(q => q.Id == id);
        }

        public async Task<bool> Save()
        {
            var changes = await context.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<List<SelectListItem>> SelectListItems()
        {
            List<SelectListItem> brands = await context.Brands.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToListAsync();
            return brands;
        }

        public async Task<bool> Update(Brand entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            return await Save();
        }
    }
}
