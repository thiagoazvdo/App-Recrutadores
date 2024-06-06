using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecrutamentoAPI.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidatos_Empresas_EmpresaId",
                table: "Candidatos");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "CandidatoId",
                table: "Candidatos");

            migrationBuilder.AlterColumn<int>(
                name: "EmpresaId",
                table: "Candidatos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidatos_Empresas_EmpresaId",
                table: "Candidatos",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidatos_Empresas_EmpresaId",
                table: "Candidatos");

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Empresas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "EmpresaId",
                table: "Candidatos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CandidatoId",
                table: "Candidatos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidatos_Empresas_EmpresaId",
                table: "Candidatos",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
