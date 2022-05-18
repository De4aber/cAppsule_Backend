using de4aber.cAppsule.Security.Entities;
using Microsoft.EntityFrameworkCore;

namespace de4aber.cAppsule.Security;

public class AuthDbContext : DbContext
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
    {
            
    }

    public DbSet<AuthUserEntity> AuthUsers { get; set; }
}