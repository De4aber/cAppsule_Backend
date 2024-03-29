﻿using de4aber.cAppsule.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace de4aber.cAppsule.DataAccess
{
    public class MainDbContext : DbContext
    {
        
        public MainDbContext(DbContextOptions<MainDbContext> options): base(options)
        {
            
        }
        
        public virtual DbSet<UserEntity> Users { get; set; }
        public virtual DbSet<FriendshipEntity> Friendships { get; set; }
        public virtual DbSet<CapsuleEntity> Cappsules { get; set; }

    }  
}

