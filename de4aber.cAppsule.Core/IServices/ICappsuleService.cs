using System.Collections.Generic;
using de4aber.cAppsule.Core.Models;

namespace de4aber.cAppsule.Core.IServices
{
    public interface ICappsuleService
    {
        public Cappsule createCappsule(Cappsule cappsule);
        public List<Cappsule> getCappsules(int userId);
        public void deleteCappsules(int cappsuleId);
    }
}