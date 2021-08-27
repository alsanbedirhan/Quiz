using Microsoft.EntityFrameworkCore.Migrations;

namespace quiz.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    AdminID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.AdminID);
                });

            migrationBuilder.CreateTable(
                name: "Counts",
                columns: table => new
                {
                    CountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrueCount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NullCount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tryagain = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counts", x => x.CountID);
                    table.ForeignKey(
                        name: "FK_Counts_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "AdminID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Counts_UserID",
                table: "Counts",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Counts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
