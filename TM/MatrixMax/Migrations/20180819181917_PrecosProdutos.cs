using Microsoft.EntityFrameworkCore.Migrations;

namespace MatrixMax.Migrations
{
    public partial class PrecosProdutos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecoCompativel",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "PrecoOriginal",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "PrecoPeriferico",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "PrecoReciclado",
                table: "Produtos");

            migrationBuilder.AddColumn<double>(
                name: "PrecoUnitario",
                table: "Produtos",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecoUnitario",
                table: "Produtos");

            migrationBuilder.AddColumn<double>(
                name: "PrecoCompativel",
                table: "Produtos",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PrecoOriginal",
                table: "Produtos",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PrecoPeriferico",
                table: "Produtos",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PrecoReciclado",
                table: "Produtos",
                nullable: true);
        }
    }
}
