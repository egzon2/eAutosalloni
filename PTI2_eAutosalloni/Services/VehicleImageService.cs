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
    public class VehicleImageService : IVehicleImageService
    {
        private readonly IVehicleImageRepository _vehicleImageRepository;

        public VehicleImageService(IVehicleImageRepository vehicleImageRepository)
        {
            _vehicleImageRepository = vehicleImageRepository;
        }

        public async Task<bool> Create(VehicleImageViewModel model)
        {
            foreach(var item in model.Images)
            {
                VehicleImage image = new VehicleImage
                {
                    VehicleId = model.VehicleID
                };
                byte[] pictureBytes = null;

                using (var stream = new MemoryStream())
                {
                    await item.CopyToAsync(stream);
                    pictureBytes = stream.ToArray();

                    image.VehicleImg = pictureBytes;
                }
               
                var result = await _vehicleImageRepository.Create(image);
                if (!result)
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<List<VehicleImage>> FindAll(int Id)
        {
            return await _vehicleImageRepository.FindAll(Id);
        }

        public async Task<bool> Update(VehicleImageViewModel model)
        {
            if(model != null)
            {
                await _vehicleImageRepository.DeleteAllPictures(model.VehicleID);
                foreach (var item in model.Images)
                {
                    VehicleImage image = new VehicleImage
                    {
                        VehicleId = model.VehicleID
                    };
                    byte[] pictureBytes = null;

                    using (var stream = new MemoryStream())
                    {
                        await item.CopyToAsync(stream);
                        pictureBytes = stream.ToArray();

                        image.VehicleImg = pictureBytes;
                    }
                    var result = await _vehicleImageRepository.Create(image);
                    if (!result)
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                throw new ArgumentException("ProductViewModel cannot be null", "ProductViewModel");
            }
        }
    }
}
