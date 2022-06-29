using AutoMapper;
using PTI2_eAutosalloni.Interfaces.Repositories;
using PTI2_eAutosalloni.Interfaces.Services;
using PTI2_eAutosalloni.Models;
using PTI2_eAutosalloni.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PTI2_eAutosalloni.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IVehicleImageService _vehicleImageService;
        private readonly IMapper _mapper;

        public VehicleService(IVehicleRepository vehicleRepository, IMapper mapper, IVehicleImageService vehicleImageService)
        {
            _vehicleRepository = vehicleRepository;
            _vehicleImageService = vehicleImageService;
            _mapper = mapper;
        }
        public async Task<Vehicle> Create(VehicleViewModel model)
        {
            Vehicle vehicle = _mapper.Map<Vehicle>(model);
            vehicle.AddedDate = DateTime.Now;
            byte[] pictureBytes = null;

            using (var stream = new MemoryStream())
            {
                await model.DefaultPhoto.CopyToAsync(stream);
                pictureBytes = stream.ToArray();

                vehicle.DefaultImage = pictureBytes;
            }
            var result = await _vehicleRepository.Create(vehicle);

            VehicleImageViewModel productImageModel = new VehicleImageViewModel
            {
                VehicleID = result.Id,
                Images = model.Images
            };
            await _vehicleImageService.Create(productImageModel);
            return result;
        }

        public async Task<bool> Update(VehicleViewModel model)
        {
            // product.AddedDate = DateTime.Now;

            Vehicle vehicle = new Vehicle();
            byte[] pictureBytes = null;

            using (var stream = new MemoryStream())
            {
                await model.DefaultPhoto.CopyToAsync(stream);
                pictureBytes = stream.ToArray();

                vehicle.DefaultImage = pictureBytes;
            }

            var result = await _vehicleRepository.Update(vehicle);

            VehicleImageViewModel productImageModel = new VehicleImageViewModel
            {
                VehicleID = model.Id,
                Images = model.Images
            };
            await _vehicleImageService.Update(productImageModel);
            return result;
        }

        public async Task<bool> Delete(int Id)
        {
            Vehicle product = await _vehicleRepository.FindById(Id);
            if(product != null)
            {
                return await _vehicleRepository.Delete(product);
            }
            else
            {
                throw new ArgumentException("Cannot find product to delete", "Delete");
            }
        }

        public async Task<List<Vehicle>> FindAll()
        {
            return await _vehicleRepository.FindAll();
        }

        public async Task<Vehicle> FindById(int Id)
        {
            return await _vehicleRepository.FindById(Id);
        }

        public async Task<List<Vehicle>> FindByCategory(int CategoryId)
        {
            return await _vehicleRepository.FindByCategory(CategoryId);
        }

        Task<bool> IVehicleService.Update(VehicleViewModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
