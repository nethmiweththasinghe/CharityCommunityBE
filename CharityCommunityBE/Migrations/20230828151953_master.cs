using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CharityCommunityBE.Migrations
{
    /// <inheritdoc />
    public partial class master : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Volunteers",
                table: "Volunteers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_volunteers",
                table: "volunteers");

            migrationBuilder.RenameTable(
                name: "Volunteers",
                newName: "Volunteer");

            migrationBuilder.RenameTable(
                name: "volunteers",
                newName: "volunteer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Volunteer",
                table: "Volunteer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_volunteer",
                table: "volunteer",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Volunteer",
                table: "Volunteer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_volunteer",
                table: "volunteer");

            migrationBuilder.RenameTable(
                name: "Volunteer",
                newName: "Volunteers");

            migrationBuilder.RenameTable(
                name: "volunteer",
                newName: "volunteers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Volunteers",
                table: "Volunteers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_volunteers",
                table: "volunteers",
                column: "Id");
        }
    }
}
