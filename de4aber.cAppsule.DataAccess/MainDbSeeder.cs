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
        }
    }
}