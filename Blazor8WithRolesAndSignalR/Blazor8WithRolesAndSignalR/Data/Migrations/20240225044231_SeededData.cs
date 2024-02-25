using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Blazor8WithRolesAndSignalR.Migrations
{
    /// <inheritdoc />
    public partial class SeededData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "19d34cdf-507b-4a2f-a5ab-66018c887db5", "d95f09c1-a166-434a-9207-24ec56f6e6c4", "Moderator", "MODERATOR" },
                    { "9a9dbeda-c681-48db-b4a7-c79c5259bf94", "d95f09c1-a166-434a-9207-24ec56f6e6c4", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9c3e219c-1e63-4628-9b08-bc76ef648729", 0, "d95f09c1-a166-434a-9207-24ec56f6e6c4", "bob@bob.com", true, true, null, "BOB@BOB.COM", "BOB@BOB.COM", "AQAAAAIAAYagAAAAEERZ/Fm8OS2jn3C1ZFm4KVax9pjknE+7nkSEteI2VI/PTln2fbZQcJCpcYYhuYyPpg==", null, false, "HULL3RUQ53EXBH7OIQKBPSTDHHUJE36J", false, "bob@bob.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "19d34cdf-507b-4a2f-a5ab-66018c887db5", "9c3e219c-1e63-4628-9b08-bc76ef648729" },
                    { "9a9dbeda-c681-48db-b4a7-c79c5259bf94", "9c3e219c-1e63-4628-9b08-bc76ef648729" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "19d34cdf-507b-4a2f-a5ab-66018c887db5", "9c3e219c-1e63-4628-9b08-bc76ef648729" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9a9dbeda-c681-48db-b4a7-c79c5259bf94", "9c3e219c-1e63-4628-9b08-bc76ef648729" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19d34cdf-507b-4a2f-a5ab-66018c887db5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a9dbeda-c681-48db-b4a7-c79c5259bf94");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c3e219c-1e63-4628-9b08-bc76ef648729");
        }
    }
}
