using GGPlatform.Common.Enum;
using GGPlatform.Common.SnowflakeToTwitter;
using GGPlatoform.Domain.Entity;
using GGPlatoform.Domain.Entity.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;

namespace GGPlatform.Infrastructure.Data
{
    public class GGPatlformContext : DbContext
    {
        public GGPatlformContext(DbContextOptions<GGPatlformContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {          
            var gender = new EnumToNumberConverter<Gender, int>();
            modelBuilder.Entity<Users>(a =>
            {
                a.HasKey(b => b.ID);
                a.Property(b => b.UserName).HasMaxLength(50).IsRequired();
                a.Property(b => b.Password).HasMaxLength(50).IsRequired();
                a.Property(b => b.Genders).HasConversion(gender).IsRequired();
                a.Property(b => b.LoginCount).HasDefaultValue(0).IsRequired(); 
                a.Property(b => b.CreateTime);
                a.Property(b => b.LastUpdateTime).IsRequired();
                a.Property(b => b.LoginCount).HasDefaultValue(0);
                a.Property(b => b.LookTime);
            });
            var target = new EnumToNumberConverter<Target, int>();
            modelBuilder.Entity<Menu>(a =>
            {
                a.HasKey(b => b.ID);
                a.Property(b => b.Name).HasMaxLength(50).IsRequired();
                a.Property(b => b.Iocn).HasMaxLength(50).IsRequired();
                a.Property(b => b.Targets).HasConversion(target).IsRequired();
                a.Property(b => b.ParentID).HasDefaultValue(0).IsRequired();
                a.Property(b => b.IsDelete).HasDefaultValue(0).IsRequired();
                a.Property(b => b.IsShow).HasDefaultValue(0).IsRequired();
                a.Property(b => b.CreateTime);
                a.Property(b => b.LastUpdateTime).IsRequired();
               
            });
            modelBuilder.Entity<Role>(a =>
            {
                a.HasKey(b => b.ID);
                a.Property(b => b.Name).HasMaxLength(50).IsRequired();
                a.Property(b => b.MenuPermissionID).IsRequired();
                a.Property(b => b.IsDelete).HasDefaultValue(0).IsRequired();               
                a.Property(b => b.CreateTime).IsRequired();
                a.Property(b => b.LastUpdateTime).IsRequired();

            });
            modelBuilder.Entity<Users>().HasData(
                new Users { ID = Snowflake.Instance().GetId(), UserName = "ZhangSan", Password = "123456", Genders = Gender.Male, CreateTime = DateTime.Now, LastUpdateTime = DateTime.Now, Age = 31, LoginCount = 0 },
                new Users { ID = Snowflake.Instance().GetId(), UserName = "LiLi", Password = "123456", Genders = Gender.Female, CreateTime = DateTime.Now, LastUpdateTime = DateTime.Now, Age = 21, LoginCount = 0 },
                new Users { ID = Snowflake.Instance().GetId(), UserName = "WangWu", Password = "123456", Genders = Gender.Male, CreateTime = DateTime.Now, LastUpdateTime = DateTime.Now, Age = 18, LoginCount = 0 },
                new Users { ID = Snowflake.Instance().GetId(), UserName = "Cook", Password = "123456", Genders = Gender.Male, CreateTime = DateTime.Now, LastUpdateTime = DateTime.Now, Age = 25, LoginCount = 0 },
                new Users { ID = Snowflake.Instance().GetId(), UserName = "XiaoLi", Password = "123456", Genders = Gender.Female, CreateTime = DateTime.Now, LastUpdateTime = DateTime.Now, Age = 25, LoginCount = 0 });
        }
    }
}
