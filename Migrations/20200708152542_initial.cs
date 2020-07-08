using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Comander.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Command",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    DataAtualizacao = table.Column<DateTime>(nullable: true),
                    HowTo = table.Column<string>(maxLength: 250, nullable: false),
                    Line = table.Column<string>(nullable: false),
                    Plataform = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Command", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Command");
        }
    }
}
