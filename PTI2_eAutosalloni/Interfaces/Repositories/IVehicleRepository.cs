using PTI2_eAutosalloni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTI2_eAutosalloni.Interfaces.Repositories
{
    public interface IVehicleRepository
    {
        public Task<Vehicle> Create(Vehicle Entity);
        public Task<bool> Update(Vehicle Entity);
        public Task<bool> Delete(Vehicle Entity);
        public Task<bool> Save();
        public bool isExists(int Id);
        public Task<List<Vehicle>> FindAll();
        public Task<Vehicle> FindById(int Id);
        public Task<List<Vehicle>> FindByCategory(int CategoryId);
    }
}
