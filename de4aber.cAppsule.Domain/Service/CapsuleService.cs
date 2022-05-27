using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using de4aber.cAppsule.Core.DTOs;
using de4aber.cAppsule.Core.IServices;
using de4aber.cAppsule.Core.Models;
using de4aber.cAppsule.Domain.IRepositories;
using Microsoft.AspNetCore.Mvc;

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

        public List<ReceiveCapsuleDTO> GetByReceiverId(int receiverId)
        {
            return _capsuleRepository.FindByReceiverId(receiverId).Select(c => new ReceiveCapsuleDTO(c.Id, _userRepository.ReadById(c.SenderId).Username)
            {
                Message = c.Message,
                Latitude = c.Latitude,
                Longitude = c.Longitude,
                Time = c.Time.ToString(),
                Photo = c.Photo,
            }).ToList();
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

        public ReceiveCapsuleDTO GetById(int capsuleId)
        {
            var c = _capsuleRepository.ReadById(capsuleId);
            return new ReceiveCapsuleDTO(c.Id, _userRepository.ReadById(c.SenderId).Username)
            {
                Message = c.Message,
                Latitude = c.Latitude,
                Longitude = c.Longitude,
                Time = c.Time.ToString(),
                Photo = c.Photo,
            };
        }

        private static DateTime? IfTimeNull(string? str)
        {
            if (string.IsNullOrEmpty(str) || str.StartsWith("null"))
            {
                return null;
            }

            return Convert.ToDateTime(str);
        }
    }
}