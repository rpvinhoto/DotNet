using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Livraria.Dados.Migrations
{
    public partial class InitialSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    CategoriaId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Editora",
                columns: table => new
                {
                    EditoraId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editora", x => x.EditoraId);
                });

            migrationBuilder.CreateTable(
                name: "Livro",
                columns: table => new
                {
                    LivroId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    EditoraId = table.Column<long>(nullable: false),
                    CategoriaId = table.Column<long>(nullable: false),
                    DataPublicacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro", x => x.LivroId);
                    table.ForeignKey(
                        name: "FK_Livro_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Livro_Editora_EditoraId",
                        column: x => x.EditoraId,
                        principalTable: "Editora",
                        principalColumn: "EditoraId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Nome" },
                values: new object[,]
                {
                    { 1L, "Ficção" },
                    { 2L, "Fábula" },
                    { 3L, "Biografia" }
                });

            migrationBuilder.InsertData(
                table: "Editora",
                columns: new[] { "EditoraId", "Nome" },
                values: new object[,]
                {
                    { 1L, "Aleph" },
                    { 2L, "Reynal & Hitchcock" }
                });

            migrationBuilder.InsertData(
                table: "Livro",
                columns: new[] { "LivroId", "CategoriaId", "DataPublicacao", "EditoraId", "Titulo" },
                values: new object[] { 1L, 1L, new DateTime(1984, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, "Neuromancer" });

            migrationBuilder.InsertData(
                table: "Livro",
                columns: new[] { "LivroId", "CategoriaId", "DataPublicacao", "EditoraId", "Titulo" },
                values: new object[] { 2L, 2L, new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, "The Little Prince" });

            migrationBuilder.CreateIndex(
                name: "IX_Livro_CategoriaId",
                table: "Livro",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Livro_EditoraId",
                table: "Livro",
                column: "EditoraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livro");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Editora");
        }
    }
}
