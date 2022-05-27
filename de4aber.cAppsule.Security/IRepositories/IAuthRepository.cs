using System.Collections.Generic;
using de4aber.cAppsule.Security.Entities;
using de4aber.cAppsule.Security.Models;
using Microsoft.AspNetCore.Mvc;

namespace de4aber.cAppsule.Security.IRepositories
{
    public interface IAuthRepository
    {
        //public AuthUser FindByUsernameAndPassword(string username, string password);

        AuthUser FindUser(string username);
        void CreateUser(int id, string username, string password);
        List<AuthUserEntity> GetAll();
    }
}