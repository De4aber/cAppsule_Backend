using System.Collections.Generic;
using cAppsule;
using de4aber.cAppsule.Core.DTOs;

namespace de4aber.cAppsule.Core.IServices
{
    public interface IFriendshipService
    {
        public List<FriendshipDTO> FindAll();
        public List<UserDTO> FindByUserId(int userId);
    }
}