using Microsoft.EntityFrameworkCore.Migrations;

namespace MatrixMax.Migrations
{
    public partial class CorrigindoFormaDePagamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdCartao",
                table: "FormasDePagamento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCartao",
                table: "FormasDePagamento",
                nullable: true);
        }
    }
}
