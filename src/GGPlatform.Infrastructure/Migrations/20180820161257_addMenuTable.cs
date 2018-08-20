using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GGPlatform.Infrastructure.Migrations
{
    public partial class addMenuTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    LastUpdateTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Url = table.Column<string>(nullable: true),
                    Iocn = table.Column<string>(maxLength: 50, nullable: false),
                    ParentID = table.Column<long>(nullable: false, defaultValue: 0L),
                    IsDelete = table.Column<byte>(nullable: false, defaultValue: (byte)0),
                    IsShow = table.Column<byte>(nullable: false, defaultValue: (byte)0),
                    Targets = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    LastUpdateTime = table.Column<DateTime>(nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Genders = table.Column<int>(nullable: false),
                    IsEnabled = table.Column<int>(nullable: false),
                    LoginCount = table.Column<int>(nullable: false, defaultValue: 0),
                    LookCount = table.Column<int>(nullable: false),
                    LookTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Age", "CreateTime", "Genders", "IsEnabled", "LastUpdateTime", "LoginCount", "LookCount", "LookTime", "Password", "UserName" },
                values: new object[,]
                {
                    { 3552129114590674944L, 31, new DateTime(2018, 8, 21, 0, 12, 57, 196, DateTimeKind.Local), 1, 0, new DateTime(2018, 8, 21, 0, 12, 57, 196, DateTimeKind.Local), 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "123456", "ZhangSan" },
                    { 3552129114682949632L, 21, new DateTime(2018, 8, 21, 0, 12, 57, 197, DateTimeKind.Local), 2, 0, new DateTime(2018, 8, 21, 0, 12, 57, 197, DateTimeKind.Local), 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "123456", "LiLi" },
                    { 3552129114682949633L, 18, new DateTime(2018, 8, 21, 0, 12, 57, 197, DateTimeKind.Local), 1, 0, new DateTime(2018, 8, 21, 0, 12, 57, 197, DateTimeKind.Local), 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "123456", "WangWu" },
                    { 3552129114682949634L, 25, new DateTime(2018, 8, 21, 0, 12, 57, 197, DateTimeKind.Local), 1, 0, new DateTime(2018, 8, 21, 0, 12, 57, 197, DateTimeKind.Local), 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "123456", "Cook" },
                    { 3552129114682949635L, 25, new DateTime(2018, 8, 21, 0, 12, 57, 197, DateTimeKind.Local), 2, 0, new DateTime(2018, 8, 21, 0, 12, 57, 197, DateTimeKind.Local), 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "123456", "XiaoLi" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
