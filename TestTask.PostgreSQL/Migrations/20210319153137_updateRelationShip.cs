using Microsoft.EntityFrameworkCore.Migrations;

namespace TestTask.PostgreSQL.Migrations
{
    public partial class updateRelationShip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "PFRs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PFRs_PersonId",
                table: "PFRs",
                column: "PersonId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PFRs_People_PersonId",
                table: "PFRs",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PFRs_People_PersonId",
                table: "PFRs");

            migrationBuilder.DropIndex(
                name: "IX_PFRs_PersonId",
                table: "PFRs");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "PFRs");
        }
    }
}
