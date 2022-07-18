using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace War.Migrations
{
    public partial class PlayerMove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Enemy",
                table: "Players");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfMove",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfMove",
                table: "Players");

            migrationBuilder.AddColumn<string>(
                name: "Enemy",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
