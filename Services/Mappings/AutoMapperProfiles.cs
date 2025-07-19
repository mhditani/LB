using AutoMapper;
using Entities.Domain;
using Entities.DTO_S;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<Region, CreateRegionDto>().ReverseMap();
            CreateMap<Region, UpdateRegionDto>().ReverseMap();
        }
    }
}
