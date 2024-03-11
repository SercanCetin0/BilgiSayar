using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bilgi_SayarUI.Migrations
{
    /// <inheritdoc />
    public partial class Addİdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1b1ca58b-6267-4428-9e72-968a96e52aa9", null, "Admin", "ADMIN" },
                    { "a548ea74-15e4-4071-b0fb-5870bbd1024b", null, "Editor", "EDITOR" },
                    { "e41c16de-0d94-44f9-84da-d8696a45d34e", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b1ca58b-6267-4428-9e72-968a96e52aa9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a548ea74-15e4-4071-b0fb-5870bbd1024b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e41c16de-0d94-44f9-84da-d8696a45d34e");
        }
    }
}
