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
    public class CapsuleHub : Hub
    {
        private ICapsuleService _capsuleService;


        public CapsuleHub(ICapsuleService capsuleService)
        {
            _capsuleService = capsuleService;
        }

        public override async Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            StringValues _userID = httpContext.Request.Query["userID"];

            var capsules = _capsuleService.GetByReceiverId(Int32.Parse(_userID));
            
            
            await Clients.Caller.SendAsync("load", capsules);
        }


    }
}