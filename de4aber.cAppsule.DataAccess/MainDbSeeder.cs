using System;
using System.Linq;
using de4aber.cAppsule.DataAccess.Entities;

namespace de4aber.cAppsule.DataAccess
{
    public class MainDbSeeder : IMainDbSeeder
    {
        
        private readonly MainDbContext _ctx;

        public MainDbSeeder(MainDbContext ctx)
        {
            _ctx = ctx;
        }
        
        public void SeedDevelopment()
        {
            _ctx.Database.EnsureDeleted();
            _ctx.Database.EnsureCreated();
            AddMockDataUser();
            AddMockDataFriendships();
            AddMockDataCappsules();
            _ctx.SaveChanges();
        }

        public void SeedProduction()
        {
            _ctx.Database.EnsureCreated();
            if (!_ctx.Users.Any())
            {
              AddMockDataUser();  
            }
            
            _ctx.SaveChanges();
        }

        private void AddMockDataUser()
        {
            _ctx.Users.Add(new UserEntity() {Username = "Ove", CapScore = 3,  BirthDate = DateTime.Now.ToString()});
            _ctx.Users.Add(new UserEntity() {Username = "Bobo", CapScore = 70,  BirthDate = DateTime.Now.ToString()});
            _ctx.Users.Add(new UserEntity() {Username = "Kirsten", CapScore = 130, BirthDate = DateTime.Now.ToString()});
            _ctx.Users.Add(new UserEntity() {Username = "Bertramowitche", CapScore = 13120, BirthDate = DateTime.Now.ToString()});
        }

        private void AddMockDataFriendships()
        {
            _ctx.Friendships.Add(new FriendshipEntity()
            {
                UserIdRequested = 1,
                UserIdRequesting = 2,
                Accepted = true
            });
            _ctx.Friendships.Add(new FriendshipEntity()
            {
                UserIdRequested = 1,
                UserIdRequesting = 3,
                Accepted = true
            });
            _ctx.Friendships.Add(new FriendshipEntity()
            {
                UserIdRequested = 1,
                UserIdRequesting = 4,
                Accepted = false
            });
        }

        private void AddMockDataCappsules()
        {
            _ctx.Cappsules.Add(new CapsuleEntity()
            {
                SenderId = 1,
                ReceiverId = 3,
                Latitude = 55.46910408813035, 
                Longitude = 8.458843244655215,
                Message = "Esbjerg Banegård",
                Photo = null,
                Time = "2022-05-16T21:54:26"
            });
        }
    }
}