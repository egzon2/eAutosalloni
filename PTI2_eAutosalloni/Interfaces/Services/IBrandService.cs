using Microsoft.AspNetCore.Mvc.Rendering;
using PTI2_eAutosalloni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTI2_eAutosalloni.Interfaces.Services
{
    public interface IBrandService
    {
        public Task<Brand> Create(Brand entity);
        public Task<bool> Update(Brand entity);
        public Task<bool> Delete(int Id);
        public List<Brand> FindAll();
        public Brand FindById(int Id);
        public bool isExists(int id);
        public Task<List<SelectListItem>> SelectListItems();
    }
}
