using AutoMapper;
using DataAccess.Entities;
using MonnyBE.DTOs;

namespace MonnyBE.Profiles
{
    public class CustomCategoryProfile : Profile
    {
        public CustomCategoryProfile()
        {
            CreateMap<CustomCategory, CustomCategoryDTO>();
            CreateMap<CustomCategoryDTO, CustomCategory>();
        }
    }
}