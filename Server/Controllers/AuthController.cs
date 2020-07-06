using System;
using System.Threading.Tasks;
using DeliveryService.Server.Data;
using DeliveryService.Server.Helpers;
using DeliveryService.Server.Services;
using DeliveryService.Shared.API;
using DeliveryService.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PingMe.Models;

namespace DeliveryService.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        private readonly PasswordHasher _passwordHash;

        public AuthController(ITokenService tokenService,IUserService userService)
        {
            _tokenService = tokenService;
            _userService = userService;
            _passwordHash = new PasswordHasher();
        }

        [HttpPost("login")]
        public async Task<IActionResult> ValidateUser([FromBody]AuthRequest login)
        {

            var user = new AppUser();// await _userService.GetUser(login.Email);
            if(user == null)
            {
                return NotFound();
            }

            if(!_passwordHash.VerifyPassword(_passwordHash.HashPassword(login.Password).HashedPass, user.HashedPassword, user.Salt))
            {
                return Ok(new AuthResponse { Error = "Invalid details entered", Successfull = false, Token = string.Empty});
            }

            //Login here
            return Ok(new AuthResponse { Token = _tokenService.GenerateToken(user), Error = string.Empty, Successfull = true }); ;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody]RegisterRequest request)
        {

            var newUser = new AppUser();
            newUser.FirstName = request.FirstName;


            return Ok(new ResponseModel<AppUser> { IsSuccess = true, Data = newUser, Message = $"Registered new account for {newUser.FirstName}"});
        }
    }
}
