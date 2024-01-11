using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp1.Server.Migrations
{
    /// <inheritdoc />
    public partial class NewRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "School",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f625560-ccfa-4655-82a9-c9bcfe9566d5",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Oksbøl Friskole", "OKSBØL FRISKOLE" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e9f3987-e4d9-47c2-b465-9919e0c206c7",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Dybbøl Skole", "DYBBØL SKOLE" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f36433a2-bbe5-45c5-af5d-747204c7978e",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEMOR8Rqsj/V6Widtq8A3lfzhaAaU8LEBeQ8Sqm3TdiWtpZiPR0o6w5wfqMIFN4rSjQ==");

            migrationBuilder.UpdateData(
                table: "Chips",
                keyColumn: "ChipID",
                keyValue: 1,
                columns: new[] { "ChangeDate", "CreateDate" },
                values: new object[] { new DateTime(2024, 1, 9, 11, 1, 37, 525, DateTimeKind.Local).AddTicks(2809), new DateTime(2024, 1, 9, 11, 1, 37, 525, DateTimeKind.Local).AddTicks(2865) });

            migrationBuilder.UpdateData(
                table: "Chips",
                keyColumn: "ChipID",
                keyValue: 2,
                columns: new[] { "ChangeDate", "CreateDate" },
                values: new object[] { new DateTime(2024, 1, 9, 11, 1, 37, 525, DateTimeKind.Local).AddTicks(2869), new DateTime(2024, 1, 9, 11, 1, 37, 525, DateTimeKind.Local).AddTicks(2871) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventID",
                keyValue: 1,
                columns: new[] { "CreateDate", "EndDate", "School", "StartDate" },
                values: new object[] { new DateTime(2024, 1, 9, 11, 1, 37, 525, DateTimeKind.Local).AddTicks(2899), new DateTime(2024, 1, 14, 11, 1, 37, 525, DateTimeKind.Local).AddTicks(2893), "Dybbøl", new DateTime(2024, 1, 9, 11, 1, 37, 525, DateTimeKind.Local).AddTicks(2897) });

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumn: "RegistrationID",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 1, 9, 11, 1, 37, 525, DateTimeKind.Local).AddTicks(2938));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumn: "RegistrationID",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 1, 9, 11, 1, 37, 525, DateTimeKind.Local).AddTicks(2941));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "School",
                table: "Events");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f625560-ccfa-4655-82a9-c9bcfe9566d5",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e9f3987-e4d9-47c2-b465-9919e0c206c7",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Admin", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f36433a2-bbe5-45c5-af5d-747204c7978e",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEK2Fli2IgE4JvhDVtg+c4kwPMmFQ9kE23q3PTwe1AoGOemR7Xq7O3ncSK9g/nH/tMQ==");

            migrationBuilder.UpdateData(
                table: "Chips",
                keyColumn: "ChipID",
                keyValue: 1,
                columns: new[] { "ChangeDate", "CreateDate" },
                values: new object[] { new DateTime(2023, 8, 30, 8, 53, 13, 617, DateTimeKind.Local).AddTicks(6470), new DateTime(2023, 8, 30, 8, 53, 13, 617, DateTimeKind.Local).AddTicks(6525) });

            migrationBuilder.UpdateData(
                table: "Chips",
                keyColumn: "ChipID",
                keyValue: 2,
                columns: new[] { "ChangeDate", "CreateDate" },
                values: new object[] { new DateTime(2023, 8, 30, 8, 53, 13, 617, DateTimeKind.Local).AddTicks(6528), new DateTime(2023, 8, 30, 8, 53, 13, 617, DateTimeKind.Local).AddTicks(6530) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventID",
                keyValue: 1,
                columns: new[] { "CreateDate", "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 8, 30, 8, 53, 13, 617, DateTimeKind.Local).AddTicks(6555), new DateTime(2023, 9, 4, 8, 53, 13, 617, DateTimeKind.Local).AddTicks(6549), new DateTime(2023, 8, 30, 8, 53, 13, 617, DateTimeKind.Local).AddTicks(6553) });

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumn: "RegistrationID",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 8, 30, 8, 53, 13, 617, DateTimeKind.Local).AddTicks(6597));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumn: "RegistrationID",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 8, 30, 8, 53, 13, 617, DateTimeKind.Local).AddTicks(6599));
        }
    }
}
