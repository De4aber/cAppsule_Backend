using System.Collections.Generic;
using de4aber.cAppsule.Core.Models;

namespace de4aber.cAppsule.Domain.IRepositories
{
    public interface ICappsuleRepository
    {
        public Cappsule createCappsule(Cappsule cappsule);
        public List<Cappsule> getCappsules(int userId);
        public void deleteCappsule(int cappsuleId);
    }
}