using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace War.Migrations
{
    public partial class EnemyBack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Enemy",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Enemy",
                table: "Players");
        }
    }
}
