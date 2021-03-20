using Microsoft.EntityFrameworkCore.Migrations;

namespace TestTask.PostgreSQL.Migrations
{
    public partial class changerelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Perio",
                table: "PFRs");

            migrationBuilder.DropColumn(
                name: "Snils",
                table: "People");

            migrationBuilder.AlterColumn<double>(
                name: "Sum",
                table: "PFRs",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "PFRs",
                type: "integer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Period",
                table: "PFRs");

            migrationBuilder.AlterColumn<double>(
                name: "Sum",
                table: "PFRs",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Perio",
                table: "PFRs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Snils",
                table: "People",
                type: "text",
                nullable: true);
        }
    }
}
