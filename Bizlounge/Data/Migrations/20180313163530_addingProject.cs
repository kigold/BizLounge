using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Bizlounge.Data.Migrations
{
    public partial class addingProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bonus = table.Column<decimal>(nullable: false),
                    Budget = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Duration = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PaybackAmount = table.Column<decimal>(nullable: false),
                    PaybackCycleCount = table.Column<int>(nullable: false),
                    PaybackInterval = table.Column<int>(nullable: false),
                    ProjectOwner = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
