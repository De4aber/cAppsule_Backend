using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using cAppsule;
using de4aber.cAppsule.Core.DTOs;
using de4aber.cAppsule.Core.IServices;
using de4aber.cAppsule.Domain.IRepositories;

namespace de4aber.cAppsule.Domain.Service
{
    public class FriendshipService : IFriendshipService
    {
        
        private readonly IFriendshipRepository _friendshipRepository;
        private readonly IUserRepository _userRepository;

        public FriendshipService(IFriendshipRepository friendshipRepository, IUserRepository userRepository)
        {
            _friendshipRepository = friendshipRepository ?? throw new InvalidDataException("Repository cannot be null");
            _userRepository = userRepository ?? throw new InvalidDataException("Repository cannot be null");
        }

        public List<FriendshipDTO> FindAll()
        {
            return _friendshipRepository.FindAll().Select(f=> new FriendshipDTO()
            {
                Username1 = _userRepository.ReadById(Convert.ToInt32(f.UserIdRequesting)).Username,
                Username2 = _userRepository.ReadById(Convert.ToInt32(f.UserIdRequested)).Username,
                Accepted = f.Accepted
            }).ToList();
        }

        public List<UserDTO> FindByUserId(int userId)
        {
            var friendList = _friendshipRepository.FindByUserId(userId);
            List<UserDTO> userDtos = new List<UserDTO>();
            foreach (Friendship friendship in friendList)
            {
                if (Int32.Parse(friendship.UserIdRequested) != userId)
                {
                    userDtos.Add(new UserDTO()
                    {
                        username = _userRepository.ReadById(Convert.ToInt32(friendship.UserIdRequested)).Username,
                        capScore = Convert.ToInt32(_userRepository.ReadById(Convert.ToInt32(friendship.UserIdRequested)).CapScore)
                    });
                }
                else
                {
                    userDtos.Add(new UserDTO()
                    {
                        username = _userRepository.ReadById(Convert.ToInt32(friendship.UserIdRequesting)).Username,
                        capScore = Convert.ToInt32(_userRepository.ReadById(Convert.ToInt32(friendship.UserIdRequesting)).CapScore)
                    });
                }
            }

            return userDtos;
        }
    }
}