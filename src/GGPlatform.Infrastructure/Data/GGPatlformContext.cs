using GGPlatoform.Domain.Entity.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GGPlatform.Infrastructure.Data
{
  public class GGPatlformContext : DbContext
    {
        public GGPatlformContext(DbContextOptions<GGPatlformContext> options) : base(options) { }
        
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(a =>
            {
                a.HasKey(b => b.ID);
                a.Property(b => b.UserName).HasColumnType("varchar(50)");
                a.Property(b => b.Password).HasColumnType("varchar(50)");              
                
            });
            
           
        }
    }
}
