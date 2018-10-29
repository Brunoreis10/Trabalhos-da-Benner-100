using Microsoft.EntityFrameworkCore.Migrations;

namespace MatrixMax.Migrations
{
    public partial class AlterandoFormaDePagamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormasDePagamento_FormasDePagamento_BandeiraCartaoId",
                table: "FormasDePagamento");

            migrationBuilder.DropIndex(
                name: "IX_FormasDePagamento_BandeiraCartaoId",
                table: "FormasDePagamento");

            migrationBuilder.DropColumn(
                name: "BandeiraCartaoId",
                table: "FormasDePagamento");

            migrationBuilder.AddColumn<bool>(
                name: "BandeiraCartao",
                table: "FormasDePagamento",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Previsao",
                table: "FormasDePagamento",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BandeiraCartao",
                table: "FormasDePagamento");

            migrationBuilder.DropColumn(
                name: "Previsao",
                table: "FormasDePagamento");

            migrationBuilder.AddColumn<int>(
                name: "BandeiraCartaoId",
                table: "FormasDePagamento",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FormasDePagamento_BandeiraCartaoId",
                table: "FormasDePagamento",
                column: "BandeiraCartaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_FormasDePagamento_FormasDePagamento_BandeiraCartaoId",
                table: "FormasDePagamento",
                column: "BandeiraCartaoId",
                principalTable: "FormasDePagamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
