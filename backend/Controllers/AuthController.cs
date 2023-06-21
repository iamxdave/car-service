using backend.DTOs;
using backend.Helpers.Jwt;
using backend.Services.Users;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IJwtService _jwtService;

        public AuthController(IUserService service, IJwtService jwtService)
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
                    message = "Account with that email already exists"
                });
            }

            var user = new User
            {
                Name = body.Name,
                Surname = body.Surname,
                Email = body.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(body.Password)
            };

            await _service.CreateAsync(user);

            await _service.SaveChangesAsync();
            
            return Created("success", user);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto body) 
        {
            var user = await _service.GetByEmail(body.Email);

            if(user == null)
                return Unauthorized(new {message = "Invalid credentials"});

            if(!BCrypt.Net.BCrypt.Verify(body.Password, user.Password))
                return Unauthorized(new {message = "Invalid credentials"});
            

                var jwt = _jwtService.Generate(user.IdPerson);

                Response.Cookies.Append("jwt", jwt, new CookieOptions
                {
                    HttpOnly = false,
                    IsEssential = true,
                    Secure = true,
                    SameSite = SameSiteMode.None,
                    Domain = "localhost",
                    Expires = DateTime.UtcNow.AddDays(14)
                });

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
                
                Guid userId = Guid.Parse(token.Issuer);

                var user = await _service.GetByIdAsync(userId);

                return Ok(user);
            } catch (Exception _)
            {
                return Unauthorized(new { message = "Invalid credentials" });
            }
        }
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt", new CookieOptions
                {
                    Secure = true,
                    SameSite = SameSiteMode.None,
                }
            );

            return Ok(new
            {
                message = "success"
            });
        }
    }
}