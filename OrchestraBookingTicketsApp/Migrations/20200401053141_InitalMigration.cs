using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrchestraBookingTicketsApp.Migrations
{
    public partial class InitalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "OrchestraHistories",
                columns: table => new
                {
                    OrchestraHistoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<string>(nullable: true),
                    SeatNumber = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    UsersUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrchestraHistories", x => x.OrchestraHistoryId);
                    table.ForeignKey(
                        name: "FK_OrchestraHistories_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orchestras",
                columns: table => new
                {
                    OrchestraId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    OrchestraHistoriesOrchestraHistoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orchestras", x => x.OrchestraId);
                    table.ForeignKey(
                        name: "FK_Orchestras_OrchestraHistories_OrchestraHistoriesOrchestraHistoryId",
                        column: x => x.OrchestraHistoriesOrchestraHistoryId,
                        principalTable: "OrchestraHistories",
                        principalColumn: "OrchestraHistoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Instruments",
                columns: table => new
                {
                    InstrumentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    OrchestraId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instruments", x => x.InstrumentId);
                    table.ForeignKey(
                        name: "FK_Instruments_Orchestras_OrchestraId",
                        column: x => x.OrchestraId,
                        principalTable: "Orchestras",
                        principalColumn: "OrchestraId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeadArtists",
                columns: table => new
                {
                    LeadArtistId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    OrchestraId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadArtists", x => x.LeadArtistId);
                    table.ForeignKey(
                        name: "FK_LeadArtists_Orchestras_OrchestraId",
                        column: x => x.OrchestraId,
                        principalTable: "Orchestras",
                        principalColumn: "OrchestraId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    OrchestraId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_Locations_Orchestras_OrchestraId",
                        column: x => x.OrchestraId,
                        principalTable: "Orchestras",
                        principalColumn: "OrchestraId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Awards",
                columns: table => new
                {
                    AwardId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    LeadArtistId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Awards", x => x.AwardId);
                    table.ForeignKey(
                        name: "FK_Awards_LeadArtists_LeadArtistId",
                        column: x => x.LeadArtistId,
                        principalTable: "LeadArtists",
                        principalColumn: "LeadArtistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BuildingFacilities",
                columns: table => new
                {
                    BuildingFacilitiesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaxSeats = table.Column<int>(nullable: false),
                    HasAirConditioning = table.Column<bool>(nullable: false),
                    HasSmokingArea = table.Column<bool>(nullable: false),
                    LocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingFacilities", x => x.BuildingFacilitiesId);
                    table.ForeignKey(
                        name: "FK_BuildingFacilities_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Awards_LeadArtistId",
                table: "Awards",
                column: "LeadArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingFacilities_LocationId",
                table: "BuildingFacilities",
                column: "LocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Instruments_OrchestraId",
                table: "Instruments",
                column: "OrchestraId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadArtists_OrchestraId",
                table: "LeadArtists",
                column: "OrchestraId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_OrchestraId",
                table: "Locations",
                column: "OrchestraId");

            migrationBuilder.CreateIndex(
                name: "IX_OrchestraHistories_UsersUserId",
                table: "OrchestraHistories",
                column: "UsersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orchestras_OrchestraHistoriesOrchestraHistoryId",
                table: "Orchestras",
                column: "OrchestraHistoriesOrchestraHistoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Awards");

            migrationBuilder.DropTable(
                name: "BuildingFacilities");

            migrationBuilder.DropTable(
                name: "Instruments");

            migrationBuilder.DropTable(
                name: "LeadArtists");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Orchestras");

            migrationBuilder.DropTable(
                name: "OrchestraHistories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
