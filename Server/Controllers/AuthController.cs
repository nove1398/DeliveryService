using System.Threading.Tasks;
using DeliveryService.Server.Helpers;
using DeliveryService.Server.Services;
using DeliveryService.Shared.API;
using DeliveryService.Shared.Models;
using Microsoft.AspNetCore.Mvc;


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

            var user =  await _userService.GetUser(login.Email);
            if(user == null)
            {
                return NotFound(new AuthResponse { Error = "No user with that account", Successfull  = false, Token = null });
            }

            if(!_passwordHash.VerifyPassword(_passwordHash.HashPassword(login.Password).Password, user.HashedPassword, user.Salt))
            {
                return Ok(new AuthResponse { Error = "Invalid details entered", Successfull = false, Token = string.Empty});
            }

            //Login here
            return Ok(new AuthResponse { Token = _tokenService.GenerateToken(user), Error = string.Empty, Successfull = true }); ;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody]RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseModel<string> { IsSuccess = false, Message = "Invalid form data sent"});
            }

            var hashedObj = _passwordHash.HashPassword(request.Password);
            var newUser = new AppUser();
            newUser.FirstName = request.FirstName;
            newUser.LastName = request.LastName;
            newUser.Email = request.Email;
            newUser.HashedPassword = hashedObj.Password;
            newUser.Salt = hashedObj.Salt;
            newUser.Addresses.Add(request.Address);


            var createdUser = await _userService.CreateUser(newUser);
            createdUser.AppUserRoles.Add(new AppUserRoles { AppUserId = createdUser.AppUserId, AppRoleId = 5 });
            var dbUser = await _userService.UpdateUser(createdUser);

            return Ok(new ResponseModel<AppUser> { IsSuccess = true, Data = dbUser, Message = $"Registered new account for {newUser.FirstName}"});
        }
    }
}
