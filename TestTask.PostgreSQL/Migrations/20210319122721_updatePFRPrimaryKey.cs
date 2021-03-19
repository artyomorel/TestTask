using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TestTask.PostgreSQL.Migrations
{
    public partial class updatePFRPrimaryKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PFRs",
                table: "PFRs");

            migrationBuilder.DropColumn(
                name: "PFRId",
                table: "PFRs");

            migrationBuilder.AlterColumn<string>(
                name: "Snils",
                table: "PFRs",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PFRs",
                table: "PFRs",
                column: "Snils");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PFRs",
                table: "PFRs");

            migrationBuilder.AlterColumn<string>(
                name: "Snils",
                table: "PFRs",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "PFRId",
                table: "PFRs",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PFRs",
                table: "PFRs",
                column: "PFRId");
        }
    }
}
