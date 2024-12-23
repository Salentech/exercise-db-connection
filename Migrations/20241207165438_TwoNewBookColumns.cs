using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exercise_db_connection.Migrations
{
    /// <inheritdoc />
    public partial class TwoNewBookColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Plot",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Pubyear",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Plot",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Pubyear",
                table: "Books");
        }
    }
}
