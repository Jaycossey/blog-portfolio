using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogPortfolio.Migrations
{
    /// <inheritdoc />
    public partial class ProjectsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    FeaturedImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    TechStack = table.Column<string>(type: "TEXT", nullable: false),
                    GitHubUrl = table.Column<string>(type: "TEXT", nullable: false),
                    DeployedUrl = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
