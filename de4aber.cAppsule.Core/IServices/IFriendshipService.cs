using System.Collections.Generic;
using cAppsule;
using de4aber.cAppsule.Core.DTOs;

namespace de4aber.cAppsule.Core.IServices
{
    public interface IFriendshipService
    {
        public List<Friendship> FindAll();
        public List<FriendDto> FindByUserId(int userId);
        public bool DeleteById(int friendshipId);

        public Friendship Create(Friendship friendship);

        public Friendship Update(int friendShipId, Friendship friendship);
        

        public Friendship RequestFriendship(FriendRequestDto friendRequestDto);

        public Friendship AcceptFriendship(int friendshipId, int acceptingUserId);

    }
}