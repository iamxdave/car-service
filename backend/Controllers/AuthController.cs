using backend.DTOs;
using backend.Helpers.Jwt;
using backend.Services.Customers;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ICustomerService _service;
        private readonly IJwtService _jwtService;

        public AuthController(ICustomerService service, IJwtService jwtService)
        {
            _service = service;
            _jwtService = jwtService;
        }

        [HttpPostAttribute("register")]
        public async Task<IActionResult> Register(RegisterDto body)
        {
            if(await _service.GetByEmail(body.Email) != null)
            {
                return Conflict(new{
                    message = "email exists"
                });
            }

            var customer = new Customer
            {
                Name = body.Name,
                Surname = body.Surname,
                BirthDate = body.BirthDate,
                Email = body.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(body.Password)
            };

            await _service.CreateAsync(customer);

            await _service.SaveChangesAsync();
            
            return Created("success", customer);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto body) 
        {
            var customer = await _service.GetByEmail(body.Email);

            if(customer == null)
                return Unauthorized(new {message = "Invalid credentials"});

            if(!BCrypt.Net.BCrypt.Verify(body.Password, customer.Password))
                return Unauthorized(new {message = "Invalid credentials"});
            
            //TODO
            // if(body.IsRemebered)
            // {
                var jwt = _jwtService.Generate(customer.IdPerson);

                Response.Cookies.Append("jwt", jwt, new CookieOptions
                {
                    HttpOnly = false,
                    IsEssential = true,
                    Secure = true,
                    SameSite = SameSiteMode.None,
                    Domain = "localhost",
                    Expires = DateTime.UtcNow.AddDays(14)
                });

            // }

            return Ok(new {
                message = "Success"
            });
        }
        [HttpGet("user")]
        public async Task<IActionResult> GetUser()
        {
            try {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);
                
                int userId = int.Parse(token.Issuer);

                var user = await _service.GetById(userId);

                return Ok(user);
            } catch (Exception _)
            {
                return Unauthorized(new { message = "Invalid credentials" });
            }
        }
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");

            return Ok(new
            {
                message = "success"
            });
        }
    }
}