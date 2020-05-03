using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MonnyBE.Services;
using Microsoft.AspNetCore.Authorization;
using MonnyBE.DTOs;

namespace MonnyBE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomCategoriesController : ControllerBase
    {
        private readonly CustomCategoriesService customCategoriesService;
        public CustomCategoriesController(CustomCategoriesService service)
        {
            customCategoriesService = service;
        }
        
        [HttpGet("{userId}"), Authorize]
        public List<CustomCategoryDTO> Get(int userId)
        {
            return customCategoriesService.GetItems(userId);
        }

        [HttpPost, Authorize]
        public void Post([FromBody] CustomCategoryDTO customCategoryDTO)
        {
            customCategoriesService.Create(customCategoryDTO);
        }

        [HttpDelete("{id}"), Authorize]
        public void Delete(int id)
        {
            customCategoriesService.Delete(id);
        }
    }
}