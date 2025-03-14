using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Renewal.DataHub.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    CLIENTID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CLIENTNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISACTIVE = table.Column<bool>(type: "bit", nullable: true),
                    CREATEDBY = table.Column<int>(type: "int", nullable: true),
                    CREATEDDATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATEDBY = table.Column<int>(type: "int", nullable: true),
                    UPDATEDDATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Suspend = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.CLIENTID);
                });

            migrationBuilder.CreateTable(
                name: "Renewalset",
                columns: table => new
                {
                    RENEWALID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BRANCHID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CATEGORYID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STARTDATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ENDDATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VALIDITY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RENEWALDATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AMOUNT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    REMINDER = table.Column<int>(type: "int", nullable: true),
                    ALERTTO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STATUS = table.Column<int>(type: "int", nullable: true),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: true),
                    CREATEDBY = table.Column<int>(type: "int", nullable: true),
                    CREATEDDATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATEDBY = table.Column<int>(type: "int", nullable: true),
                    UPDATEDDATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SUSPEND = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Renewalset", x => x.RENEWALID);
                });

            migrationBuilder.CreateTable(
                name: "Trans",
                columns: table => new
                {
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TRENEWALID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BRANCHID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CATEGORYID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STARTDATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ENDDATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VALIDITY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RENEWALDATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AMOUNT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    REMINDER = table.Column<int>(type: "int", nullable: true),
                    ALERTTO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STATUS = table.Column<int>(type: "int", nullable: true),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: true),
                    CREATEDBY = table.Column<int>(type: "int", nullable: true),
                    CREATEDDATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATEDBY = table.Column<int>(type: "int", nullable: true),
                    UPDATEDDATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SUSPEND = table.Column<bool>(type: "bit", nullable: true),
                    RENEWALID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trans", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Trans_Renewalset_RENEWALID",
                        column: x => x.RENEWALID,
                        principalTable: "Renewalset",
                        principalColumn: "RENEWALID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trans_RENEWALID",
                table: "Trans",
                column: "RENEWALID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Trans");

            migrationBuilder.DropTable(
                name: "Renewalset");
        }
    }
}
