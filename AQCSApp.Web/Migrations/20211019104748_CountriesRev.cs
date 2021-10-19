using Microsoft.EntityFrameworkCore.Migrations;

namespace AQCSApp.Web.Migrations
{
    public partial class CountriesRev : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Countries",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Countries",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_UserId",
                table: "Countries",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_AspNetUsers_UserId",
                table: "Countries",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_AspNetUsers_UserId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_UserId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Countries");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Countries",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);
        }
    }
}
