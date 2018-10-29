using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MatrixMax.Migrations
{
    public partial class AdicionandoAtivoCaregoriasEMarcasERemovendoImagemUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagemDePerfil",
                table: "Usuarios");

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Marcas",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Categorias",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Marcas");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Categorias");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImagemDePerfil",
                table: "Usuarios",
                nullable: true);
        }
    }
}
