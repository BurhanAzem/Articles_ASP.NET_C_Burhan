using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_Controller_Burhan.Migrations
{
    public partial class FORMDB : Migration
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
                    authorusername = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.slug);
                });

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    username = table.Column<string>(type: "TEXT", nullable: false),
                    bio = table.Column<string>(type: "TEXT", nullable: false),
                    image = table.Column<string>(type: "TEXT", nullable: false),
                    Articleslug = table.Column<string>(type: "TEXT", nullable: true),
                    Profileusername = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.username);
                    table.ForeignKey(
                        name: "FK_Profile_Articles_Articleslug",
                        column: x => x.Articleslug,
                        principalTable: "Articles",
                        principalColumn: "slug");
                    table.ForeignKey(
                        name: "FK_Profile_Profile_Profileusername",
                        column: x => x.Profileusername,
                        principalTable: "Profile",
                        principalColumn: "username");

                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    tag = table.Column<string>(type: "TEXT", nullable: false),
                    Articleslug = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.tag);
                    table.ForeignKey(
                        name: "FK_Tag_Articles_Articleslug",
                        column: x => x.Articleslug,
                        principalTable: "Articles",
                        principalColumn: "slug");
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    createdAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    updatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    body = table.Column<string>(type: "TEXT", nullable: false),
                    authorusername = table.Column<string>(type: "TEXT", nullable: true),
                    Articleslug = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.id);
                    table.ForeignKey(
                        name: "FK_Comment_Articles_Articleslug",
                        column: x => x.Articleslug,
                        principalTable: "Articles",
                        principalColumn: "slug");
                    table.ForeignKey(
                        name: "FK_Comment_Profile_authorusername",
                        column: x => x.authorusername,
                        principalTable: "Profile",
                        principalColumn: "username");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false),
                    profileusername = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.email);
                    table.ForeignKey(
                        name: "FK_Users_Profile_profileusername",
                        column: x => x.profileusername,
                        principalTable: "Profile",
                        principalColumn: "username");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_authorusername",
                table: "Articles",
                column: "authorusername");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_Articleslug",
                table: "Comment",
                column: "Articleslug");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_authorusername",
                table: "Comment",
                column: "authorusername");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_Articleslug",
                table: "Profile",
                column: "Articleslug");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_Profileusername",
                table: "Profile",
                column: "Profileusername");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_Articleslug",
                table: "Tag",
                column: "Articleslug");

            migrationBuilder.CreateIndex(
                name: "IX_Users_profileusername",
                table: "Users",
                column: "profileusername");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Profile_authorusername",
                table: "Articles",
                column: "authorusername",
                principalTable: "Profile",
                principalColumn: "username");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Profile_authorusername",
                table: "Articles");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropTable(
                name: "Articles");
        }
    }
}
