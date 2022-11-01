using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_Controller_Burhan.Migrations
{
    public partial class FinalTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProfileProfile",
                columns: table => new
                {
                    ProfileFollowerusername = table.Column<string>(type: "TEXT", nullable: false),
                    ProfileFollowusername = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileProfile", x => new { x.ProfileFollowerusername, x.ProfileFollowusername });
                    table.ForeignKey(
                        name: "FK_ProfileProfile_profiles_ProfileFollowerusername",
                        column: x => x.ProfileFollowerusername,
                        principalTable: "profiles",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileProfile_profiles_ProfileFollowusername",
                        column: x => x.ProfileFollowusername,
                        principalTable: "profiles",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfileProfile_ProfileFollowusername",
                table: "ProfileProfile",
                column: "ProfileFollowusername");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfileProfile");
        }
    }
}
