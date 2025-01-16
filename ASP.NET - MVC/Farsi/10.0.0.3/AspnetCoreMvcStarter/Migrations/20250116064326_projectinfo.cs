using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspnetCoreMvcStarter.Migrations
{
    /// <inheritdoc />
    public partial class projectinfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectInfos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersianName = table.Column<string>(type: "TEXT", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    CrowdFundingType = table.Column<string>(type: "TEXT", nullable: false),
                    ProjectStatus = table.Column<string>(type: "TEXT", nullable: false),
                    UnderwritingApprovedStartDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UnderwritingDuration = table.Column<int>(type: "INTEGER", nullable: false),
                    AgentName = table.Column<string>(type: "TEXT", nullable: false),
                    PlatformUrl = table.Column<string>(type: "TEXT", nullable: false),
                    BrokerName = table.Column<string>(type: "TEXT", nullable: false),
                    PersianSubject = table.Column<string>(type: "TEXT", nullable: false),
                    CompanyName = table.Column<string>(type: "TEXT", nullable: false),
                    PersianApprovedSymbol = table.Column<string>(type: "TEXT", nullable: false),
                    IndustryGroupDescription = table.Column<string>(type: "TEXT", nullable: false),
                    SubIndustryGroupDescription = table.Column<string>(type: "TEXT", nullable: false),
                    MinimumRequiredPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    RealPersonMinimumAvailablePrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    RealPersonMaximumAvailablePrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    LegalPersonMinimumAvailablePrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    LegalPersonMaximumAvailablePrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    UnderwritingStartDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UnderwritingEndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ProjectStartDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ProjectEndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CompanyUnitCounts = table.Column<int>(type: "INTEGER", nullable: false),
                    CommissionIfb = table.Column<decimal>(type: "TEXT", nullable: false),
                    CommissionAgent = table.Column<decimal>(type: "TEXT", nullable: false),
                    GuaranteeType = table.Column<string>(type: "TEXT", nullable: false),
                    CompanyNationalID = table.Column<string>(type: "TEXT", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "TEXT", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EconomicID = table.Column<string>(type: "TEXT", nullable: false),
                    CompanyType = table.Column<string>(type: "TEXT", nullable: false),
                    PostalCode = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectInfos", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectInfos");
        }
    }
}
