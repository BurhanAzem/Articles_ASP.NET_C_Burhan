using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_Controller_Burhan.Migrations
{
    public partial class FinalTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_profiles_profileUserName",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_profiles",
                table: "profiles");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "profiles",
                newName: "Profile");

            migrationBuilder.RenameColumn(
                name: "profileUserName",
                table: "Users",
                newName: "profileusername");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "email");

            migrationBuilder.RenameIndex(
                name: "IX_User_profileUserName",
                table: "Users",
                newName: "IX_Users_profileusername");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Profile",
                newName: "username");

            migrationBuilder.AddColumn<string>(
                name: "Articleslug",
                table: "Profile",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Profileusername",
                table: "Profile",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profile",
                table: "Profile",
                column: "username");

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
                    table.ForeignKey(
                        name: "FK_Articles_Profile_authorusername",
                        column: x => x.authorusername,
                        principalTable: "Profile",
                        principalColumn: "username");
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

            migrationBuilder.CreateIndex(
                name: "IX_Profile_Articleslug",
                table: "Profile",
                column: "Articleslug");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_Profileusername",
                table: "Profile",
                column: "Profileusername");

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
                name: "IX_Tag_Articleslug",
                table: "Tag",
                column: "Articleslug");

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_Articles_Articleslug",
                table: "Profile",
                column: "Articleslug",
                principalTable: "Articles",
                principalColumn: "slug");

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_Profile_Profileusername",
                table: "Profile",
                column: "Profileusername",
                principalTable: "Profile",
                principalColumn: "username");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Profile_profileusername",
                table: "Users",
                column: "profileusername",
                principalTable: "Profile",
                principalColumn: "username");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profile_Articles_Articleslug",
                table: "Profile");

            migrationBuilder.DropForeignKey(
                name: "FK_Profile_Profile_Profileusername",
                table: "Profile");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Profile_profileusername",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profile",
                table: "Profile");

            migrationBuilder.DropIndex(
                name: "IX_Profile_Articleslug",
                table: "Profile");

            migrationBuilder.DropIndex(
                name: "IX_Profile_Profileusername",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "Articleslug",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "Profileusername",
                table: "Profile");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Profile",
                newName: "profiles");

            migrationBuilder.RenameColumn(
                name: "profileusername",
                table: "User",
                newName: "profileUserName");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "User",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "User",
                newName: "Email");

            migrationBuilder.RenameIndex(
                name: "IX_Users_profileusername",
                table: "User",
                newName: "IX_User_profileUserName");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "profiles",
                newName: "UserName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_profiles",
                table: "profiles",
                column: "UserName");

            migrationBuilder.AddForeignKey(
                name: "FK_User_profiles_profileUserName",
                table: "User",
                column: "profileUserName",
                principalTable: "profiles",
                principalColumn: "UserName");
        }
    }
}
