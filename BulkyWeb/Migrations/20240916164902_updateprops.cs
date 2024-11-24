using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulkyWeb.Migrations
{
    /// <inheritdoc />
    public partial class updateprops : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "standard",
                table: "Student",
                newName: "Standard");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Student",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "age",
                table: "Student",
                newName: "Age");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Standard",
                table: "Student",
                newName: "standard");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Student",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Student",
                newName: "age");
        }
    }
}
