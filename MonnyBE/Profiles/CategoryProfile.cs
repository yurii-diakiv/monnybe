using AutoMapper;
using DataAccess.Entities;
using MonnyBE.DTOs;

namespace MonnyBE.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();
        }
    }
}