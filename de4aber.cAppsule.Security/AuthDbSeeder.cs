using System;
using System.Text;
using de4aber.cAppsule.Security.Entities;
using de4aber.cAppsule.Security.IServices;

namespace de4aber.cAppsule.Security
{
    public class AuthDbSeeder : IAuthDbSeeder
    {
        private readonly AuthDbContext _ctx;
        private readonly ISecurityService _securityService;

        public AuthDbSeeder(AuthDbContext authDbContext, ISecurityService securityService)
        {
            _ctx = authDbContext;
            _securityService = securityService;
        }

        public void SeedDevelopment()
        {
            _ctx.Database.EnsureDeleted();
            _ctx.Database.EnsureCreated();

            var salt = "123#!";
            _ctx.AuthUsers.Add(new AuthUserEntity()
            {
                Username = "Knud",
                Salt = salt,
                HashedPassword = _securityService.HashedPassword("123456", Encoding.ASCII.GetBytes(salt)),
                EmployeeId = 1,
            });
            _ctx.SaveChanges();
        }

        public void SeedProduction()
        {
            _ctx.Database.EnsureCreated();
        }
    }
}