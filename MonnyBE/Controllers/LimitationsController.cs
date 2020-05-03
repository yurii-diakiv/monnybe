using Microsoft.AspNetCore.Mvc;
using MonnyBE.Services;
using Microsoft.AspNetCore.Authorization;
using MonnyBE.DTOs;

namespace MonnyBE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LimitationsController : ControllerBase
    {
        private readonly LimitationsService limitationsService;
        public LimitationsController(LimitationsService service)
        {
            limitationsService = service;
        }

        [HttpGet("byUserId/{id}"), Authorize]
        public LimitationDTO GetByUserId(int id)
        {
            return limitationsService.GetLimitationByUserId(id);
        }
        
        [HttpPut, Authorize]
        public void Put([FromBody] LimitationDTO limitation)
        {
            limitationsService.Update(limitation);
        }
    }
}
