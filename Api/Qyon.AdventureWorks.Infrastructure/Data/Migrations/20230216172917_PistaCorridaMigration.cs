using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Qynon.AdventureWorks.Infrastructure.Migrations
{
    public partial class PistaCorridaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_competidores",
                table: "competidores");

            migrationBuilder.AlterColumn<double>(
                name: "temperaturamediacorpo",
                table: "competidores",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<double>(
                name: "peso",
                table: "competidores",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "id",
                table: "competidores",
                column: "id");

            migrationBuilder.CreateTable(
                name: "PistaCorrida",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descricao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PistaCorrida");

            migrationBuilder.DropPrimaryKey(
                name: "id",
                table: "competidores");

            migrationBuilder.AlterColumn<int>(
                name: "temperaturamediacorpo",
                table: "competidores",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<int>(
                name: "peso",
                table: "competidores",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AddPrimaryKey(
                name: "PK_competidores",
                table: "competidores",
                column: "id");
        }
    }
}
