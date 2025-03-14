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
                name: "MS_Category",
                columns: table => new
                {
                    CATEGORYID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CATEGORYNAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISACTIVE = table.Column<int>(type: "int", nullable: true),
                    CREATEDBY = table.Column<int>(type: "int", nullable: true),
                    CREATEDDATE = table.Column<DateTime>(type: "date", nullable: true),
                    UPDATEDBY = table.Column<int>(type: "int", nullable: true),
                    UPDATEDDATE = table.Column<DateTime>(type: "date", nullable: true),
                    Suspend = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MS_Category", x => x.CATEGORYID);
                });

            migrationBuilder.CreateTable(
                name: "PODetails",
                columns: table => new
                {
                    POID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    POTypeID = table.Column<int>(type: "int", nullable: true),
                    PONumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    POvalue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    POStatusID = table.Column<int>(type: "int", nullable: true),
                    ClientNameID = table.Column<int>(type: "int", nullable: true),
                    EngagementModelID = table.Column<int>(type: "int", nullable: true),
                    ResourceprojectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationID = table.Column<int>(type: "int", nullable: true),
                    Accountable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencyID = table.Column<int>(type: "int", nullable: true),
                    JoiningDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractPeriod = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    RenewalDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemindertoAlert = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    POFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Isactive = table.Column<int>(type: "int", nullable: true),
                    Suspend = table.Column<int>(type: "int", nullable: true),
                    Createddatetime = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    Updateddatetime = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    DMPOC = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FMPOC = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ProposalPath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PODetails", x => x.POID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MS_Category");

            migrationBuilder.DropTable(
                name: "PODetails");
        }
    }
}
