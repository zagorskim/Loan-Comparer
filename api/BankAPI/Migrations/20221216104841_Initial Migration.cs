using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inquiries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MoneyAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InstallmentsCount = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentType = table.Column<int>(type: "int", nullable: false),
                    DocumentId = table.Column<int>(type: "int", nullable: false),
                    JobType = table.Column<int>(type: "int", nullable: false),
                    IncomeLevel = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inquiries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Percentage = table.Column<int>(type: "int", nullable: false),
                    MonthlyInstallment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RequesedValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RequestedPeriodInMonth = table.Column<int>(type: "int", nullable: false),
                    StatusID = table.Column<int>(type: "int", nullable: false),
                    StatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InquireId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocumentLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentLinkValidDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inquiries");

            migrationBuilder.DropTable(
                name: "Offers");
        }
    }
}
