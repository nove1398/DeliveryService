using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliveryService.Server.Services;
using DeliveryService.Shared.API;
using DeliveryService.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryService.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly IUserService _userSrvice;
        private readonly IStoreService _storeService;
        private readonly IRiderService _riderService;


        public ApiController(IUserService service, IStoreService storeService,IRiderService riderService)
        {
            _userSrvice = service;
            _storeService = storeService;
            _riderService = riderService;
        }

        #region AppUsers 
        //GET: api/appusers
        [HttpGet("appusers")]
        public async Task<IActionResult> AllUsers()
        {
            var data = await _userSrvice.GetUsers();
            return Ok(new ResponseModel<List<AppUser>>() { Data = data, Message = $"Retrieved {data.Count} result(s)", IsSuccess = true });
        }
        #endregion

        #region Restaurants
        //GET: api/stores
        [HttpGet("stores")]
        public async Task<IActionResult> AllStores()
        {
            var data = await _storeService.AllActiveStoresAsync();
            return Ok(new ResponseModel<List<Store>>() { Data = data, Message = $"Retrieved {data.Count} result(s)", IsSuccess = true });
        }
        #endregion

        #region Riders
        //GET: api/riders
        [HttpGet("riders")]
        public async Task<IActionResult> AllRiders()
        {
            var data = await _userSrvice.GetUsers();
            return Ok(new ResponseModel<List<AppUser>>() { Data = data, Message = $"Retrieved {data.Count} result(s)", IsSuccess = true });
        }
        #endregion
    }
}
