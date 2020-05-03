using System.Collections.Generic;
using DataAccess.Repositories;
using DataAccess.Entities;
using AutoMapper;
using MonnyBE.DTOs;

namespace MonnyBE.Services
{
    public class CategoriesService
    {
        private readonly CategoryRepository repository;
        private readonly IMapper _mapper;

        public CategoriesService(CategoryRepository categoryRepository, IMapper mapper)
        {
            repository = categoryRepository;
            _mapper = mapper;
        }
        public CategoryDTO GetCategory(int id)
        {
            Category category = repository.GetItem(id);
            CategoryDTO categoryDTO = _mapper.Map<CategoryDTO>(category);
            return categoryDTO;
        }
        public List<CategoryDTO> GetItems()
        {
            List<Category> categories = repository.GetItems();
            List<CategoryDTO> categoryDTOs = _mapper.Map<List<CategoryDTO>>(categories);
            return categoryDTOs;
        }
    }
}