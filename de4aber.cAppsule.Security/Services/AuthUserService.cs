using System.Collections.Generic;
using de4aber.cAppsule.Security.Entities;
using de4aber.cAppsule.Security.IRepositories;
using de4aber.cAppsule.Security.IServices;
using de4aber.cAppsule.Security.Models;
using Microsoft.AspNetCore.Mvc;

namespace de4aber.cAppsule.Security.Services
{
    public class AuthUserService: IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthUserService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        
        public AuthUser GetUser(string username)
        {
            return _authRepository.FindUser(username);
        }

        public void Create(int id, string username, string password)
        {
            _authRepository.CreateUser(id, username, password);
        }

        public ActionResult<List<AuthUserEntity>> GetAll()
        {
            return _authRepository.GetAll();
        }
    }
}