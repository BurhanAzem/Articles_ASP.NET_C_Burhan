using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_Controller_Burhan.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "profiles",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    bio = table.Column<string>(type: "TEXT", nullable: false),
                    image = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profiles", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    profileUserName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Email);
                    table.ForeignKey(
                        name: "FK_User_profiles_profileUserName",
                        column: x => x.profileUserName,
                        principalTable: "profiles",
                        principalColumn: "UserName");
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_profileUserName",
                table: "User",
                column: "profileUserName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "profiles");
        }
    }
}
