using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Blazor8WithRolesAndSignalR.Migrations
{
    /// <inheritdoc />
    public partial class AddUsersWithMixedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "9aec66ee-db18-499e-9b0d-24f2e100b882", 0, "d95f09c1-a166-434a-9207-24ec56f6e6c4", "sally@sally.com", true, true, null, "SALLY@SALLY.COM", "SALLY@SALLY.COM", "AQAAAAIAAYagAAAAEERZ/Fm8OS2jn3C1ZFm4KVax9pjknE+7nkSEteI2VI/PTln2fbZQcJCpcYYhuYyPpg==", null, false, "HULL3RUQ53EXBH7OIQKBPSTDHHUJE36J", false, "sally@sally.com" },
                    { "e496845c-71bd-4517-afa9-81c8f59d83cc", 0, "d95f09c1-a166-434a-9207-24ec56f6e6c4", "joe@joe.com", true, true, null, "JOE@JOE.COM", "JOE@JOE.COM", "AQAAAAIAAYagAAAAEERZ/Fm8OS2jn3C1ZFm4KVax9pjknE+7nkSEteI2VI/PTln2fbZQcJCpcYYhuYyPpg==", null, false, "HULL3RUQ53EXBH7OIQKBPSTDHHUJE36J", false, "joe@joe.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "19d34cdf-507b-4a2f-a5ab-66018c887db5", "9aec66ee-db18-499e-9b0d-24f2e100b882" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "19d34cdf-507b-4a2f-a5ab-66018c887db5", "9aec66ee-db18-499e-9b0d-24f2e100b882" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e496845c-71bd-4517-afa9-81c8f59d83cc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9aec66ee-db18-499e-9b0d-24f2e100b882");
        }
    }
}
