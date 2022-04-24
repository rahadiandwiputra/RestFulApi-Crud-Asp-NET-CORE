using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SamuraiApp.Data.Migrations
{
    public partial class manytomanyelement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elements_Swords_SwordId",
                table: "Elements");

            migrationBuilder.DropForeignKey(
                name: "FK_Swords_Samurais_SamuraiId",
                table: "Swords");

            migrationBuilder.DropIndex(
                name: "IX_Elements_SwordId",
                table: "Elements");

            migrationBuilder.DropColumn(
                name: "SwordId",
                table: "Elements");

            migrationBuilder.AlterColumn<int>(
                name: "SamuraiId",
                table: "Swords",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Swords_Samurais_SamuraiId",
                table: "Swords",
                column: "SamuraiId",
                principalTable: "Samurais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BattleSamurai_Elements_ElementsId",
                table: "BattleSamurai");

            migrationBuilder.DropForeignKey(
                name: "FK_BattleSamurai_Swords_SwordsId",
                table: "BattleSamurai");

            migrationBuilder.DropForeignKey(
                name: "FK_Swords_Samurais_SamuraiId",
                table: "Swords");

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

            migrationBuilder.AlterColumn<int>(
                name: "SamuraiId",
                table: "Swords",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SwordId",
                table: "Elements",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Elements_SwordId",
                table: "Elements",
                column: "SwordId");

            migrationBuilder.AddForeignKey(
                name: "FK_Elements_Swords_SwordId",
                table: "Elements",
                column: "SwordId",
                principalTable: "Swords",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Swords_Samurais_SamuraiId",
                table: "Swords",
                column: "SamuraiId",
                principalTable: "Samurais",
                principalColumn: "Id");
        }
    }
}
