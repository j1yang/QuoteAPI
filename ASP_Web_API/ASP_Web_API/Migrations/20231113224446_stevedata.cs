using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ASP_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class stevedata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "QuoteId" },
                values: new object[,]
                {
                    { 4, 4 },
                    { 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "QuoteTag",
                columns: new[] { "QuoteId", "TagId" },
                values: new object[] { 5, 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "QuoteTag",
                keyColumns: new[] { "QuoteId", "TagId" },
                keyValues: new object[] { 5, 2 });
        }
    }
}
