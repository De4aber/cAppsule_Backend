﻿using System.Collections.Generic;
using de4aber.cAppsule.Core.IServices;
using de4aber.cAppsule.Core.Models;
using de4aber.cAppsule.Domain.IRepositories;

namespace de4aber.cAppsule.Domain.Service
{
    public class CappsuleService : ICappsuleService
    {
        private readonly ICappsuleRepository _repo;
        public Cappsule createCappsule(Cappsule cappsule)
        {
            throw new System.NotImplementedException();
        }

        public List<Cappsule> getCappsules(int userId)
        {
            throw new System.NotImplementedException();
        }

        public void deleteCappsules(int cappsuleId)
        {
            throw new System.NotImplementedException();
        }
    }
}