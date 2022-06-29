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
    public class VehicleImageRepository : IVehicleImageRepository
    {
        private readonly ApplicationDbContext context;

        public VehicleImageRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Create(VehicleImage entity)
        {
            await context.VehicleImages.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> DeleteAllPictures(int Id)
        {
            List<VehicleImage> productImages = context.VehicleImages.Where(x => x.VehicleId == Id).ToList();
            foreach(var item in productImages)
            {
                context.VehicleImages.Remove(item);
            }
            return await Save();
        }

        public async Task<List<VehicleImage>> FindAll(int Id)
        {
            return await context.VehicleImages.Where(x => x.VehicleId == Id).ToListAsync();
        }

        public async Task<bool> Save()
        {
            int changes = await context.SaveChangesAsync();
            return changes > 0;
        }
    }
}
