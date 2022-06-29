using Microsoft.AspNetCore.Mvc.Rendering;
using PTI2_eAutosalloni.Interfaces.Repositories;
using PTI2_eAutosalloni.Interfaces.Services;
using PTI2_eAutosalloni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTI2_eAutosalloni.Services
{
    public class BrandService:IBrandService
    {
        private readonly IBrandRepository _brandRepo;


        public BrandService(IBrandRepository brandRepo)
        {
            _brandRepo = brandRepo;
        }

        public async Task<Brand> Create(Brand entity)
        {

            return await _brandRepo.Create(entity);
        }

        public Brand FindById(int Id)
        {
            return _brandRepo.FindById(Id);
        }
        public List<Brand> FindAll()
        {
            return _brandRepo.FindAll();
        }
        public async Task<bool> Update(Brand entity)
        {
            return await _brandRepo.Update(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _brandRepo.Delete(id);
        }

        public bool isExists(int id)
        {
            return _brandRepo.isExists(id);
        }

        public async Task<List<SelectListItem>> SelectListItems()
        {
            return await _brandRepo.SelectListItems();
        }
    }
}
