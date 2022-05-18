using System.Collections.Generic;
using de4aber.cAppsule.Core.Models;

namespace de4aber.cAppsule.Domain.IRepositories
{
    public interface ICapsuleRepository
    {
        public List<Capsule> FindAll();
    }
}