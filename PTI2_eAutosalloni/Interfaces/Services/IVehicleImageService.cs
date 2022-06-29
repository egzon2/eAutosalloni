using PTI2_eAutosalloni.Models;
using PTI2_eAutosalloni.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTI2_eAutosalloni.Interfaces.Services
{
    public interface IVehicleImageService
    {
        public Task<bool> Create(VehicleImageViewModel entity);
        public Task<bool> Update(VehicleImageViewModel entity);
        public Task<List<VehicleImage>> FindAll(int Id);
    }
}
