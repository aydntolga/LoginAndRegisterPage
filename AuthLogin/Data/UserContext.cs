﻿using AuthLogin.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthLogin.Data
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions<UserContext> options): base(options) 
        {
            
        }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<User>(entity => { entity.HasIndex(e => e.Email).IsUnique(); });
        }
    }
}
