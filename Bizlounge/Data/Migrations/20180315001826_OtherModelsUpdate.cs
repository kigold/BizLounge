using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Bizlounge.Data.Migrations
{
    public partial class OtherModelsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Project_ProjectId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Slot_Project_ProjectId",
                table: "Slot");

            migrationBuilder.DropColumn(
                name: "Project",
                table: "Slot");

            migrationBuilder.DropColumn(
                name: "Payee",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "Project",
                table: "Payment");

            migrationBuilder.RenameColumn(
                name: "User",
                table: "Slot",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ProjectOwner",
                table: "Project",
                newName: "ProjectOwnerId");

            migrationBuilder.RenameColumn(
                name: "ProjectOwner",
                table: "Payment",
                newName: "PayeerId");

            migrationBuilder.RenameColumn(
                name: "Payeer",
                table: "Payment",
                newName: "PayeeId");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Slot",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Payment",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Project_ProjectId",
                table: "Payment",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Slot_Project_ProjectId",
                table: "Slot",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Project_ProjectId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Slot_Project_ProjectId",
                table: "Slot");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Slot",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "ProjectOwnerId",
                table: "Project",
                newName: "ProjectOwner");

            migrationBuilder.RenameColumn(
                name: "PayeerId",
                table: "Payment",
                newName: "ProjectOwner");

            migrationBuilder.RenameColumn(
                name: "PayeeId",
                table: "Payment",
                newName: "Payeer");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Slot",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Project",
                table: "Slot",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Payment",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Payee",
                table: "Payment",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Project",
                table: "Payment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Project_ProjectId",
                table: "Payment",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Slot_Project_ProjectId",
                table: "Slot",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
