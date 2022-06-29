
using Microsoft.AspNetCore.Mvc.Rendering;
using PTI2_eAutosalloni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTI2_eAutosalloni.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        public Task<Category> Create(Category entity);
        public Task<bool> Update(Category entity);
        public Task<bool> Delete(int Id);
        public Task<bool> Save();
        public bool isExists(int Id);
        public List<Category> FindAll();
        public Category FindById(int Id);
        public Task<List<SelectListItem>> SelectListItems();
    }
}
