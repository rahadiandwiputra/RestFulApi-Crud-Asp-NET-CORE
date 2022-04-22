using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SamuraiApp.Data.Migrations
{
    public partial class tambhtambh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elements_Swords_SwordId",
                table: "Elements");

            migrationBuilder.DropForeignKey(
                name: "FK_Swords_Samurais_SamuraiId",
                table: "Swords");

            migrationBuilder.AlterColumn<int>(
                name: "SamuraiId",
                table: "Swords",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SwordId",
                table: "Elements",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elements_Swords_SwordId",
                table: "Elements");

            migrationBuilder.DropForeignKey(
                name: "FK_Swords_Samurais_SamuraiId",
                table: "Swords");

            migrationBuilder.AlterColumn<int>(
                name: "SamuraiId",
                table: "Swords",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SwordId",
                table: "Elements",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Elements_Swords_SwordId",
                table: "Elements",
                column: "SwordId",
                principalTable: "Swords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Swords_Samurais_SamuraiId",
                table: "Swords",
                column: "SamuraiId",
                principalTable: "Samurais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
