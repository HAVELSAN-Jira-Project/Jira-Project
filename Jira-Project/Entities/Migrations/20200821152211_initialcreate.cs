using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Entities.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bugs",
                columns: table => new
                {
                    BugID = table.Column<string>(nullable: false),
                    Summary = table.Column<string>(nullable: false),
                    Creator = table.Column<string>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    Severity = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bugs", x => x.BugID);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    LogID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BugID = table.Column<string>(nullable: false),
                    Author = table.Column<string>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Field = table.Column<string>(nullable: false),
                    FromString = table.Column<string>(nullable: false),
                    toString = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.LogID);
                    table.ForeignKey(
                        name: "FK_Logs_Bugs_BugID",
                        column: x => x.BugID,
                        principalTable: "Bugs",
                        principalColumn: "BugID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Logs_BugID",
                table: "Logs",
                column: "BugID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Bugs");
        }
    }
}
