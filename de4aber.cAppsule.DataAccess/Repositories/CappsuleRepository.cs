using System.Collections.Generic;
using System.IO;
using System.Linq;
using de4aber.cAppsule.Core.Models;
using de4aber.cAppsule.Domain.IRepositories;

namespace de4aber.cAppsule.DataAccess.Repositories
{
    public class CappsuleRepository : ICappsuleRepository
    {
        private readonly MainDbContext _ctx;

        public CappsuleRepository(MainDbContext ctx)
        {
            _ctx = ctx ?? throw new InvalidDataException("Database context cannot be NULL");
        }
        
        public Cappsule createCappsule(Cappsule cappsule)
        {
            throw new System.NotImplementedException();
        }

        public List<Cappsule> getCappsules(int userId)
        {
            return _ctx.Cappsules.Select(c => c.toCappsule()).ToList();
        }

        public void deleteCappsule(int cappsuleId)
        {
            throw new System.NotImplementedException();
        }
    }
}