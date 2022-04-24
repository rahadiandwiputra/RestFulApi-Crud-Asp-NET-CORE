using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SamuraiApp.Data.Migrations
{
    public partial class relationelementsword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BattleSamurai_Elements_ElementsId",
                table: "BattleSamurai");

            migrationBuilder.DropForeignKey(
                name: "FK_BattleSamurai_Swords_SwordsId",
                table: "BattleSamurai");

            migrationBuilder.DropIndex(
                name: "IX_BattleSamurai_ElementsId",
                table: "BattleSamurai");

            migrationBuilder.DropIndex(
                name: "IX_BattleSamurai_SwordsId",
                table: "BattleSamurai");

            migrationBuilder.DropColumn(
                name: "ElementsId",
                table: "BattleSamurai");

            migrationBuilder.DropColumn(
                name: "SwordsId",
                table: "BattleSamurai");

            migrationBuilder.CreateTable(
                name: "SwordElement",
                columns: table => new
                {
                    SwordId = table.Column<int>(type: "int", nullable: false),
                    ElementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SwordElement", x => new { x.ElementId, x.SwordId });
                    table.ForeignKey(
                        name: "FK_SwordElement_Elements_ElementId",
                        column: x => x.ElementId,
                        principalTable: "Elements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SwordElement_Swords_SwordId",
                        column: x => x.SwordId,
                        principalTable: "Swords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SwordElement_SwordId",
                table: "SwordElement",
                column: "SwordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SwordElement");

            migrationBuilder.AddColumn<int>(
                name: "ElementsId",
                table: "BattleSamurai",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SwordsId",
                table: "BattleSamurai",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BattleSamurai_ElementsId",
                table: "BattleSamurai",
                column: "ElementsId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleSamurai_SwordsId",
                table: "BattleSamurai",
                column: "SwordsId");

            migrationBuilder.AddForeignKey(
                name: "FK_BattleSamurai_Elements_ElementsId",
                table: "BattleSamurai",
                column: "ElementsId",
                principalTable: "Elements",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BattleSamurai_Swords_SwordsId",
                table: "BattleSamurai",
                column: "SwordsId",
                principalTable: "Swords",
                principalColumn: "Id");
        }
    }
}
