using System.Collections.Generic;
using de4aber.cAppsule.Security.Entities;
using de4aber.cAppsule.Security.Models;
using Microsoft.AspNetCore.Mvc;

namespace de4aber.cAppsule.Security.IServices
{
    public interface IAuthService
    {
        public AuthUser GetUser(string username);
        void Create(int id, string username, string password);
        ActionResult<List<AuthUserEntity>> GetAll();
    }
}