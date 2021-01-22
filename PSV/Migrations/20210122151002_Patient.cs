using Microsoft.EntityFrameworkCore.Migrations;

namespace PSV.Migrations
{
    public partial class Patient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Termins",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Termins_PatientId",
                table: "Termins",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Termins_Users_PatientId",
                table: "Termins",
                column: "PatientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Termins_Users_PatientId",
                table: "Termins");

            migrationBuilder.DropIndex(
                name: "IX_Termins_PatientId",
                table: "Termins");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Termins");
        }
    }
}
