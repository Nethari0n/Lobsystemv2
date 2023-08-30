using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorApp1.Server.Migrations
{
    /// <inheritdoc />
    public partial class MoreSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f36433a2-bbe5-45c5-af5d-747204c7978e",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEK2Fli2IgE4JvhDVtg+c4kwPMmFQ9kE23q3PTwe1AoGOemR7Xq7O3ncSK9g/nH/tMQ==");

            migrationBuilder.InsertData(
                table: "Chips",
                columns: new[] { "ChipID", "Aktive", "ChangeDate", "CreateDate", "LaanerID", "UID" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2023, 8, 30, 8, 53, 13, 617, DateTimeKind.Local).AddTicks(6470), new DateTime(2023, 8, 30, 8, 53, 13, 617, DateTimeKind.Local).AddTicks(6525), "123", "0002592549" },
                    { 2, true, new DateTime(2023, 8, 30, 8, 53, 13, 617, DateTimeKind.Local).AddTicks(6528), new DateTime(2023, 8, 30, 8, 53, 13, 617, DateTimeKind.Local).AddTicks(6530), "456", "0002616098" }
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "TypesID", "IsDeleted", "MultipleRounds", "Multiplyer", "TypeName" },
                values: new object[] { 1, false, false, 0, "typetest" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventID", "Chips", "CooldownTimer", "CreateDate", "Description", "EndDate", "EventName", "IsDeleted", "StartDate", "TypesID", "Username" },
                values: new object[] { 1, 0, 30, new DateTime(2023, 8, 30, 8, 53, 13, 617, DateTimeKind.Local).AddTicks(6555), "bla bla", new DateTime(2023, 9, 4, 8, 53, 13, 617, DateTimeKind.Local).AddTicks(6549), "Test1", false, new DateTime(2023, 8, 30, 8, 53, 13, 617, DateTimeKind.Local).AddTicks(6553), 1, "Ole" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostID", "Distance", "EventID", "IsDeleted", "Multiplyer", "PostNum" },
                values: new object[] { 1, 500, 1, false, 0, 1 });

            migrationBuilder.InsertData(
                table: "Registrations",
                columns: new[] { "RegistrationID", "ChipID", "CreateDate", "EventID" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 8, 30, 8, 53, 13, 617, DateTimeKind.Local).AddTicks(6597), 1 },
                    { 2, 2, new DateTime(2023, 8, 30, 8, 53, 13, 617, DateTimeKind.Local).AddTicks(6599), 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Registrations",
                keyColumn: "RegistrationID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Registrations",
                keyColumn: "RegistrationID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Chips",
                keyColumn: "ChipID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Chips",
                keyColumn: "ChipID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "TypesID",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f36433a2-bbe5-45c5-af5d-747204c7978e",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEF9xqqvWQ/x1T86MZ79RbGRqpvOTH8Kb+0wvCnyxccFEsjqdKKRv6JdYBYanA8rMRw==");
        }
    }
}
