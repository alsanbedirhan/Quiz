using Microsoft.EntityFrameworkCore.Migrations;

namespace quiz.Migrations
{
    public partial class son : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tryagain",
                table: "Counts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "tryagain",
                table: "Counts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
