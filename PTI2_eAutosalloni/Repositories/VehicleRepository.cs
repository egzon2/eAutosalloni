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
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ApplicationDbContext context;

        public VehicleRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<Vehicle> Create(Vehicle entity)
        {
            await context.Vehicles.AddAsync(entity);
            await Save();
            return entity;
        }

        public async Task<bool> Delete(Vehicle entity)
        {
            context.Vehicles.Remove(entity);
            return await Save();
        }

        public async Task<List<Vehicle>> FindAll()
        {
            return await context.Vehicles.Include(x => x.Category).Include(x=> x.Brand).ToListAsync();
        }

        public async Task<List<Vehicle>> FindByCategory(int CategoryId)
        {
            return await context.Vehicles.Where(x => x.CategoryId == CategoryId).ToListAsync();
        }

        public async Task<Vehicle> FindById(int Id)
        {
            return await context.Vehicles.Include(x => x.Category).Include(x => x.Brand).Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public bool isExists(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Save()
        {
            int changes = await context.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(Vehicle entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            return await Save();
        }
    }
}
