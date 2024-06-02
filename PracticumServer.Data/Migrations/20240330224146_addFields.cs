using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticumServer.Data.Migrations
{
    /// <inheritdoc />
    public partial class addFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdNumber",
                table: "Workers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Workers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdNumber",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Workers");
        }
    }
}
