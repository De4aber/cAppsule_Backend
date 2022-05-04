using System.Collections.Generic;
using cAppsule;

namespace de4aber.cAppsule.Domain.IRepositories
{
    public interface IFriendshipRepository
    {
        
        public List<Friendship> FindAll();

        public Friendship FindById(int friendshipId);
        public List<Friendship> FindByUserId(int userId);

        public bool DeleteById(int id);
        
        public Friendship Create(Friendship friendship);
        
        public Friendship UpdateFriendship(int id, Friendship friendship);

        public Friendship AcceptFriendRequest(int friendshipId, int acceptingUserId);

    }
}