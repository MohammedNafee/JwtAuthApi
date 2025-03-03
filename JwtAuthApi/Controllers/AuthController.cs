using JwtAuthApi.DTOs;
using JwtAuthApi.Managers;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthApi.Controllers
{
    [Route("api/[Controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtManager _jwtManager;

        public AuthController(JwtManager jwtManager)
        {
            _jwtManager = jwtManager;
        }

        [HttpPost]
        public IActionResult Login([FromBody] UserLoginDto user)
        {
            if (user.Username == "admin" && user.Password == "password") // Mock user validation
            {
                var token = _jwtManager.GenerateToken(user.Username);
                return Ok(new { token });
            }
            return Unauthorized();
        }
    }

}
