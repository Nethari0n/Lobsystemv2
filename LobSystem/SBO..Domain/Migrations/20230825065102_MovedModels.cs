using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp1.Server.Migrations
{
    /// <inheritdoc />
    public partial class MovedModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SendEmergencyHelp",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Chips",
                columns: table => new
                {
                    ChipID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LaanerID = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChangeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Aktive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chips", x => x.ChipID);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupID);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    TypesID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Multiplyer = table.Column<int>(type: "int", nullable: false),
                    MultipleRounds = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.TypesID);
                });

            migrationBuilder.CreateTable(
                name: "ChipGroups",
                columns: table => new
                {
                    ChipGroupID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChipID = table.Column<int>(type: "int", nullable: false),
                    GroupID = table.Column<int>(type: "int", nullable: false),
                    EventID = table.Column<int>(type: "int", nullable: false),
                    GroupNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChipGroups", x => x.ChipGroupID);
                    table.ForeignKey(
                        name: "FK_ChipGroups_Chips_ChipID",
                        column: x => x.ChipID,
                        principalTable: "Chips",
                        principalColumn: "ChipID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChipGroups_Groups_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Groups",
                        principalColumn: "GroupID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false),
                    Chips = table.Column<int>(type: "int", nullable: false),
                    CooldownTimer = table.Column<int>(type: "int", nullable: false),
                    TypesID = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventID);
                    table.ForeignKey(
                        name: "FK_Events_Types_TypesID",
                        column: x => x.TypesID,
                        principalTable: "Types",
                        principalColumn: "TypesID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventID = table.Column<int>(type: "int", nullable: false),
                    Multiplyer = table.Column<int>(type: "int", nullable: false),
                    Distance = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    PostNum = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostID);
                    table.ForeignKey(
                        name: "FK_Posts_Events_EventID",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    RegistrationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChipID = table.Column<int>(type: "int", nullable: false),
                    EventID = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => x.RegistrationID);
                    table.ForeignKey(
                        name: "FK_Registrations_Chips_ChipID",
                        column: x => x.ChipID,
                        principalTable: "Chips",
                        principalColumn: "ChipID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registrations_Events_EventID",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Scannings",
                columns: table => new
                {
                    ScanningID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChipID = table.Column<int>(type: "int", nullable: false),
                    PostID = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scannings", x => x.ScanningID);
                    table.ForeignKey(
                        name: "FK_Scannings_Chips_ChipID",
                        column: x => x.ChipID,
                        principalTable: "Chips",
                        principalColumn: "ChipID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Scannings_Posts_PostID",
                        column: x => x.PostID,
                        principalTable: "Posts",
                        principalColumn: "PostID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f36433a2-bbe5-45c5-af5d-747204c7978e",
                columns: new[] { "IsDeleted", "Name", "PasswordHash" },
                values: new object[] { false, null, "AQAAAAIAAYagAAAAEFm0Z+IMZdwunW/PtzG0Ob8s10fm51NdK4S43/dCtOAgTosorzXF8ZoWGSr9pQ+DVQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_ChipGroups_ChipID",
                table: "ChipGroups",
                column: "ChipID");

            migrationBuilder.CreateIndex(
                name: "IX_ChipGroups_GroupID",
                table: "ChipGroups",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Events_TypesID",
                table: "Events",
                column: "TypesID");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_EventID",
                table: "Posts",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_ChipID",
                table: "Registrations",
                column: "ChipID");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_EventID",
                table: "Registrations",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_Scannings_ChipID",
                table: "Scannings",
                column: "ChipID");

            migrationBuilder.CreateIndex(
                name: "IX_Scannings_PostID",
                table: "Scannings",
                column: "PostID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChipGroups");

            migrationBuilder.DropTable(
                name: "Registrations");

            migrationBuilder.DropTable(
                name: "Scannings");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Chips");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "SendEmergencyHelp",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f36433a2-bbe5-45c5-af5d-747204c7978e",
                columns: new[] { "PasswordHash", "SendEmergencyHelp" },
                values: new object[] { "AQAAAAIAAYagAAAAELeF5wxKdnVTDsCzDHaiKCyUq7O66fAqhyZPI7SUl3wtS+vmRDvYdJ+JR6x97aeSJQ==", "HelpReciecv" });
        }
    }
}
