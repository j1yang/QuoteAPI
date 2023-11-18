using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ASP_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class newdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "QuoteTags",
                keyColumns: new[] { "QuoteId", "TagId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "QuoteTags",
                keyColumns: new[] { "QuoteId", "TagId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "QuoteTags",
                keyColumns: new[] { "QuoteId", "TagId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "QuoteId" },
                values: new object[,]
                {
                    { 31, 1 },
                    { 39, 2 },
                    { 42, 4 },
                    { 52, 5 },
                    { 64, 4 },
                    { 65, 2 },
                    { 66, 5 },
                    { 68, 4 },
                    { 73, 2 },
                    { 75, 1 },
                    { 80, 2 },
                    { 84, 3 },
                    { 89, 3 },
                    { 92, 3 },
                    { 96, 5 },
                    { 103, 3 },
                    { 107, 5 },
                    { 109, 5 },
                    { 114, 4 },
                    { 121, 5 },
                    { 127, 3 },
                    { 129, 1 },
                    { 131, 1 },
                    { 134, 5 },
                    { 136, 4 },
                    { 145, 4 },
                    { 155, 4 },
                    { 163, 1 },
                    { 167, 1 }
                });

            migrationBuilder.InsertData(
                table: "QuoteTags",
                columns: new[] { "QuoteId", "TagId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 }
                });

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Author", "Text" },
                values: new object[] { "Mahatma Gandhi", "You must be the change you wish to see in the world." });

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Author", "Text" },
                values: new object[] { "Mother Teresa", "Spread love everywhere you go. Let no one ever come to you without leaving happier." });

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Author", "Text" },
                values: new object[] { "Franklin D. Roosevelt", "The only thing we have to fear is fear itself." });

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Author", "Text" },
                values: new object[] { "Martin Luther King Jr.", "Darkness cannot drive out darkness: only light can do that. Hate cannot drive out hate: only love can do that." });

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Author", "Text" },
                values: new object[] { "Eleanor Roosevelt", "Do one thing every day that scares you." });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Author", "Text" },
                values: new object[,]
                {
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
                table: "Likes",
                columns: new[] { "Id", "QuoteId" },
                values: new object[,]
                {
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
                    { 26, 20 },
                    { 27, 6 },
                    { 28, 6 },
                    { 29, 19 },
                    { 30, 19 },
                    { 32, 13 },
                    { 33, 19 },
                    { 34, 21 },
                    { 35, 6 },
                    { 36, 17 },
                    { 37, 17 },
                    { 38, 15 },
                    { 40, 6 },
                    { 41, 18 },
                    { 43, 6 },
                    { 44, 19 },
                    { 45, 22 },
                    { 46, 9 },
                    { 47, 15 },
                    { 48, 11 },
                    { 49, 21 },
                    { 50, 19 },
                    { 51, 24 },
                    { 53, 18 },
                    { 54, 14 },
                    { 55, 16 },
                    { 56, 21 },
                    { 57, 23 },
                    { 58, 16 },
                    { 59, 13 },
                    { 60, 12 },
                    { 61, 6 },
                    { 62, 10 },
                    { 63, 20 },
                    { 67, 19 },
                    { 69, 16 },
                    { 70, 11 },
                    { 71, 11 },
                    { 72, 22 },
                    { 74, 10 },
                    { 76, 23 },
                    { 77, 21 },
                    { 78, 10 },
                    { 79, 23 },
                    { 81, 12 },
                    { 82, 21 },
                    { 83, 11 },
                    { 85, 8 },
                    { 86, 21 },
                    { 87, 15 },
                    { 88, 14 },
                    { 90, 13 },
                    { 91, 21 },
                    { 93, 12 },
                    { 94, 10 },
                    { 95, 22 },
                    { 97, 19 },
                    { 98, 12 },
                    { 99, 12 },
                    { 100, 17 },
                    { 101, 16 },
                    { 102, 6 },
                    { 104, 17 },
                    { 105, 7 },
                    { 106, 8 },
                    { 108, 21 },
                    { 110, 13 },
                    { 111, 19 },
                    { 112, 8 },
                    { 113, 25 },
                    { 115, 13 },
                    { 116, 15 },
                    { 117, 17 },
                    { 118, 25 },
                    { 119, 10 },
                    { 120, 18 },
                    { 122, 18 },
                    { 123, 9 },
                    { 124, 25 },
                    { 125, 9 },
                    { 126, 19 },
                    { 128, 20 },
                    { 130, 16 },
                    { 132, 16 },
                    { 133, 19 },
                    { 135, 17 },
                    { 137, 25 },
                    { 138, 24 },
                    { 139, 23 },
                    { 140, 19 },
                    { 141, 12 },
                    { 142, 14 },
                    { 143, 6 },
                    { 144, 21 },
                    { 146, 16 },
                    { 147, 15 },
                    { 148, 6 },
                    { 149, 23 },
                    { 150, 14 },
                    { 151, 13 },
                    { 152, 21 },
                    { 153, 8 },
                    { 154, 14 },
                    { 156, 17 },
                    { 157, 18 },
                    { 158, 19 },
                    { 159, 6 },
                    { 160, 24 },
                    { 161, 14 },
                    { 162, 13 },
                    { 164, 11 },
                    { 165, 13 },
                    { 166, 12 },
                    { 168, 17 },
                    { 169, 13 },
                    { 170, 22 },
                    { 171, 17 },
                    { 172, 24 },
                    { 173, 25 },
                    { 174, 25 },
                    { 175, 25 }
                });

            migrationBuilder.InsertData(
                table: "QuoteTags",
                columns: new[] { "QuoteId", "TagId" },
                values: new object[,]
                {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "QuoteTags",
                keyColumns: new[] { "QuoteId", "TagId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "QuoteTags",
                keyColumns: new[] { "QuoteId", "TagId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "QuoteTags",
                keyColumns: new[] { "QuoteId", "TagId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "QuoteTags",
                keyColumns: new[] { "QuoteId", "TagId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "QuoteTags",
                keyColumns: new[] { "QuoteId", "TagId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "QuoteTags",
                keyColumns: new[] { "QuoteId", "TagId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "QuoteTags",
                keyColumns: new[] { "QuoteId", "TagId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "QuoteTags",
                keyColumns: new[] { "QuoteId", "TagId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "QuoteTags",
                keyColumns: new[] { "QuoteId", "TagId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "QuoteTags",
                keyColumns: new[] { "QuoteId", "TagId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "QuoteTags",
                keyColumns: new[] { "QuoteId", "TagId" },
                keyValues: new object[] { 9, 5 });

            migrationBuilder.DeleteData(
                table: "QuoteTags",
                keyColumns: new[] { "QuoteId", "TagId" },
                keyValues: new object[] { 10, 5 });

            migrationBuilder.DeleteData(
                table: "QuoteTags",
                keyColumns: new[] { "QuoteId", "TagId" },
                keyValues: new object[] { 11, 5 });

            migrationBuilder.DeleteData(
                table: "QuoteTags",
                keyColumns: new[] { "QuoteId", "TagId" },
                keyValues: new object[] { 12, 6 });

            migrationBuilder.DeleteData(
                table: "QuoteTags",
                keyColumns: new[] { "QuoteId", "TagId" },
                keyValues: new object[] { 13, 6 });

            migrationBuilder.DeleteData(
                table: "QuoteTags",
                keyColumns: new[] { "QuoteId", "TagId" },
                keyValues: new object[] { 14, 6 });

            migrationBuilder.DeleteData(
                table: "QuoteTags",
                keyColumns: new[] { "QuoteId", "TagId" },
                keyValues: new object[] { 15, 7 });

            migrationBuilder.DeleteData(
                table: "QuoteTags",
                keyColumns: new[] { "QuoteId", "TagId" },
                keyValues: new object[] { 16, 7 });

            migrationBuilder.DeleteData(
                table: "QuoteTags",
                keyColumns: new[] { "QuoteId", "TagId" },
                keyValues: new object[] { 17, 7 });

            migrationBuilder.DeleteData(
                table: "QuoteTags",
                keyColumns: new[] { "QuoteId", "TagId" },
                keyValues: new object[] { 18, 7 });

            migrationBuilder.DeleteData(
                table: "QuoteTags",
                keyColumns: new[] { "QuoteId", "TagId" },
                keyValues: new object[] { 19, 1 });

            migrationBuilder.DeleteData(
                table: "QuoteTags",
                keyColumns: new[] { "QuoteId", "TagId" },
                keyValues: new object[] { 20, 1 });

            migrationBuilder.DeleteData(
                table: "QuoteTags",
                keyColumns: new[] { "QuoteId", "TagId" },
                keyValues: new object[] { 21, 1 });

            migrationBuilder.DeleteData(
                table: "QuoteTags",
                keyColumns: new[] { "QuoteId", "TagId" },
                keyValues: new object[] { 22, 1 });

            migrationBuilder.DeleteData(
                table: "QuoteTags",
                keyColumns: new[] { "QuoteId", "TagId" },
                keyValues: new object[] { 23, 1 });

            migrationBuilder.DeleteData(
                table: "QuoteTags",
                keyColumns: new[] { "QuoteId", "TagId" },
                keyValues: new object[] { 24, 2 });

            migrationBuilder.DeleteData(
                table: "QuoteTags",
                keyColumns: new[] { "QuoteId", "TagId" },
                keyValues: new object[] { 25, 3 });

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.InsertData(
                table: "QuoteTags",
                columns: new[] { "QuoteId", "TagId" },
                values: new object[,]
                {
                    { 3, 1 },
                    { 4, 3 },
                    { 5, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Author", "Text" },
                values: new object[] { "Franklin D. Roosevelt", "The only limit to our realization of tomorrow will be our doubts of today." });

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Author", "Text" },
                values: new object[] { "Winston Churchill", "Success is not final, failure is not fatal: It is the courage to continue that counts." });

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Author", "Text" },
                values: new object[] { "John Lennon", "Life is what happens when you're busy making other plans." });

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Author", "Text" },
                values: new object[] { "Robert Frost", "In three words I can sum up everything I've learned about life: it goes on." });

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Author", "Text" },
                values: new object[] { "Steve Jobs", "The only way to do great work is to love what you do." });
        }
    }
}
