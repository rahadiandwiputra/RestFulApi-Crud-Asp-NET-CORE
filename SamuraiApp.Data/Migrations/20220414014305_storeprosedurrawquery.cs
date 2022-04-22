using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SamuraiApp.Data.Migrations
{
    public partial class storeprosedurrawquery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //mencari samurai dengan parameter text
            migrationBuilder.Sql(@"CREATE PROCEDURE dbo.SamuraisWhoSaidAWord
               @text VARCHAR(20)
               AS
               SELECT      Samurais.Id, Samurais.Name
               FROM        Samurais INNER JOIN
                           Quotes ON Samurais.Id = Quotes.SamuraiId
               WHERE      (Quotes.Name LIKE '%'+@text+'%')");
            //delete Quote dengan parameter samuraiId
            migrationBuilder.Sql(@"CREATE PROCEDURE dbo.DeleteQuotesForSamurai
             @samuraiId int
             AS
             DELETE FROM Quotes
             WHERE Quotes.SamuraiId=@samuraiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
