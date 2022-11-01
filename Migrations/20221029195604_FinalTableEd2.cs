using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_Controller_Burhan.Migrations
{
    public partial class FinalTableEd2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_profiles_authorusername",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileProfile_profiles_ProfileFollowerusername",
                table: "ProfileProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileProfile_profiles_ProfileFollowusername",
                table: "ProfileProfile");

            migrationBuilder.RenameColumn(
                name: "ProfileFollowusername",
                table: "ProfileProfile",
                newName: "ProfileFollowingusername");

            migrationBuilder.RenameColumn(
                name: "ProfileFollowerusername",
                table: "ProfileProfile",
                newName: "ProfileFolloweresusername");

            migrationBuilder.RenameIndex(
                name: "IX_ProfileProfile_ProfileFollowusername",
                table: "ProfileProfile",
                newName: "IX_ProfileProfile_ProfileFollowingusername");

            migrationBuilder.AlterColumn<string>(
                name: "authorusername",
                table: "Comments",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_profiles_authorusername",
                table: "Comments",
                column: "authorusername",
                principalTable: "profiles",
                principalColumn: "username");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileProfile_profiles_ProfileFolloweresusername",
                table: "ProfileProfile",
                column: "ProfileFolloweresusername",
                principalTable: "profiles",
                principalColumn: "username",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileProfile_profiles_ProfileFollowingusername",
                table: "ProfileProfile",
                column: "ProfileFollowingusername",
                principalTable: "profiles",
                principalColumn: "username",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_profiles_authorusername",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileProfile_profiles_ProfileFolloweresusername",
                table: "ProfileProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileProfile_profiles_ProfileFollowingusername",
                table: "ProfileProfile");

            migrationBuilder.RenameColumn(
                name: "ProfileFollowingusername",
                table: "ProfileProfile",
                newName: "ProfileFollowusername");

            migrationBuilder.RenameColumn(
                name: "ProfileFolloweresusername",
                table: "ProfileProfile",
                newName: "ProfileFollowerusername");

            migrationBuilder.RenameIndex(
                name: "IX_ProfileProfile_ProfileFollowingusername",
                table: "ProfileProfile",
                newName: "IX_ProfileProfile_ProfileFollowusername");

            migrationBuilder.AlterColumn<string>(
                name: "authorusername",
                table: "Comments",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_profiles_authorusername",
                table: "Comments",
                column: "authorusername",
                principalTable: "profiles",
                principalColumn: "username",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileProfile_profiles_ProfileFollowerusername",
                table: "ProfileProfile",
                column: "ProfileFollowerusername",
                principalTable: "profiles",
                principalColumn: "username",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileProfile_profiles_ProfileFollowusername",
                table: "ProfileProfile",
                column: "ProfileFollowusername",
                principalTable: "profiles",
                principalColumn: "username",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
