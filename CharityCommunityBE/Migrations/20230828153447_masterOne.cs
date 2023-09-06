using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CharityCommunityBE.Migrations
{
    /// <inheritdoc />
    public partial class masterOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_volunteer",
                table: "volunteer");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "volunteer");

            migrationBuilder.RenameTable(
                name: "volunteer",
                newName: "Volunteer");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Volunteer",
                newName: "Project");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Volunteer",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Other",
                table: "Volunteer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Volunteer",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Volunteer",
                table: "Volunteer",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "volunteer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_volunteer", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "volunteer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Volunteer",
                table: "Volunteer");

            migrationBuilder.DropColumn(
                name: "Other",
                table: "Volunteer");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Volunteer");

            migrationBuilder.RenameTable(
                name: "Volunteer",
                newName: "volunteer");

            migrationBuilder.RenameColumn(
                name: "Project",
                table: "volunteer",
                newName: "Name");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "volunteer",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "volunteer",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_volunteer",
                table: "volunteer",
                column: "Id");
        }
    }
}
