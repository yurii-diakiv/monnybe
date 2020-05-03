using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MonnyBE.Services;
using Microsoft.AspNetCore.Authorization;
using MonnyBE.DTOs;

namespace MonnyBE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoriesService categoriesService;
        public CategoriesController(CategoriesService service)
        {
            categoriesService = service;
        }

        [HttpGet("{id}"), Authorize]
        public CategoryDTO Get(int id)
        {
            return categoriesService.GetCategory(id);
        }

        [HttpGet, Authorize]
        public List<CategoryDTO> Get()
        {
            return categoriesService.GetItems();
        }
    }
}