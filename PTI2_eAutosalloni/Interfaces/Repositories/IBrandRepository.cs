using Microsoft.AspNetCore.Mvc.Rendering;
using PTI2_eAutosalloni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTI2_eAutosalloni.Interfaces.Repositories
{
   public interface IBrandRepository
    {
        public Task<Brand> Create(Brand entity);
        public Task<bool> Update(Brand entity);
        public Task<bool> Delete(int Id);
        public Task<bool> Save();
        public bool isExists(int Id);
        public List<Brand> FindAll();
        public Brand FindById(int Id);
        public Task<List<SelectListItem>> SelectListItems();
    }
}
