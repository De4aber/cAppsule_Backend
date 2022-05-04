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
            _ctx.Users.Add(new UserEntity() {Username = "Ove", CapScore = 3});
            _ctx.Users.Add(new UserEntity() {Username = "Bobo", CapScore = 70});
            _ctx.Users.Add(new UserEntity() {Username = "Kirsten", CapScore = 130});
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
    }
}