using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bilgi_SayarUI.Migrations
{
    /// <inheritdoc />
    public partial class updateWriter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "637e09c0-0f46-4785-a4bc-9763c641ae15");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c2dc8e3-67fa-48f2-84e5-69673dcb1e9f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e93edd9b-8ff6-4a57-92f9-0f57fd1af703");

            migrationBuilder.AddColumn<bool>(
                name: "WriterStatu",
                table: "Writers",
                type: "bit",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0232bc83-95ed-4e5f-bd2b-294f9fcb8ed5", null, "Editor", "EDITOR" },
                    { "8b209da4-aaa1-4cd8-8a8f-ee12e88413ed", null, "Admin", "ADMIN" },
                    { "e7b65e46-874c-4a68-a550-14bb5e69e21f", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0232bc83-95ed-4e5f-bd2b-294f9fcb8ed5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b209da4-aaa1-4cd8-8a8f-ee12e88413ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7b65e46-874c-4a68-a550-14bb5e69e21f");

            migrationBuilder.DropColumn(
                name: "WriterStatu",
                table: "Writers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "637e09c0-0f46-4785-a4bc-9763c641ae15", null, "User", "USER" },
                    { "9c2dc8e3-67fa-48f2-84e5-69673dcb1e9f", null, "Editor", "EDITOR" },
                    { "e93edd9b-8ff6-4a57-92f9-0f57fd1af703", null, "Admin", "ADMIN" }
                });
        }
    }
}
