using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_Controller_Burhan.Migrations
{
    public partial class FinalTableEd1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_profiles_Articles_articleslug",
                table: "profiles");

            migrationBuilder.AlterColumn<string>(
                name: "emailuser",
                table: "profiles",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "articleslug",
                table: "profiles",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "profileusername",
                table: "Articles",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_profiles_Articles_articleslug",
                table: "profiles",
                column: "articleslug",
                principalTable: "Articles",
                principalColumn: "slug");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_profiles_Articles_articleslug",
                table: "profiles");

            migrationBuilder.AlterColumn<string>(
                name: "emailuser",
                table: "profiles",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "articleslug",
                table: "profiles",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "profileusername",
                table: "Articles",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_profiles_Articles_articleslug",
                table: "profiles",
                column: "articleslug",
                principalTable: "Articles",
                principalColumn: "slug",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
