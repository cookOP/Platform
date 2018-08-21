﻿// <auto-generated />
using System;
using GGPlatform.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GGPlatform.Infrastructure.Migrations
{
    [DbContext(typeof(GGPatlformContext))]
    [Migration("20180821132908_updateRoleTableContent")]
    partial class updateRoleTableContent
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("GGPlatoform.Domain.Entity.Menu", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("Iocn")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<byte>("IsDelete")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue((byte)0);

                    b.Property<byte>("IsShow")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue((byte)0);

                    b.Property<DateTime>("LastUpdateTime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<long>("ParentID")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0L);

                    b.Property<int>("Targets");

                    b.Property<string>("Url");

                    b.HasKey("ID");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("GGPlatoform.Domain.Entity.Role", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateTime");

                    b.Property<byte>("IsDelete")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue((byte)0);

                    b.Property<DateTime>("LastUpdateTime");

                    b.Property<string>("MenuPermissionID")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("GGPlatoform.Domain.Entity.User.Users", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<DateTime>("CreateTime");

                    b.Property<int>("Genders");

                    b.Property<int>("IsEnabled");

                    b.Property<DateTime>("LastUpdateTime");

                    b.Property<int>("LoginCount")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<int>("LookCount");

                    b.Property<DateTime>("LookTime");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Users");

                    b.HasData(
                        new { ID = 3552450275438493697L, Age = 31, CreateTime = new DateTime(2018, 8, 21, 21, 29, 8, 19, DateTimeKind.Local), Genders = 1, IsEnabled = 0, LastUpdateTime = new DateTime(2018, 8, 21, 21, 29, 8, 19, DateTimeKind.Local), LoginCount = 0, LookCount = 0, LookTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Password = "123456", UserName = "ZhangSan" },
                        new { ID = 3552450275442688001L, Age = 21, CreateTime = new DateTime(2018, 8, 21, 21, 29, 8, 20, DateTimeKind.Local), Genders = 2, IsEnabled = 0, LastUpdateTime = new DateTime(2018, 8, 21, 21, 29, 8, 20, DateTimeKind.Local), LoginCount = 0, LookCount = 0, LookTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Password = "123456", UserName = "LiLi" },
                        new { ID = 3552450275442688003L, Age = 18, CreateTime = new DateTime(2018, 8, 21, 21, 29, 8, 20, DateTimeKind.Local), Genders = 1, IsEnabled = 0, LastUpdateTime = new DateTime(2018, 8, 21, 21, 29, 8, 20, DateTimeKind.Local), LoginCount = 0, LookCount = 0, LookTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Password = "123456", UserName = "WangWu" },
                        new { ID = 3552450275442688005L, Age = 25, CreateTime = new DateTime(2018, 8, 21, 21, 29, 8, 20, DateTimeKind.Local), Genders = 1, IsEnabled = 0, LastUpdateTime = new DateTime(2018, 8, 21, 21, 29, 8, 20, DateTimeKind.Local), LoginCount = 0, LookCount = 0, LookTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Password = "123456", UserName = "Cook" },
                        new { ID = 3552450275442688007L, Age = 25, CreateTime = new DateTime(2018, 8, 21, 21, 29, 8, 20, DateTimeKind.Local), Genders = 2, IsEnabled = 0, LastUpdateTime = new DateTime(2018, 8, 21, 21, 29, 8, 20, DateTimeKind.Local), LoginCount = 0, LookCount = 0, LookTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Password = "123456", UserName = "XiaoLi" }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}
