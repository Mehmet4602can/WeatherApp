using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WatherApp.Business;
using WatherApp.Entity.Entities;

namespace WatherApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtTokenService _jwtTokenService;
        public AuthController(JwtTokenService jwtTokenService)
        {
            _jwtTokenService = jwtTokenService;
        }
        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            // Burada kullanıcıyı veri tabanına kaydetmen gerekiyor (şimdilik veri tutmadığımız için pas)
            // Bu kısmı DataAccess katmanında yapıcaz ileride
            var token = _jwtTokenService.GenerateToken(user);
            return Ok(new { token });
        }
    }
}
