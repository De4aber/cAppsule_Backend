using System.Collections.Generic;
using de4aber.cAppsule.Core.DTOs;
using de4aber.cAppsule.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace de4aber.cAppsule.Core.IServices
{
    public interface ICapsuleService
    {
        public List<Capsule> GetAll();

        public List<ReceiveCapsuleDTO> GetByReceiverId(int receiverId);
        
        public ReceiveCapsuleDTO GetById(int capsuleId);

        public bool SendCapsule(SendCapsuleDTO capsule);
        
    }
}