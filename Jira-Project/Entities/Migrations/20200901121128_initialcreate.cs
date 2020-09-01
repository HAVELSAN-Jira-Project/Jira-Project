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
                name: "JiraIssues",
                columns: table => new
                {
                    IssueID = table.Column<string>(nullable: false),
                    Summary = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    Severity = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JiraIssues", x => x.IssueID);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    LogID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IssueID = table.Column<string>(nullable: false),
                    LogType = table.Column<string>(nullable: false),
                    Author = table.Column<string>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Field = table.Column<string>(nullable: true),
                    FromString = table.Column<string>(nullable: true),
                    toString = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.LogID);
                    table.ForeignKey(
                        name: "FK_Logs_JiraIssues_IssueID",
                        column: x => x.IssueID,
                        principalTable: "JiraIssues",
                        principalColumn: "IssueID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Logs_IssueID",
                table: "Logs",
                column: "IssueID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "JiraIssues");
        }
    }
}
