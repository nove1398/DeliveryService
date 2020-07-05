using System.Threading.Tasks;
using DeliveryService.Models;
using DeliveryService.Server.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PingMe.Data;
using PingMe.Models;
using PingMe.Services;

namespace DeliveryService.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly PingMeContext _context;
        private readonly ITokenService _tokenService;

        public AuthController(IConfiguration config, PingMeContext context,ITokenService tokenService)
        {
            _config = config;
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> ValidateUser([FromBody]LoginModel login)
        {

            //Login here
            var user = new AppUser();
            return Ok(new AuthResponse { Token = _tokenService.GenerateToken(user), Error = string.Empty, Successfull = true }); ;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser()
        {
            return Ok(new AuthResponse { Successfull = true, Error = string.Empty});
        }
    }
}
