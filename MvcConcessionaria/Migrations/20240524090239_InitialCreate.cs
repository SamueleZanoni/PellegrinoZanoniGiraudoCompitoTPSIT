using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcConcessionaria.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Concessionaria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modello = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genere = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataDiRilascio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Prezzo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cavalli = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cilindrata = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Alimentazione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concessionaria", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Concessionaria");
        }
    }
}
