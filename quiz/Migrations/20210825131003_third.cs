using Microsoft.EntityFrameworkCore.Migrations;

namespace quiz.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NullCount",
                table: "Counts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NullCount",
                table: "Counts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
