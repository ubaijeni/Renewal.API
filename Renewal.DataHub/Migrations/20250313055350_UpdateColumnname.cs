using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Renewal.DataHub.Migrations
{
    /// <inheritdoc />
    public partial class UpdateColumnname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trans_Renewalset_RENEWALID",
                table: "Trans");

            migrationBuilder.DropColumn(
                name: "TRENEWALID",
                table: "Trans");

            migrationBuilder.AlterColumn<Guid>(
                name: "RENEWALID",
                table: "Trans",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Trans_Renewalset_RENEWALID",
                table: "Trans",
                column: "RENEWALID",
                principalTable: "Renewalset",
                principalColumn: "RENEWALID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trans_Renewalset_RENEWALID",
                table: "Trans");

            migrationBuilder.AlterColumn<Guid>(
                name: "RENEWALID",
                table: "Trans",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TRENEWALID",
                table: "Trans",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Trans_Renewalset_RENEWALID",
                table: "Trans",
                column: "RENEWALID",
                principalTable: "Renewalset",
                principalColumn: "RENEWALID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
