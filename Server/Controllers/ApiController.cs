using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliveryService.Client.Pages;
using DeliveryService.Server.Services;
using DeliveryService.Shared.API;
using DeliveryService.Shared.Models;
using DeliveryService.Shared.ViewModels;
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
        private readonly IGeneralService _generalService;

        public ApiController(IUserService service, IStoreService storeService,IRiderService riderService,IGeneralService generalService)
        {
            _userSrvice = service;
            _storeService = storeService;
            _riderService = riderService;
            _generalService = generalService;
        }

        #region General Calls
        //GET: api/servicetypes
        [HttpGet("servicetypes")]
        public async Task<IActionResult> AllServicetypes()
        {
            var data = await _generalService.GetAllServiceTypes();
            return Ok(new ResponseModel<List<ServiceType>>() { Data = data, Message = $"Retrieved {data.Count} result(s)", IsSuccess = true });
        }
        //GET: api/parishes
        [HttpGet("parishes")]
        public async Task<IActionResult> AllParishes()
        {
            var data = await _generalService.GetAllParishes();
            return Ok(new ResponseModel<List<Parish>>() { Data = data, Message = $"Retrieved {data.Count} result(s)", IsSuccess = true });
        }
        #endregion

        #region AppUsers 
        //GET: api/appusers
        [HttpGet("appusers")]
        public async Task<IActionResult> AllUsers()
        {
            var data = await _userSrvice.GetUsers();
            return Ok(new ResponseModel<List<AppUser>>() { Data = data, Message = $"Retrieved {data.Count} result(s)", IsSuccess = true });
        }

        //GET: api/appusers/owners/james
        [HttpGet("appusers/nonowners/{needle}")]
        public async Task<IActionResult> AllOwnerUsers(string needle)
        {
            // Add bool check for owners vs non owners
            var data = await _userSrvice.UsersNotOwners(needle);
            return Ok(new ResponseModel<List<UserViewModel>>() { Data = data, Message = $"Retrieved {data.Count} result(s)", IsSuccess = true });
        }
        #endregion

        #region Stores
        //GET: api/stores
        [HttpGet("stores")]
        public async Task<IActionResult> AllStores()
        {
            var data = await _storeService.AllActiveStoresAsync();
            return Ok(new ResponseModel<List<StoreViewModel>>() { Data = data, Message = $"Retrieved {data.Count} result(s)", IsSuccess = true });
        }

        //POST: api/stores
        [HttpPost("stores")]
        public async Task<IActionResult> NewStoreAsync([FromBody] Store newStore)
        {
            newStore.IsActive = true;
            int success = await _storeService.AddNewStore(newStore);
            if(success == 1)
                return Ok(new ResponseModel<StoreViewModel> { Data = 
                                             new StoreViewModel { StoreName = newStore.Name, 
                                                                    IsActive= true }, 
                    Message =$"Added new store {newStore.Name}", 
                    IsSuccess = true});
            else
                return BadRequest(new ResponseModel<StoreViewModel> { Data = null, Message ="Failed to add new store", IsSuccess = false});
        }

        //GET: api/stores/10
        [HttpGet("stores/{id:int}")]
        public async Task<IActionResult> GetStoreAsync(int id)
        {
            var response = await _storeService.FindStore(id);
            if(response != null)
            {
                return Ok(new ResponseModel<StoreViewModel> { Data = response, IsSuccess = true, Message = "" });
            }
            return NotFound(new ResponseModel<StoreViewModel> { Data = null, IsSuccess = false, Message = "" });
        }

        //PUT: api/stores
        [HttpPut("stores")]
        public async Task<IActionResult> UpdateStoreAsync([FromBody]StoreViewModel model)
        {
            if (!ModelState.IsValid)
                return Ok(new ResponseModel<StoreViewModel> { Data = null, IsSuccess = false, Message = "Errors found" });

            var response = await _storeService.UpdateStore(model);
            var updatedStore = await _storeService.FindStore(model.Id);
            return Ok(new ResponseModel<StoreViewModel> { Data = updatedStore, IsSuccess = true, Message = "Updated successfully" });
        }
        #endregion

        #region Riders
        //GET: api/riders
        [HttpGet("riders")]
        public async Task<IActionResult> AllRiders()
        {
            var data = await _riderService.AllRidersAsync();
            return Ok(new ResponseModel<List<RiderViewModel>>() { Data = data, Message = $"Retrieved {data.Count} result(s)", IsSuccess = true });
        }

        //GET: api/riders/5
        [HttpGet("riders/{id:int}")]
        public async Task<IActionResult> GetRider(int  id)
        {
            var data = await _riderService.GetRiderAsync(id);
            if(data == null)
            {
                return NotFound(new ResponseModel<RiderViewModel> { Message = "No rider data found", IsSuccess = false, Data = null });
            }
            return Ok(new ResponseModel<RiderViewModel>() { Data = data, Message = $"Rider found", IsSuccess = true });
        }

        //POST: api/riders
        [HttpPost("riders")]
        public async Task<IActionResult> NewRider([FromBody] RiderViewModel newRider)
        {
            await _riderService.SaveNewRiderAsync(newRider);
            return Ok(new ResponseModel<RiderViewModel> { Data = newRider, Message ="New rider added to fleet", IsSuccess = true });
        }
        #endregion
    }
}
