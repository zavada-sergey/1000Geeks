using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using System;

namespace BLL.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PicturesDTO, Pictures>()
                .ForMember(d => d.HashId, c => c.MapFrom(x => Guid.NewGuid().ToString()))
                .ReverseMap();
        }
    }
}