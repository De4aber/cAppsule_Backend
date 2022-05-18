using System.Collections.Generic;
using de4aber.cAppsule.Core.IServices;
using de4aber.cAppsule.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace cAppsule.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class CapsuleController : ControllerBase
    {
        private readonly ICapsuleService _capsuleService;

        public CapsuleController(ICapsuleService capsuleService)
        {
            _capsuleService = capsuleService;
        }

        [HttpGet]
        public ActionResult<List<Capsule>> GetAll()
        {
            return _capsuleService.GetAll();
        }


    }
}