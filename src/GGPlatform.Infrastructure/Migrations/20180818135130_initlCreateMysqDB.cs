using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GGPlatform.Infrastructure.Migrations
{
    public partial class initlCreateMysqDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    LastUpdateTime = table.Column<DateTime>(nullable: false),
                    UserName = table.Column<string>(type: "varchar(50)", nullable: true),
                    Password = table.Column<string>(type: "varchar(50)", nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Sex = table.Column<int>(nullable: false),
                    IsEnabled = table.Column<int>(nullable: false),
                    LoginCount = table.Column<int>(nullable: false),
                    LookTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
