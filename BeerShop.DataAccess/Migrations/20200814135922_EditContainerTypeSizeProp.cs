using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerShop.DataAccess.Migrations
{
    public partial class EditContainerTypeSizeProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Size",
                table: "ContainerTypes",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Size",
                table: "ContainerTypes",
                type: "float",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
