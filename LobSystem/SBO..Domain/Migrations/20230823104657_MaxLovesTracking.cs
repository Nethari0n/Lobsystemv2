using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorApp1.Server.Migrations
{
    /// <inheritdoc />
    public partial class MaxLovesTracking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4f625560-ccfa-4655-82a9-c9bcfe9566d5", "0b471a65-11da-4d2c-9e72-fce7de17638f", "User", "USER" },
                    { "8e9f3987-e4d9-47c2-b465-9919e0c206c7", "6f6c68e9-0d18-460c-bb6a-7df4fe5241b4", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SendEmergencyHelp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f36433a2-bbe5-45c5-af5d-747204c7978e", 0, "87fdec86-2d9c-4d80-8b41-4ee02d0d072d", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "OLEDF", "AQAAAAIAAYagAAAAELeF5wxKdnVTDsCzDHaiKCyUq7O66fAqhyZPI7SUl3wtS+vmRDvYdJ+JR6x97aeSJQ==", "88888888", true, "3MGMRVY3L6INIULL47JSPA6HWVPWUEIQ", "HelpReciecv", false, "oledf" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8e9f3987-e4d9-47c2-b465-9919e0c206c7", "f36433a2-bbe5-45c5-af5d-747204c7978e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f625560-ccfa-4655-82a9-c9bcfe9566d5");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8e9f3987-e4d9-47c2-b465-9919e0c206c7", "f36433a2-bbe5-45c5-af5d-747204c7978e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e9f3987-e4d9-47c2-b465-9919e0c206c7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f36433a2-bbe5-45c5-af5d-747204c7978e");
        }
    }
}
