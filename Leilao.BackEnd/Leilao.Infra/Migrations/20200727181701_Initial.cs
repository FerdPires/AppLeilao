using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leilao.Infra.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leiloes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_leilao = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    valor_inicial = table.Column<double>(nullable: false),
                    item_usado = table.Column<bool>(type: "bit", nullable: false),
                    data_inicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    data_fim = table.Column<DateTime>(type: "datetime", nullable: false),
                    nome_usuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    User = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leiloes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usuario_ativo = table.Column<bool>(type: "bit", nullable: false),
                    User = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Leiloes_User",
                table: "Leiloes",
                column: "User");

            migrationBuilder.CreateIndex(
                name: "IX_Users_User",
                table: "Users",
                column: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leiloes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
