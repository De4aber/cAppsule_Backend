using System.Collections.Generic;
using de4aber.cAppsule.Core.Models;

namespace de4aber.cAppsule.Core.IServices
{
    public interface ICapsuleService
    {
        public List<Capsule> GetAll();
    }
}