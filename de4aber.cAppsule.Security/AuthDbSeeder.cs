using de4aber.cAppsule.Security.IServices;
using de4aber.cAppsule.Security.Services;

namespace de4aber.cAppsule.Security;

public class AuthDbSeeder : IAuthDbSeeder
{
    private readonly AuthDbContext _ctx;
    private readonly IAuthService _service;
    public AuthDbSeeder(AuthDbContext ctx, IAuthService service)
    {
        _ctx = ctx;
        _service = service;
    }
    public void SeedDevelopment()
    {
        _ctx.Database.EnsureDeleted();
        _ctx.Database.EnsureCreated();
    }

    public void SeedProduction()
    {
        _ctx.Database.EnsureCreated();
    }
}