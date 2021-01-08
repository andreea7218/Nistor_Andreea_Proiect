using Microsoft.EntityFrameworkCore.Migrations;

namespace Nistor_Andreea_Proiect.Migrations
{
    public partial class DrugCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PartnerID",
                table: "Drug",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Partner",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartnerName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partner", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DrugCategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrugID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DrugCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrugCategory_Drug_DrugID",
                        column: x => x.DrugID,
                        principalTable: "Drug",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drug_PartnerID",
                table: "Drug",
                column: "PartnerID");

            migrationBuilder.CreateIndex(
                name: "IX_DrugCategory_CategoryID",
                table: "DrugCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_DrugCategory_DrugID",
                table: "DrugCategory",
                column: "DrugID");

            migrationBuilder.AddForeignKey(
                name: "FK_Drug_Partner_PartnerID",
                table: "Drug",
                column: "PartnerID",
                principalTable: "Partner",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drug_Partner_PartnerID",
                table: "Drug");

            migrationBuilder.DropTable(
                name: "DrugCategory");

            migrationBuilder.DropTable(
                name: "Partner");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Drug_PartnerID",
                table: "Drug");

            migrationBuilder.DropColumn(
                name: "PartnerID",
                table: "Drug");
        }
    }
}
