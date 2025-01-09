using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspnetCoreMvcStarter.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DashboardData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Started = table.Column<double>(type: "REAL", nullable: false),
                    OtherStarted = table.Column<double>(type: "REAL", nullable: false),
                    FundingFinished = table.Column<double>(type: "REAL", nullable: false),
                    OtherFundingFinished = table.Column<double>(type: "REAL", nullable: false),
                    ApprovedByBroker = table.Column<double>(type: "REAL", nullable: false),
                    OtherApprovedByBroker = table.Column<double>(type: "REAL", nullable: false),
                    FundingApprovedByFarabourse = table.Column<double>(type: "REAL", nullable: false),
                    OtherFundingApprovedByFarabourse = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProjectName = table.Column<string>(type: "TEXT", nullable: false),
                    Benefit = table.Column<string>(type: "TEXT", nullable: false),
                    StartTime = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<string>(type: "TEXT", nullable: false),
                    Pay = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RequestDate = table.Column<string>(type: "TEXT", nullable: false),
                    Symbol = table.Column<string>(type: "TEXT", nullable: false),
                    PlatformName = table.Column<string>(type: "TEXT", nullable: false),
                    Applicant = table.Column<string>(type: "TEXT", nullable: false),
                    NationalID = table.Column<string>(type: "TEXT", nullable: false),
                    ProjectTitle = table.Column<string>(type: "TEXT", nullable: false),
                    ApprovalDate = table.Column<string>(type: "TEXT", nullable: false),
                    TotalFundingRequired = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalRaisedAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    ActualRaisedAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    LegalRaisedAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    IndividualContributorsCount = table.Column<int>(type: "INTEGER", nullable: false),
                    LegalContributorsCount = table.Column<int>(type: "INTEGER", nullable: false),
                    FundCollectionDate = table.Column<string>(type: "TEXT", nullable: false),
                    ProjectStartDate = table.Column<string>(type: "TEXT", nullable: false),
                    ProjectEndDate = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    CollateralType = table.Column<string>(type: "TEXT", nullable: false),
                    InterestRate = table.Column<decimal>(type: "TEXT", nullable: false),
                    PaymentFrequency = table.Column<string>(type: "TEXT", nullable: false),
                    FinancialInstitutionID = table.Column<string>(type: "TEXT", nullable: false),
                    FinancialInstitutionName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectID);
                });

            migrationBuilder.CreateTable(
                name: "QuestionHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    question = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    response = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    selectedOption = table.Column<string>(type: "TEXT", nullable: false),
                    isDelete = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TextSegments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    Embedding = table.Column<byte[]>(type: "BLOB", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextSegments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Customer = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DueDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Total = table.Column<decimal>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DashboardData");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "QuestionHistories");

            migrationBuilder.DropTable(
                name: "TextSegments");

            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
