using System;
using System.Collections.Generic;
using de4aber.cAppsule.Core.DTOs;
using de4aber.cAppsule.Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace cAppsule.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FriendshipController : ControllerBase
    {
        private readonly IFriendshipService _friendshipService;

        public FriendshipController(IFriendshipService friendshipService)
        {
            _friendshipService = friendshipService;
        }

        [HttpGet]
        public ActionResult<List<FriendshipDTO>> GetAll()
        {
            return _friendshipService.FindAll();
        }
        
        [HttpGet(nameof(GetFriendsByUserId) +"/{userId}")]
        public ActionResult<List<UserDTO>> GetFriendsByUserId(string userId)
        {
            return _friendshipService.FindByUserId(Convert.ToInt32(userId));
        }
    }
}