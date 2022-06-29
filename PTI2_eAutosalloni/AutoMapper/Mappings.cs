using AutoMapper;
using PTI2_eAutosalloni.Models;
using PTI2_eAutosalloni.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTI2_eAutosalloni.AutoMapper
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Category, CategoryViewModel>().ReverseMap();

            CreateMap<Vehicle, VehicleViewModel>().ReverseMap();
        }
    }
}
