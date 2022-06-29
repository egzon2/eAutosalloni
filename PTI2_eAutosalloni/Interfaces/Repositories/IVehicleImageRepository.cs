using PTI2_eAutosalloni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTI2_eAutosalloni.Interfaces.Repositories
{
    public interface IVehicleImageRepository
    {
        public Task<bool> Create(VehicleImage entity);
        public Task<bool> DeleteAllPictures(int Id);
        public Task<List<VehicleImage>> FindAll(int Id);
        public Task<bool> Save();
    }
}
