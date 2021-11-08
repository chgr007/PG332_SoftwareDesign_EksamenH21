using Microsoft.EntityFrameworkCore.Migrations;

namespace PG332_SoftwareDesign_EksamenH21.Migrations
{
    public partial class addedFieldsInSpecialization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CoursesInSpecializations_SpecializationId",
                table: "CoursesInSpecializations");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Specializations",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Specializations",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoursesInSpecializations_SpecializationId",
                table: "CoursesInSpecializations",
                column: "SpecializationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CoursesInSpecializations_SpecializationId",
                table: "CoursesInSpecializations");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Specializations");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Specializations");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesInSpecializations_SpecializationId",
                table: "CoursesInSpecializations",
                column: "SpecializationId",
                unique: true);
        }
    }
}
