using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Bizlounge.Data.Migrations
{
    public partial class AddUserRefToOtherDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Slot",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProjectOwnerId",
                table: "Project",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPayout",
                table: "Project",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "PayeeId",
                table: "Payment",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PayerId",
                table: "Payment",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Slot_UserId",
                table: "Slot",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ProjectOwnerId",
                table: "Project",
                column: "ProjectOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_PayeeId",
                table: "Payment",
                column: "PayeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_PayerId",
                table: "Payment",
                column: "PayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_AspNetUsers_PayeeId",
                table: "Payment",
                column: "PayeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_AspNetUsers_PayerId",
                table: "Payment",
                column: "PayerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_AspNetUsers_ProjectOwnerId",
                table: "Project",
                column: "ProjectOwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Slot_AspNetUsers_UserId",
                table: "Slot",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_AspNetUsers_PayeeId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_AspNetUsers_PayerId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_AspNetUsers_ProjectOwnerId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Slot_AspNetUsers_UserId",
                table: "Slot");

            migrationBuilder.DropIndex(
                name: "IX_Slot_UserId",
                table: "Slot");

            migrationBuilder.DropIndex(
                name: "IX_Project_ProjectOwnerId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Payment_PayeeId",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_PayerId",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "TotalPayout",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "PayerId",
                table: "Payment");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Slot",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProjectOwnerId",
                table: "Project",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PayeeId",
                table: "Payment",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
