using System.Collections.Generic;
using de4aber.cAppsule.Core.DTOs;
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
        
        [HttpGet(nameof(GetById)+"/{capsuleId}")]
        public ActionResult<ReceiveCapsuleDTO> GetById(int capsuleId)
        {
            return _capsuleService.GetById(capsuleId);
        }

        [HttpGet(nameof(GetByReceiverId)+"/{receiverId}")]
        public ActionResult<List<ReceiveCapsuleDTO>> GetByReceiverId(int receiverId)
        {
            return _capsuleService.GetByReceiverId(receiverId);
        }

        [HttpPost(nameof(SendCapsule))]
        public ActionResult<bool> SendCapsule(SendCapsuleDTO capsuleDto)
        {
            return _capsuleService.SendCapsule(capsuleDto);
        }


    }
}