using Api.Extensions;
using Api.ViewModels;
using AutoMapper;
using BLL.DTO;
using Microsoft.AspNetCore.Http;
using System;

namespace Api.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PictureViewModel, PicturesDTO>()
                .ReverseMap()
                .ForMember(x => x.Picture, c => c.MapFrom(x => $"data:image/png;base64,{Convert.ToBase64String(x.Picture)}"));

            CreateMap<IFormFile, PicturesDTO>()
                .ForMember(x => x.Picture, c => c.MapFrom(x => x.AsByteArray()));
        }
    }
}