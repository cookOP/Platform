using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GGPlatform.Infrastructure.Migrations
{
    public partial class AddUsersTableDefaultData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Age", "CreateTime", "Genders", "IsEnabled", "LastUpdateTime", "LoginCount", "LookCount", "LookTime", "Password", "UserName" },
                values: new object[,]
                {
                    { 3552151734849634305L, 31, new DateTime(2018, 8, 21, 1, 42, 50, 396, DateTimeKind.Local), 1, 0, new DateTime(2018, 8, 21, 1, 42, 50, 396, DateTimeKind.Local), 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "123456", "ZhangSan" },
                    { 3552151734853828609L, 21, new DateTime(2018, 8, 21, 1, 42, 50, 397, DateTimeKind.Local), 2, 0, new DateTime(2018, 8, 21, 1, 42, 50, 397, DateTimeKind.Local), 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "123456", "LiLi" },
                    { 3552151734853828611L, 18, new DateTime(2018, 8, 21, 1, 42, 50, 397, DateTimeKind.Local), 1, 0, new DateTime(2018, 8, 21, 1, 42, 50, 397, DateTimeKind.Local), 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "123456", "WangWu" },
                    { 3552151734853828613L, 25, new DateTime(2018, 8, 21, 1, 42, 50, 397, DateTimeKind.Local), 1, 0, new DateTime(2018, 8, 21, 1, 42, 50, 397, DateTimeKind.Local), 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "123456", "Cook" },
                    { 3552151734853828615L, 25, new DateTime(2018, 8, 21, 1, 42, 50, 397, DateTimeKind.Local), 2, 0, new DateTime(2018, 8, 21, 1, 42, 50, 397, DateTimeKind.Local), 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "123456", "XiaoLi" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 3552151734849634305L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 3552151734853828609L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 3552151734853828611L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 3552151734853828613L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 3552151734853828615L);
        }
    }
}
