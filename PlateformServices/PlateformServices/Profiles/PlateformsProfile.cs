using AutoMapper;
using PlateformServices.Dtos;
using PlateformServices.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlateformServices.Profiles
{
    public class PlateformsProfile : Profile
    {
        public PlateformsProfile()
        {
            CreateMap<Plateform, PlateformReadDto>();
            CreateMap<PlateformCreateDto, Plateform>();
        }
        
    }
}
