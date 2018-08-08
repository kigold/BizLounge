using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Bizlounge.Data.Migrations
{
    public partial class changedidToID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Slot",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Project",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Payment",
                newName: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Slot",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Project",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Payment",
                newName: "Id");
        }
    }
}
