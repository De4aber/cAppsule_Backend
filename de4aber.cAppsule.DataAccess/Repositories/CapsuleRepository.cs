using System.Collections.Generic;
using System.IO;
using System.Linq;
using de4aber.cAppsule.Core.Models;
using de4aber.cAppsule.DataAccess.Entities;
using de4aber.cAppsule.Domain.IRepositories;

namespace de4aber.cAppsule.DataAccess.Repositories
{
    public class CapsuleRepository : ICapsuleRepository
    {
        private readonly MainDbContext _ctx;

        public CapsuleRepository(MainDbContext ctx)
        {
            _ctx = ctx ?? throw new InvalidDataException("CapsuleRepository need a DBcontext");
        }

        public List<Capsule> FindAll()
        {
            return _ctx.Cappsules.Select(c => c.ToCapsule()).ToList();
        }

        public Capsule Create(Capsule capsule)
        {
            CapsuleEntity capsuleEntity = _ctx.Cappsules.Add(new CapsuleEntity(capsule)).Entity;
            _ctx.SaveChanges();
            return capsuleEntity.ToCapsule();
        }
    }
}