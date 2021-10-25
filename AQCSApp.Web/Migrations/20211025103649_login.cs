using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AQCSApp.Web.Migrations
{
    public partial class login : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fish_FishFamilies_FamilyId",
                table: "Fish");

            migrationBuilder.DropForeignKey(
                name: "FK_Fish_AspNetUsers_UserId",
                table: "Fish");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fish",
                table: "Fish");

            migrationBuilder.RenameTable(
                name: "Fish",
                newName: "Fishes");

            migrationBuilder.RenameColumn(
                name: "FamilyId",
                table: "Fishes",
                newName: "FishFamilyId");

            migrationBuilder.RenameIndex(
                name: "IX_Fish_UserId",
                table: "Fishes",
                newName: "IX_Fishes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Fish_FamilyId",
                table: "Fishes",
                newName: "IX_Fishes_FishFamilyId");

            migrationBuilder.AddColumn<int>(
                name: "ContinentId",
                table: "Countries",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FishGenusId",
                table: "Fishes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fishes",
                table: "Fishes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "FishGenus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    FishFamilyId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FishGenus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FishGenus_FishFamilies_FishFamilyId",
                        column: x => x.FishFamilyId,
                        principalTable: "FishFamilies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FishGenus_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Province",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    CountryId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Province_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Province_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Continent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ProvinceId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Continent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Continent_Province_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Province",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Continent_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_ContinentId",
                table: "Countries",
                column: "ContinentId");

            migrationBuilder.CreateIndex(
                name: "IX_Fishes_FishGenusId",
                table: "Fishes",
                column: "FishGenusId");

            migrationBuilder.CreateIndex(
                name: "IX_Continent_ProvinceId",
                table: "Continent",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Continent_UserId",
                table: "Continent",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FishGenus_FishFamilyId",
                table: "FishGenus",
                column: "FishFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_FishGenus_UserId",
                table: "FishGenus",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Province_CountryId",
                table: "Province",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Province_UserId",
                table: "Province",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Continent_ContinentId",
                table: "Countries",
                column: "ContinentId",
                principalTable: "Continent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fishes_FishFamilies_FishFamilyId",
                table: "Fishes",
                column: "FishFamilyId",
                principalTable: "FishFamilies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fishes_FishGenus_FishGenusId",
                table: "Fishes",
                column: "FishGenusId",
                principalTable: "FishGenus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fishes_AspNetUsers_UserId",
                table: "Fishes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Continent_ContinentId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Fishes_FishFamilies_FishFamilyId",
                table: "Fishes");

            migrationBuilder.DropForeignKey(
                name: "FK_Fishes_FishGenus_FishGenusId",
                table: "Fishes");

            migrationBuilder.DropForeignKey(
                name: "FK_Fishes_AspNetUsers_UserId",
                table: "Fishes");

            migrationBuilder.DropTable(
                name: "Continent");

            migrationBuilder.DropTable(
                name: "FishGenus");

            migrationBuilder.DropTable(
                name: "Province");

            migrationBuilder.DropIndex(
                name: "IX_Countries_ContinentId",
                table: "Countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fishes",
                table: "Fishes");

            migrationBuilder.DropIndex(
                name: "IX_Fishes_FishGenusId",
                table: "Fishes");

            migrationBuilder.DropColumn(
                name: "ContinentId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "FishGenusId",
                table: "Fishes");

            migrationBuilder.RenameTable(
                name: "Fishes",
                newName: "Fish");

            migrationBuilder.RenameColumn(
                name: "FishFamilyId",
                table: "Fish",
                newName: "FamilyId");

            migrationBuilder.RenameIndex(
                name: "IX_Fishes_UserId",
                table: "Fish",
                newName: "IX_Fish_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Fishes_FishFamilyId",
                table: "Fish",
                newName: "IX_Fish_FamilyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fish",
                table: "Fish",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fish_FishFamilies_FamilyId",
                table: "Fish",
                column: "FamilyId",
                principalTable: "FishFamilies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fish_AspNetUsers_UserId",
                table: "Fish",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
