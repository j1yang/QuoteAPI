using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class quotetag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuoteTag_Quotes_QuoteId",
                table: "QuoteTag");

            migrationBuilder.DropForeignKey(
                name: "FK_QuoteTag_Tags_TagId",
                table: "QuoteTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuoteTag",
                table: "QuoteTag");

            migrationBuilder.RenameTable(
                name: "QuoteTag",
                newName: "QuoteTags");

            migrationBuilder.RenameIndex(
                name: "IX_QuoteTag_TagId",
                table: "QuoteTags",
                newName: "IX_QuoteTags_TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuoteTags",
                table: "QuoteTags",
                columns: new[] { "QuoteId", "TagId" });

            migrationBuilder.AddForeignKey(
                name: "FK_QuoteTags_Quotes_QuoteId",
                table: "QuoteTags",
                column: "QuoteId",
                principalTable: "Quotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuoteTags_Tags_TagId",
                table: "QuoteTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuoteTags_Quotes_QuoteId",
                table: "QuoteTags");

            migrationBuilder.DropForeignKey(
                name: "FK_QuoteTags_Tags_TagId",
                table: "QuoteTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuoteTags",
                table: "QuoteTags");

            migrationBuilder.RenameTable(
                name: "QuoteTags",
                newName: "QuoteTag");

            migrationBuilder.RenameIndex(
                name: "IX_QuoteTags_TagId",
                table: "QuoteTag",
                newName: "IX_QuoteTag_TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuoteTag",
                table: "QuoteTag",
                columns: new[] { "QuoteId", "TagId" });

            migrationBuilder.AddForeignKey(
                name: "FK_QuoteTag_Quotes_QuoteId",
                table: "QuoteTag",
                column: "QuoteId",
                principalTable: "Quotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuoteTag_Tags_TagId",
                table: "QuoteTag",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
