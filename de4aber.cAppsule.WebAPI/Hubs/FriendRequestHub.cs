using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using de4aber.cAppsule.Core.DTOs;
using de4aber.cAppsule.Core.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Primitives;

namespace cAppsule.Hubs
{
    public class FriendRequestHub : Hub
    {
        private ICapsuleService _capsuleService;


        public FriendRequestHub(ICapsuleService capsuleService)
        {
            _capsuleService = capsuleService;
        }

        public override async Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            StringValues _userID = httpContext.Request.Query["userID"];
            Console.WriteLine("connected with userId" + _userID);

            var capsules = _capsuleService.GetByReceiverId(Int32.Parse(_userID));
            
            Console.WriteLine("capsules total = " + capsules.Count);
            
            await Clients.Caller.SendAsync("load", capsules);
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.Caller.SendAsync("ReceiveMessage", user, message);
        }

        public async Task<List<ReceiveCapsuleDTO>> GetCapsules(int id)
        {
            var capsules = _capsuleService.GetByReceiverId(id);
            return capsules;
        }
        
        public async Task Broadcast(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", new
            {
                Message = message
            });
        }

    }
}