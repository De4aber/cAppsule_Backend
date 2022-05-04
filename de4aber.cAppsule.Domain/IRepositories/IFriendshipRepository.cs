using System.Collections.Generic;
using cAppsule;

namespace de4aber.cAppsule.Domain.IRepositories
{
    public interface IFriendshipRepository
    {
        
        public List<Friendship> FindAll();
        public List<Friendship> FindByUserId(int userId);
    }
}