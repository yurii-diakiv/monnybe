using System.Collections.Generic;
using DataAccess.Repositories;
using DataAccess.Entities;
using AutoMapper;
using MonnyBE.DTOs;

namespace MonnyBE.Services
{
    public class CustomCategoriesService
    {
        private readonly CustomCategoryRepository repository;
        private readonly IMapper _mapper;

        public CustomCategoriesService(CustomCategoryRepository customCategoryRepository, IMapper mapper)
        {
            repository = customCategoryRepository;
            _mapper = mapper;
        }
        public List<CustomCategoryDTO> GetItems(int userId)
        {
            List<CustomCategory> customCategories = repository.GetItems(userId);
            List<CustomCategoryDTO> customCategoryDTOs = _mapper.Map<List<CustomCategoryDTO>>(customCategories);
            return customCategoryDTOs;
        }
        public void Create(CustomCategoryDTO item)
        {
            CustomCategory customCategory = _mapper.Map<CustomCategory>(item);
            repository.Create(customCategory);
        }
        public void Delete(int id)
        {
            repository.Delete(id);
        }
    }
}