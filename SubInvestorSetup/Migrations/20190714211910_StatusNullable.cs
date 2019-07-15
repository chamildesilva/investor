using Microsoft.EntityFrameworkCore.Migrations;

namespace SubInvestorSetup.Migrations
{
    public partial class StatusNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "InvestorLinks",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "InvestorLinks",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
