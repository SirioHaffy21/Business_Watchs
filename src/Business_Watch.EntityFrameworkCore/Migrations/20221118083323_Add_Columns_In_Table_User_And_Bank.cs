using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Business_Watch.Migrations
{
    public partial class Add_Columns_In_Table_User_And_Bank : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BankId",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Bank",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Bank_Name = table.Column<string>(nullable: true),
                    NumberBank = table.Column<string>(nullable: true),
                    Category_BankAccount = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_BankId",
                table: "AbpUsers",
                column: "BankId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_Bank_BankId",
                table: "AbpUsers",
                column: "BankId",
                principalTable: "Bank",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_Bank_BankId",
                table: "AbpUsers");

            migrationBuilder.DropTable(
                name: "Bank");

            migrationBuilder.DropIndex(
                name: "IX_AbpUsers_BankId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "BankId",
                table: "AbpUsers");
        }
    }
}
