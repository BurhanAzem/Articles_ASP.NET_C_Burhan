using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_Controller_Burhan.Migrations
{
    public partial class FinalTableED5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tages_Articles_articleslug",
                table: "Tages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tages",
                table: "Tages");

            migrationBuilder.AlterColumn<string>(
                name: "articleslug",
                table: "Tages",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tages",
                table: "Tages",
                columns: new[] { "tag", "articleslug" });

            migrationBuilder.AddForeignKey(
                name: "FK_Tages_Articles_articleslug",
                table: "Tages",
                column: "articleslug",
                principalTable: "Articles",
                principalColumn: "slug",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tages_Articles_articleslug",
                table: "Tages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tages",
                table: "Tages");

            migrationBuilder.AlterColumn<string>(
                name: "articleslug",
                table: "Tages",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tages",
                table: "Tages",
                column: "tag");

            migrationBuilder.AddForeignKey(
                name: "FK_Tages_Articles_articleslug",
                table: "Tages",
                column: "articleslug",
                principalTable: "Articles",
                principalColumn: "slug");
        }
    }
}
