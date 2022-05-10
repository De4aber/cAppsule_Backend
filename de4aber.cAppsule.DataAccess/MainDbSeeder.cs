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
            _ctx.Users.Add(new UserEntity() {Username = "Ove", CapScore = 3, Password = "hej", BirthDate = DateTime.Now.ToString()});
            _ctx.Users.Add(new UserEntity() {Username = "Bobo", CapScore = 70, Password = "hej", BirthDate = DateTime.Now.ToString()});
            _ctx.Users.Add(new UserEntity() {Username = "Kirsten", CapScore = 130, Password = "hej", BirthDate = DateTime.Now.ToString()});
            _ctx.Users.Add(new UserEntity() {Username = "Bertramowitche", CapScore = 13120, Password = "hej", BirthDate = DateTime.Now.ToString()});
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
        }

        private void AddMockDataCappsules()
        {
            _ctx.Cappsules.Add(new CappsuleEntity()
            {
                id = 0,
                image = new Photo()
                {
                    Id = 0,
                    Bytes = Array.Empty<byte>(),
                    Description = "test",
                    FileExtension = ".png",
                    Size = 0
                },
                lattitude = 0,
                longitute = 0,
                openTime = DateTime.Now.ToString(),
                reciever = 3,
                sender = 1
            });
        }
    }
}