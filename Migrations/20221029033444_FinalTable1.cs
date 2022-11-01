using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_Controller_Burhan.Migrations
{
    public partial class FinalTable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    slug = table.Column<string>(type: "TEXT", nullable: false),
                    title = table.Column<string>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    body = table.Column<string>(type: "TEXT", nullable: false),
                    createdAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    updatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    favoritesCount = table.Column<int>(type: "INTEGER", nullable: true),
                    profileusername = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.slug);
                });

            migrationBuilder.CreateTable(
                name: "profiles",
                columns: table => new
                {
                    username = table.Column<string>(type: "TEXT", nullable: false),
                    bio = table.Column<string>(type: "TEXT", nullable: true),
                    image = table.Column<string>(type: "TEXT", nullable: true),
                    emailuser = table.Column<string>(type: "TEXT", nullable: false),
                    articleslug = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profiles", x => x.username);
                    table.ForeignKey(
                        name: "FK_profiles_Articles_articleslug",
                        column: x => x.articleslug,
                        principalTable: "Articles",
                        principalColumn: "slug",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tages",
                columns: table => new
                {
                    tag = table.Column<string>(type: "TEXT", nullable: false),
                    articleslug = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tages", x => x.tag);
                    table.ForeignKey(
                        name: "FK_Tages_Articles_articleslug",
                        column: x => x.articleslug,
                        principalTable: "Articles",
                        principalColumn: "slug");
                });

            migrationBuilder.CreateTable(
                name: "ArticleProfiles",
                columns: table => new
                {
                    slug = table.Column<string>(type: "TEXT", nullable: false),
                    username = table.Column<string>(type: "TEXT", nullable: false),
                    articleslug = table.Column<string>(type: "TEXT", nullable: false),
                    Profileusername = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleProfiles", x => new { x.username, x.slug });
                    table.ForeignKey(
                        name: "FK_ArticleProfiles_Articles_articleslug",
                        column: x => x.articleslug,
                        principalTable: "Articles",
                        principalColumn: "slug",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleProfiles_profiles_Profileusername",
                        column: x => x.Profileusername,
                        principalTable: "profiles",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    createdAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    updatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    body = table.Column<string>(type: "TEXT", nullable: false),
                    authorusername = table.Column<string>(type: "TEXT", nullable: false),
                    articleslug = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.id);
                    table.ForeignKey(
                        name: "FK_Comments_Articles_articleslug",
                        column: x => x.articleslug,
                        principalTable: "Articles",
                        principalColumn: "slug");
                    table.ForeignKey(
                        name: "FK_Comments_profiles_authorusername",
                        column: x => x.authorusername,
                        principalTable: "profiles",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: true),
                    profileusername = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.email);
                    table.ForeignKey(
                        name: "FK_Users_profiles_profileusername",
                        column: x => x.profileusername,
                        principalTable: "profiles",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleProfiles_articleslug",
                table: "ArticleProfiles",
                column: "articleslug");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleProfiles_Profileusername",
                table: "ArticleProfiles",
                column: "Profileusername");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_articleslug",
                table: "Comments",
                column: "articleslug");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_authorusername",
                table: "Comments",
                column: "authorusername");

            migrationBuilder.CreateIndex(
                name: "IX_profiles_articleslug",
                table: "profiles",
                column: "articleslug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tages_articleslug",
                table: "Tages",
                column: "articleslug");

            migrationBuilder.CreateIndex(
                name: "IX_Users_profileusername",
                table: "Users",
                column: "profileusername",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleProfiles");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Tages");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "profiles");

            migrationBuilder.DropTable(
                name: "Articles");
        }
    }
}
