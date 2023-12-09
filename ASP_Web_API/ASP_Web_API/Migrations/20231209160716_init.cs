using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ASP_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuoteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_Quotes_QuoteId",
                        column: x => x.QuoteId,
                        principalTable: "Quotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuoteTags",
                columns: table => new
                {
                    QuoteId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteTags", x => new { x.QuoteId, x.TagId });
                    table.ForeignKey(
                        name: "FK_QuoteTags_Quotes_QuoteId",
                        column: x => x.QuoteId,
                        principalTable: "Quotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuoteTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cdefbf5d-aae6-472f-9b5b-42cd0746dbc9", null, "User", "USER" });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Author", "Text" },
                values: new object[,]
                {
                    { 1, "Mahatma Gandhi", "You must be the change you wish to see in the world." },
                    { 2, "Mother Teresa", "Spread love everywhere you go. Let no one ever come to you without leaving happier." },
                    { 3, "Franklin D. Roosevelt", "The only thing we have to fear is fear itself." },
                    { 4, "Martin Luther King Jr.", "Darkness cannot drive out darkness: only light can do that. Hate cannot drive out hate: only love can do that." },
                    { 5, "Eleanor Roosevelt", "Do one thing every day that scares you." },
                    { 6, "Benjamin Franklin", "Well done is better than well said." },
                    { 7, "Helen Keller", "The best and most beautiful things in the world cannot be seen or even touched - they must be felt with the heart." },
                    { 8, "Aristotle", "It is during our darkest moments that we must focus to see the light." },
                    { 9, "Ralph Waldo Emerson", "Do not go where the path may lead, go instead where there is no path and leave a trail." },
                    { 10, "Oscar Wilde", "Be yourself; everyone else is already taken." },
                    { 11, "Eleanor Roosevelt", "If life were predictable it would cease to be life and be without flavor." },
                    { 12, "Abraham Lincoln", "In the end, it's not the years in your life that count. It's the life in your years." },
                    { 13, "Ralph Waldo Emerson", "Life is a succession of lessons which must be lived to be understood." },
                    { 14, "Maya Angelou", "You will face many defeats in life, but never let yourself be defeated." },
                    { 15, "Babe Ruth", "Never let the fear of striking out keep you from playing the game." },
                    { 16, "Oscar Wilde", "Life is never fair, and perhaps it is a good thing for most of us that it is not." },
                    { 17, "Tony Robbins", "The only impossible journey is the one you never begin." },
                    { 18, "Mother Teresa", "In this life we cannot do great things. We can only do small things with great love." },
                    { 19, "Albert Einstein", "Only a life lived for others is a life worthwhile." },
                    { 20, "Dalai Lama", "The purpose of our lives is to be happy." },
                    { 21, "John Lennon", "You may say I'm a dreamer, but I'm not the only one. I hope someday you'll join us. And the world will live as one." },
                    { 22, "Mae West", "You only live once, but if you do it right, once is enough." },
                    { 23, "Ralph Waldo Emerson", "To be yourself in a world that is constantly trying to make you something else is the greatest accomplishment." },
                    { 24, "Abraham Lincoln", "Don't worry when you are not recognized, but strive to be worthy of recognition." },
                    { 25, "Nelson Mandela", "The greatest glory in living lies not in never falling, but in rising every time we fall." }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Leadership" },
                    { 2, "Motivational" },
                    { 3, "Life" },
                    { 4, "Attitude" },
                    { 5, "Wisdom" },
                    { 6, "Love" },
                    { 7, "Happiness" }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "QuoteId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 10, 10 },
                    { 11, 11 },
                    { 12, 12 },
                    { 13, 13 },
                    { 14, 14 },
                    { 15, 15 },
                    { 16, 16 },
                    { 17, 17 },
                    { 18, 18 },
                    { 19, 19 },
                    { 20, 20 },
                    { 21, 21 },
                    { 22, 22 },
                    { 23, 23 },
                    { 24, 24 },
                    { 25, 25 },
                    { 26, 3 },
                    { 27, 1 },
                    { 28, 7 },
                    { 29, 17 },
                    { 30, 17 },
                    { 31, 15 },
                    { 32, 13 },
                    { 33, 11 },
                    { 34, 21 },
                    { 35, 17 },
                    { 36, 24 },
                    { 37, 7 },
                    { 38, 15 },
                    { 39, 12 },
                    { 40, 1 },
                    { 41, 6 },
                    { 42, 22 },
                    { 43, 5 },
                    { 44, 15 },
                    { 45, 9 },
                    { 46, 21 },
                    { 47, 20 },
                    { 48, 25 },
                    { 49, 13 },
                    { 50, 13 },
                    { 51, 12 },
                    { 52, 9 },
                    { 53, 15 },
                    { 54, 16 },
                    { 55, 24 },
                    { 56, 21 },
                    { 57, 14 },
                    { 58, 10 },
                    { 59, 15 },
                    { 60, 15 },
                    { 61, 24 },
                    { 62, 5 },
                    { 63, 21 },
                    { 64, 1 },
                    { 65, 24 },
                    { 66, 10 },
                    { 67, 21 },
                    { 68, 19 },
                    { 69, 8 },
                    { 70, 14 },
                    { 71, 19 },
                    { 72, 1 },
                    { 73, 5 },
                    { 74, 5 },
                    { 75, 22 },
                    { 76, 17 },
                    { 77, 9 },
                    { 78, 3 },
                    { 79, 25 },
                    { 80, 7 },
                    { 81, 10 },
                    { 82, 2 },
                    { 83, 16 },
                    { 84, 17 },
                    { 85, 5 },
                    { 86, 13 },
                    { 87, 15 },
                    { 88, 23 },
                    { 89, 5 },
                    { 90, 1 },
                    { 91, 15 },
                    { 92, 3 },
                    { 93, 22 },
                    { 94, 11 },
                    { 95, 6 },
                    { 96, 11 },
                    { 97, 2 },
                    { 98, 16 },
                    { 99, 15 },
                    { 100, 12 },
                    { 101, 14 },
                    { 102, 1 },
                    { 103, 7 },
                    { 104, 11 },
                    { 105, 16 },
                    { 106, 19 },
                    { 107, 22 },
                    { 108, 17 },
                    { 109, 10 },
                    { 110, 2 },
                    { 111, 3 },
                    { 112, 23 },
                    { 113, 19 },
                    { 114, 15 },
                    { 115, 13 },
                    { 116, 23 },
                    { 117, 20 },
                    { 118, 6 },
                    { 119, 8 },
                    { 120, 18 },
                    { 121, 16 },
                    { 122, 20 },
                    { 123, 11 },
                    { 124, 17 },
                    { 125, 17 },
                    { 126, 23 },
                    { 127, 4 },
                    { 128, 10 },
                    { 129, 18 },
                    { 130, 7 },
                    { 131, 19 },
                    { 132, 15 },
                    { 133, 12 },
                    { 134, 4 },
                    { 135, 12 },
                    { 136, 4 },
                    { 137, 17 },
                    { 138, 17 },
                    { 139, 24 },
                    { 140, 17 },
                    { 141, 5 },
                    { 142, 3 },
                    { 143, 2 },
                    { 144, 2 },
                    { 145, 10 },
                    { 146, 17 },
                    { 147, 19 },
                    { 148, 7 },
                    { 149, 20 },
                    { 150, 25 },
                    { 151, 5 },
                    { 152, 20 },
                    { 153, 19 },
                    { 154, 3 },
                    { 155, 2 },
                    { 156, 7 },
                    { 157, 22 },
                    { 158, 11 },
                    { 159, 24 },
                    { 160, 25 },
                    { 161, 12 },
                    { 162, 23 },
                    { 163, 15 },
                    { 164, 6 },
                    { 165, 16 },
                    { 166, 13 },
                    { 167, 10 },
                    { 168, 14 },
                    { 169, 5 },
                    { 170, 2 },
                    { 171, 11 },
                    { 172, 17 },
                    { 173, 18 },
                    { 174, 10 },
                    { 175, 21 }
                });

            migrationBuilder.InsertData(
                table: "QuoteTags",
                columns: new[] { "QuoteId", "TagId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 3 },
                    { 7, 3 },
                    { 8, 3 },
                    { 9, 5 },
                    { 10, 5 },
                    { 11, 5 },
                    { 12, 6 },
                    { 13, 6 },
                    { 14, 6 },
                    { 15, 7 },
                    { 16, 7 },
                    { 17, 7 },
                    { 18, 7 },
                    { 19, 1 },
                    { 20, 1 },
                    { 21, 1 },
                    { 22, 1 },
                    { 23, 1 },
                    { 24, 2 },
                    { 25, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_QuoteId",
                table: "Likes",
                column: "QuoteId");

            migrationBuilder.CreateIndex(
                name: "IX_QuoteTags_TagId",
                table: "QuoteTags",
                column: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "QuoteTags");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Quotes");

            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}
