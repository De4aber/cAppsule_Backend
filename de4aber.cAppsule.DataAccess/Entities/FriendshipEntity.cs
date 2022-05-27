using System;
using cAppsule;
using de4aber.cAppsule.DataAccess.Repositories;

namespace de4aber.cAppsule.DataAccess.Entities
{
    public class FriendshipEntity
    {
        public int Id { get; set; }
        public int UserIdRequesting { get; set; }
        public int UserIdRequested { get; set; }
        public bool Accepted { get; set; } = false;

        public FriendshipEntity(Friendship friendship)
        {
            Id = friendship.Id;
            UserIdRequesting= friendship.UserIdRequesting;
            UserIdRequested = friendship.UserIdRequested;
            Accepted = friendship.Accepted;
        }
        
        public Friendship ToFriendship()
        {
            return new Friendship()
            {
                Id = Id,
                UserIdRequesting = UserIdRequesting,
                UserIdRequested = UserIdRequested,
                Accepted = Accepted
            };
        }

        public FriendshipEntity()
        {
        }
    }
}