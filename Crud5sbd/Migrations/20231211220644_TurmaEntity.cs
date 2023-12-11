using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crud5sbd.Migrations
{
    /// <inheritdoc />
    public partial class TurmaEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DisciplinaId",
                table: "Professor",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Turma",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Turno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisciplinaId = table.Column<int>(type: "int", nullable: false),
                    ProfessorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turma", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turma_Disciplina_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Turma_Professor_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Professor_DisciplinaId",
                table: "Professor",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Turma_DisciplinaId",
                table: "Turma",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Turma_ProfessorId",
                table: "Turma",
                column: "ProfessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Professor_Disciplina_DisciplinaId",
                table: "Professor",
                column: "DisciplinaId",
                principalTable: "Disciplina",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professor_Disciplina_DisciplinaId",
                table: "Professor");

            migrationBuilder.DropTable(
                name: "Turma");

            migrationBuilder.DropIndex(
                name: "IX_Professor_DisciplinaId",
                table: "Professor");

            migrationBuilder.DropColumn(
                name: "DisciplinaId",
                table: "Professor");
        }
    }
}
