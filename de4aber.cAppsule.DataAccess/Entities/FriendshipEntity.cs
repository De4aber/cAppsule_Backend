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
            Id = Convert.ToInt32(friendship.Id);
            UserIdRequesting= Convert.ToInt32(friendship.UserIdRequesting);
            UserIdRequested = Convert.ToInt32(friendship.UserIdRequested);
            Accepted = friendship.Accepted;
        }
        
        public Friendship ToFriendship()
        {
            return new Friendship()
            {
                Id = Id.ToString(),
                UserIdRequesting = UserIdRequesting.ToString(),
                UserIdRequested = UserIdRequested.ToString(),
                Accepted = Accepted
            };
        }

        public FriendshipEntity()
        {
        }
    }
}