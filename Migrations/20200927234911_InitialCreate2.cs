using Microsoft.EntityFrameworkCore.Migrations;

namespace AMScreenInterview.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EngineerJobs",
                table: "EngineerJobs");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EngineerJobs",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EngineerJobs",
                table: "EngineerJobs",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_EngineerJobs_EngineerId",
                table: "EngineerJobs",
                column: "EngineerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EngineerJobs",
                table: "EngineerJobs");

            migrationBuilder.DropIndex(
                name: "IX_EngineerJobs_EngineerId",
                table: "EngineerJobs");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EngineerJobs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EngineerJobs",
                table: "EngineerJobs",
                columns: new[] { "EngineerId", "IssueId" });
        }
    }
}
