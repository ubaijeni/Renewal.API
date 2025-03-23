using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Renewal.DataHub.Migrations
{
    /// <inheritdoc />
    public partial class tesing08 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    BranchID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Suspend = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.BranchID);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Isactive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Suspend = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

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
                name: "Renewalset",
                columns: table => new
                {
                    RenewalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Validity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RenewalDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Reminder = table.Column<int>(type: "int", nullable: false),
                    AlterTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Suspend = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Renewalset", x => x.RenewalId);
                });

            migrationBuilder.CreateTable(
                name: "PettyCashTransaction",
                columns: table => new
                {
                    TransactionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BranchID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaidTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Purpose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApprovedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PettyCashTransaction", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_PettyCashTransaction_Branches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "BranchID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PODetails",
                columns: table => new
                {
                    POID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    POTypeID = table.Column<int>(type: "int", nullable: true),
                    PONumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    POvalue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    POStatusID = table.Column<int>(type: "int", nullable: true),
                    ClientNameID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EngagementModelID = table.Column<int>(type: "int", nullable: true),
                    ResourceprojectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationID = table.Column<int>(type: "int", nullable: true),
                    Accountable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencyID = table.Column<int>(type: "int", nullable: true),
                    JoiningDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContractPeriod = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    RenewalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_PODetails_Clients_ClientNameID",
                        column: x => x.ClientNameID,
                        principalTable: "Clients",
                        principalColumn: "ClientId");
                });

            migrationBuilder.CreateTable(
                name: "Trans",
                columns: table => new
                {
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RenewalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Validity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RenewalDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Remider = table.Column<int>(type: "int", nullable: false),
                    AlertTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Suspend = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trans", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Trans_Renewalset_RenewalId",
                        column: x => x.RenewalId,
                        principalTable: "Renewalset",
                        principalColumn: "RenewalId");
                });

            migrationBuilder.CreateTable(
                name: "AmountReceived",
                columns: table => new
                {
                    AmountreceivedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    POId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amountreceived = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmountReceived", x => x.AmountreceivedId);
                    table.ForeignKey(
                        name: "FK_AmountReceived_PODetails_POId",
                        column: x => x.POId,
                        principalTable: "PODetails",
                        principalColumn: "POID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AmountReceived_POId",
                table: "AmountReceived",
                column: "POId");

            migrationBuilder.CreateIndex(
                name: "IX_PettyCashTransaction_BranchID",
                table: "PettyCashTransaction",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_PODetails_ClientNameID",
                table: "PODetails",
                column: "ClientNameID");

            migrationBuilder.CreateIndex(
                name: "IX_Trans_RenewalId",
                table: "Trans",
                column: "RenewalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AmountReceived");

            migrationBuilder.DropTable(
                name: "MS_Category");

            migrationBuilder.DropTable(
                name: "PettyCashTransaction");

            migrationBuilder.DropTable(
                name: "Trans");

            migrationBuilder.DropTable(
                name: "PODetails");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Renewalset");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
