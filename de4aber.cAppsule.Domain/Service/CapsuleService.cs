using System.Collections.Generic;
using System.IO;
using de4aber.cAppsule.Core.IServices;
using de4aber.cAppsule.Core.Models;
using de4aber.cAppsule.Domain.IRepositories;

namespace de4aber.cAppsule.Domain.Service
{
    public class CapsuleService: ICapsuleService
    {
        private readonly ICapsuleRepository _capsuleRepository;

        public CapsuleService(ICapsuleRepository capsuleRepository)
        {
            _capsuleRepository = capsuleRepository ?? throw new InvalidDataException("capsuleRepository cannot be null");
        }

        public List<Capsule> GetAll()
        {
            return _capsuleRepository.FindAll();
        }
    }
}