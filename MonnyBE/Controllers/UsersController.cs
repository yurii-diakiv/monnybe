using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MonnyBE.Services;
using DataAccess.Entities;
using MonnyBE.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using MonnyBE.DTOs;

namespace MonnyBE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UsersService usersService;
        public UsersController(UsersService service)
        {
            usersService = service;
        }

        [HttpGet("{id}"), Authorize]
        public UserDTO Get(int id)
        {
            return usersService.GetUser(id);
        }

        [HttpPost]
        public void Post([FromBody]UserDTO user)
        {
            usersService.Register(user);
        }

        [HttpPost, Route("login")]
        public IActionResult Login([FromBody]LoginModel loginModel)
        {
            if (loginModel == null)
                return BadRequest("Invalid client request");

            User user = usersService.Login(loginModel);

            if (user == null)
                return Unauthorized();

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
            };

            var tokeOptions = new JwtSecurityToken(
                issuer: "https://localhost:5001",
                audience: "https://localhost:5001",
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            
            return Ok(new { Token = tokenString});
        }
    }
}
