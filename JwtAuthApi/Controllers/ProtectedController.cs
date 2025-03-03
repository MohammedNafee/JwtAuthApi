using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthApi.Controllers
{

    [Route("api/[Controller]/[action]")]
    [ApiController]
    public class ProtectedController : ControllerBase
    {
        
        [HttpGet]
        [Authorize]
        public IActionResult GetSecret()
        {
            return Ok(new { message = "This is a protected resource!" });
        }
    }

}
