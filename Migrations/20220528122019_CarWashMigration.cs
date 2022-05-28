using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Car_Wash.Migrations
{
    public partial class CarWashMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProprietarioModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    DataDeNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CPF = table.Column<string>(type: "TEXT", nullable: true),
                    Celular = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProprietarioModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServicoModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Preco = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicoModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarroModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Marca = table.Column<string>(type: "TEXT", nullable: true),
                    Cor = table.Column<string>(type: "TEXT", nullable: true),
                    Modelo = table.Column<string>(type: "TEXT", nullable: true),
                    Placa = table.Column<string>(type: "TEXT", nullable: true),
                    ProprietarioId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarroModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarroModel_ProprietarioModel_ProprietarioId",
                        column: x => x.ProprietarioId,
                        principalTable: "ProprietarioModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AgendamentoModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataDeAgendamento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CarroId = table.Column<int>(type: "INTEGER", nullable: false),
                    ServicoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendamentoModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgendamentoModel_CarroModel_CarroId",
                        column: x => x.CarroId,
                        principalTable: "CarroModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgendamentoModel_ServicoModel_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "ServicoModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgendamentoModel_CarroId",
                table: "AgendamentoModel",
                column: "CarroId");

            migrationBuilder.CreateIndex(
                name: "IX_AgendamentoModel_ServicoId",
                table: "AgendamentoModel",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_CarroModel_ProprietarioId",
                table: "CarroModel",
                column: "ProprietarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgendamentoModel");

            migrationBuilder.DropTable(
                name: "CarroModel");

            migrationBuilder.DropTable(
                name: "ServicoModel");

            migrationBuilder.DropTable(
                name: "ProprietarioModel");
        }
    }
}
