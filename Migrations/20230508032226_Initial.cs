using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockCardiologia.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deposito",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreDeposito = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposito", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NSerie = table.Column<string>(type: "TEXT", nullable: false),
                    Remito = table.Column<string>(type: "TEXT", nullable: false),
                    Planilla = table.Column<string>(type: "TEXT", nullable: false),
                    FechaProd = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Condicion = table.Column<string>(type: "TEXT", nullable: false),
                    DepositoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipo_Deposito_DepositoId",
                        column: x => x.DepositoId,
                        principalTable: "Deposito",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipo_DepositoId",
                table: "Equipo",
                column: "DepositoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipo");

            migrationBuilder.DropTable(
                name: "Deposito");
        }
    }
}
