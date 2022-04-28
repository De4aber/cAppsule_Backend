using System.Collections.Generic;
using cAppsule;

namespace de4aber.cAppsule.Domain.IRepositories
{
    public interface IUserRepository
    {
        public List<User> FindAll();
    }
}