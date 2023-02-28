using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Qynon.AdventureWorks.Infrastructure.Migrations
{
    public partial class HistoricoCorridaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "PistaCorrida",
                newName: "pistacorrida");

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "pistacorrida",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "historicocorrida",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompetidorId = table.Column<int>(type: "integer", nullable: false),
                    PistaCorridaId = table.Column<int>(type: "integer", nullable: false),
                    DataCorrida = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TempoGasto = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.id);
                    table.ForeignKey(
                        name: "fk_competidor",
                        column: x => x.CompetidorId,
                        principalTable: "competidores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_pista_corrida",
                        column: x => x.PistaCorridaId,
                        principalTable: "pistacorrida",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_historicocorrida_CompetidorId",
                table: "historicocorrida",
                column: "CompetidorId");

            migrationBuilder.CreateIndex(
                name: "IX_historicocorrida_PistaCorridaId",
                table: "historicocorrida",
                column: "PistaCorridaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "historicocorrida");

            migrationBuilder.RenameTable(
                name: "pistacorrida",
                newName: "PistaCorrida");

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "PistaCorrida",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);
        }
    }
}
