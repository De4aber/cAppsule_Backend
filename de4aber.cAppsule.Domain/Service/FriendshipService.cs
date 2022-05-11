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

        public List<Friendship> FindAll()
        {
            return _friendshipRepository.FindAll();
        }

        public List<FriendDto> FindByUserId(int userId)
        {
            var friendList = _friendshipRepository.FindByUserId(userId);
            List<FriendDto> userDtos = new List<FriendDto>();
            foreach (Friendship friendship in friendList)
            {
                if (friendship.UserIdRequested != userId)
                {
                    userDtos.Add(new FriendDto()
                    {
                        FriendshipId = friendship.Id,
                        Username = _userRepository.ReadById(friendship.UserIdRequested).Username,
                        CapScore = _userRepository.ReadById(friendship.UserIdRequested).CapScore
                    });
                }
                else
                {
                    userDtos.Add(new FriendDto()
                    {
                        FriendshipId = friendship.Id,
                        Username = _userRepository.ReadById(friendship.UserIdRequesting).Username,
                        CapScore = _userRepository.ReadById(friendship.UserIdRequesting).CapScore
                    });
                }
            }

            return userDtos;
        }

        public List<FriendRequestReceiverDto> FindFriendRequestsByUserId(int userId)
        {
            return _friendshipRepository.FindFriendRequestsByUserId(userId).Select(fr=>
                new FriendRequestReceiverDto
                {
                    FriendshipId = fr.Id,
                    FromUser = _userRepository.ReadById(fr.UserIdRequesting).Username
                    
                }
                ).ToList();
        }

        public bool DeleteById(int friendshipId)
        {
            return _friendshipRepository.DeleteById(friendshipId);
        }

        public Friendship Create(Friendship friendship)
        {
            return _friendshipRepository.Create(friendship);
        }

        public Friendship Update(int friendShipId, Friendship friendship)
        {
            return _friendshipRepository.UpdateFriendship(friendShipId, friendship);
        }

        public bool RequestFriendship(FriendRequestDto friendRequestDto)
        {
            _friendshipRepository.Create(new Friendship()
            {
                UserIdRequesting = friendRequestDto.FromUserId,
                UserIdRequested = _userRepository.FindByUsername(friendRequestDto.ToUsername).Id,
                Accepted = false
            });

            return true;
        }

        public FriendDto AcceptFriendship(int friendshipId, int acceptingUserId)
        {
           var friendship = _friendshipRepository.AcceptFriendRequest(friendshipId, acceptingUserId);
           var newFriend = _userRepository.ReadById(friendship.UserIdRequesting);
           return new FriendDto
           {
               FriendshipId = friendship.Id,
               Username = newFriend.Username,
               CapScore = newFriend.CapScore

           };
        }
        
    }
}