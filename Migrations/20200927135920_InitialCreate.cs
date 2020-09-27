using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AMScreenInterview.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Engineer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engineer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Issue",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Screen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Postcode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EngineerJobs",
                columns: table => new
                {
                    EngineerId = table.Column<int>(nullable: false),
                    IssueId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngineerJobs", x => new { x.EngineerId, x.IssueId });
                    table.ForeignKey(
                        name: "FK_EngineerJobs_Engineer_EngineerId",
                        column: x => x.EngineerId,
                        principalTable: "Engineer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EngineerJobs_Issue_IssueId",
                        column: x => x.IssueId,
                        principalTable: "Issue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScreenIssues",
                columns: table => new
                {
                    ScreenId = table.Column<int>(nullable: false),
                    IssueId = table.Column<int>(nullable: false),
                    DateReported = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScreenIssues", x => new { x.IssueId, x.ScreenId });
                    table.ForeignKey(
                        name: "FK_ScreenIssues_Issue_IssueId",
                        column: x => x.IssueId,
                        principalTable: "Issue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScreenIssues_Screen_ScreenId",
                        column: x => x.ScreenId,
                        principalTable: "Screen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EngineerJobs_IssueId",
                table: "EngineerJobs",
                column: "IssueId");

            migrationBuilder.CreateIndex(
                name: "IX_ScreenIssues_ScreenId",
                table: "ScreenIssues",
                column: "ScreenId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EngineerJobs");

            migrationBuilder.DropTable(
                name: "ScreenIssues");

            migrationBuilder.DropTable(
                name: "Engineer");

            migrationBuilder.DropTable(
                name: "Issue");

            migrationBuilder.DropTable(
                name: "Screen");
        }
    }
}
