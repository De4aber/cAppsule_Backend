using System;
using System.Collections.Generic;
using System.IO;
using de4aber.cAppsule.Core.DTOs;
using de4aber.cAppsule.Core.IServices;
using de4aber.cAppsule.Core.Models;
using de4aber.cAppsule.Domain.IRepositories;

namespace de4aber.cAppsule.Domain.Service
{
    public class CapsuleService: ICapsuleService
    {
        private readonly ICapsuleRepository _capsuleRepository;
        private readonly IUserRepository _userRepository;


        public CapsuleService(ICapsuleRepository capsuleRepository, IUserRepository userRepository)
        {
            _capsuleRepository = capsuleRepository ?? throw new InvalidDataException("capsuleRepository cannot be null");
            _userRepository = userRepository ?? throw new InvalidDataException("userRepository cannot be null");
        }

        public List<Capsule> GetAll()
        {
            return _capsuleRepository.FindAll();
        }

        public bool SendCapsule(SendCapsuleDTO capsule)
        {
            _capsuleRepository.Create(new Capsule
            {
                SenderId = capsule.SenderId,
                ReceiverId = _userRepository.FindByUsername(capsule.RecieverUsername).Id,
                Latitude = capsule.Latitude,
                Longitude = capsule.Longitude,
                Message = capsule.Message,
                Time = IfTimeNull(capsule.Time),
                Photo = capsule.Photo
            });
            
            //TODO add to capScore

            return true;
        }
        
        private static DateTime? IfTimeNull(string? str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }

            return Convert.ToDateTime(str);
        }
    }
}