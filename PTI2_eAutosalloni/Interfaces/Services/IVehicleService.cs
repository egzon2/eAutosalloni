using PTI2_eAutosalloni.Models;
using PTI2_eAutosalloni.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTI2_eAutosalloni.Interfaces.Services
{
    public interface IVehicleService
    {
        public Task<Vehicle> Create(VehicleViewModel entity);
        public Task<bool> Update(VehicleViewModel entity);
        public Task<bool> Delete(int Id);
        public Task<List<Vehicle>> FindAll();
        public Task<Vehicle> FindById(int Id);
        public Task<List<Vehicle>> FindByCategory(int CategoryId);
    }
}
