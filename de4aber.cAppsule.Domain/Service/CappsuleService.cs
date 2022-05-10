using System;
using System.Collections.Generic;
using System.IO;
using de4aber.cAppsule.Core.IServices;
using de4aber.cAppsule.Core.Models;
using de4aber.cAppsule.Domain.IRepositories;

namespace de4aber.cAppsule.Domain.Service
{
    public class CappsuleService : ICappsuleService
    {
        private readonly ICappsuleRepository _repo;

        public CappsuleService(ICappsuleRepository repo)
        {
            _repo = repo ?? throw new InvalidDataException("Repo cannot be null!");
        }
        public Cappsule createCappsule(Cappsule cappsule)
        {
            return _repo.createCappsule(cappsule);
        }

        public List<Cappsule> getCappsules(int userId)
        {
            return _repo.getCappsules(userId);
        }

        public void deleteCappsules(int cappsuleId)
        {
            _repo.deleteCappsule(cappsuleId);
        }
    }
}