using System.Collections.Generic;
using cAppsule;

namespace de4aber.cAppsule.Core.IServices
{
    public interface IUserService
    {
        List<User> GetUsers();
    }
}