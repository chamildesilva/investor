using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SubInvestorSetup.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvestorLinks",
                columns: table => new
                {
                    InvestorSetupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "varchar(256)", nullable: false),
                    InvestorNo = table.Column<int>(nullable: false),
                    InvestorSubFrom = table.Column<int>(nullable: false),
                    InvestorSubTo = table.Column<int>(nullable: false),
                    ModelAfterInvestorNo = table.Column<int>(nullable: false),
                    ModelAfterInvestorSub = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ApprovedDate = table.Column<DateTime>(nullable: false),
                    ApprovedBy = table.Column<string>(nullable: true),
                    DeployedDate = table.Column<DateTime>(nullable: false),
                    DeployedBy = table.Column<string>(nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: false),
                    DeletedBy = table.Column<string>(nullable: true),
                    DeletedReason = table.Column<string>(type: "varchar(256)", nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestorLinks", x => x.InvestorSetupId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvestorLinks");
        }
    }
}
