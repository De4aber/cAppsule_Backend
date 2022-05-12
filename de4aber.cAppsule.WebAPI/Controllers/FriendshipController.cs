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
        public ActionResult<List<Friendship>> GetAll()
        {
            return _friendshipService.FindAll();
        }
        
        [HttpGet(nameof(GetFriendsByUserId) +"/{userId}")]
        public ActionResult<List<FriendDto>> GetFriendsByUserId(string userId)
        {
            return _friendshipService.FindByUserId(Convert.ToInt32(userId));
        }
        
        [HttpGet(nameof(GetFriendRequestsByUserId) +"/{userId}")]
        public ActionResult<List<FriendRequestReceiverDto>> GetFriendRequestsByUserId(string userId)
        {
            return _friendshipService.FindFriendRequestsByUserId(Convert.ToInt32(userId));
        }
        
        [HttpGet(nameof(SearchForUsernames_FilterIsFriends) +"/{userId}"+"/{searchStr}")]
        public ActionResult<List<SearchForUserIsFriendDTO>> SearchForUsernames_FilterIsFriends(string searchStr, string userId)
        {
            return _friendshipService.SearchForUsernames_FilterIsFriends(searchStr, Convert.ToInt32(userId));
        }
        
        [HttpDelete]
        public ActionResult<bool> DeleteById(int id)
        {
            return _friendshipService.DeleteById(id);
        }
        
        [HttpPost(nameof(RequestFriend))]

        public ActionResult<bool> RequestFriend(FriendRequestDto friendship)
        {
            return _friendshipService.RequestFriendship(friendship);
        }
        
        [HttpPut(nameof(AcceptFriendRequest))]
        public ActionResult<FriendDto> AcceptFriendRequest(int friendshipId, int acceptingUserId)
        {
            return _friendshipService.AcceptFriendship(friendshipId, acceptingUserId);
        }
        
        [HttpPut(nameof(UpdateFriend))]
        public ActionResult<Friendship> UpdateFriend(int friendshipId,Friendship friendship)
        {
            return _friendshipService.Update(friendshipId, friendship);
        }
    }
}