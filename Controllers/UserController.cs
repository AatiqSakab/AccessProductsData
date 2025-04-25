using AccessProductsData.Data;
using AccessProductsData.Models;
using Azure.Core;   
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using AccessProductsData.Helpers;


namespace AccessProductsData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;

       public UserController(ApplicationDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User userDto)
        {
            var user = new User
            {
                Username = userDto.Username,
                Email = userDto.Email,
                Password = userDto.Password
            };
            if (await _context.Users.AnyAsync(u => u.Username == user.Username))
            {
                return BadRequest("User already exists");
            }
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok("User registered successfully");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDto userDto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == userDto.Username && u.Password == userDto.Password);
            if (user == null)
            {
                return Unauthorized("Invalid username or password");
            }

            var token = JwtHelper.GenerateToken(user.Username, _config);
            return Ok(new { token });
        }

    }
}
