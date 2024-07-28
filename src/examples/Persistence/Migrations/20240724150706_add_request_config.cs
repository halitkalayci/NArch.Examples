using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_request_config : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("7b944e6b-d1f0-4853-863c-d4322ec4a9cc"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9990f432-a69d-49cf-b8c2-088d970f6bc4"));

            migrationBuilder.CreateTable(
                name: "RequestConfigs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestOperationClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestConfigId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OperationClaimId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestOperationClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestOperationClaims_OperationClaims_OperationClaimId",
                        column: x => x.OperationClaimId,
                        principalTable: "OperationClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestOperationClaims_RequestConfigs_RequestConfigId",
                        column: x => x.RequestConfigId,
                        principalTable: "RequestConfigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "RequestConfigs.Admin", null },
                    { 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "RequestConfigs.Read", null },
                    { 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "RequestConfigs.Write", null },
                    { 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "RequestConfigs.Create", null },
                    { 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "RequestConfigs.Update", null },
                    { 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "RequestConfigs.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("25862fc0-f0d9-4483-8573-a64ad07514e6"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 127, 89, 160, 97, 156, 134, 32, 57, 201, 5, 120, 58, 113, 26, 255, 189, 168, 15, 47, 174, 54, 168, 111, 78, 170, 111, 91, 209, 66, 175, 100, 83, 147, 6, 18, 133, 145, 26, 152, 255, 214, 157, 212, 215, 202, 201, 171, 35, 89, 66, 71, 169, 25, 239, 252, 216, 210, 198, 179, 49, 225, 248, 221, 26 }, new byte[] { 4, 33, 144, 251, 127, 80, 26, 203, 84, 83, 118, 248, 40, 233, 44, 12, 52, 168, 144, 176, 205, 130, 232, 232, 150, 134, 231, 237, 134, 152, 29, 62, 55, 243, 254, 89, 125, 201, 132, 245, 26, 238, 245, 227, 190, 218, 205, 3, 108, 178, 120, 101, 129, 217, 123, 212, 40, 248, 169, 108, 236, 26, 49, 193, 184, 125, 164, 48, 67, 133, 77, 239, 80, 63, 221, 137, 238, 106, 49, 8, 184, 19, 236, 177, 192, 5, 33, 62, 131, 161, 41, 18, 88, 0, 255, 173, 199, 127, 127, 66, 237, 239, 191, 53, 104, 197, 18, 220, 81, 155, 118, 24, 185, 149, 214, 76, 207, 124, 212, 91, 20, 81, 68, 209, 42, 248, 43, 252 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("69cd90a3-12b4-43f9-88ab-367db8ab0438"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("25862fc0-f0d9-4483-8573-a64ad07514e6") });

            migrationBuilder.CreateIndex(
                name: "IX_RequestOperationClaims_OperationClaimId",
                table: "RequestOperationClaims",
                column: "OperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestOperationClaims_RequestConfigId",
                table: "RequestOperationClaims",
                column: "RequestConfigId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestOperationClaims");

            migrationBuilder.DropTable(
                name: "RequestConfigs");

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("69cd90a3-12b4-43f9-88ab-367db8ab0438"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("25862fc0-f0d9-4483-8573-a64ad07514e6"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("9990f432-a69d-49cf-b8c2-088d970f6bc4"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 131, 63, 235, 77, 162, 77, 207, 45, 150, 148, 194, 25, 146, 145, 41, 56, 10, 223, 184, 33, 132, 79, 82, 71, 53, 117, 250, 236, 65, 129, 20, 183, 111, 19, 37, 42, 98, 13, 16, 95, 121, 160, 95, 240, 15, 51, 130, 14, 26, 190, 8, 65, 96, 95, 233, 46, 56, 29, 186, 154, 115, 230, 91, 144 }, new byte[] { 8, 69, 113, 233, 246, 52, 77, 155, 140, 35, 42, 52, 0, 43, 218, 96, 202, 169, 104, 85, 120, 139, 10, 97, 78, 90, 47, 73, 136, 148, 65, 198, 223, 76, 138, 4, 246, 77, 161, 136, 238, 252, 238, 238, 90, 86, 226, 253, 27, 56, 63, 122, 176, 83, 120, 50, 92, 184, 126, 229, 56, 1, 160, 170, 18, 45, 21, 237, 60, 118, 207, 67, 212, 195, 84, 238, 81, 227, 34, 215, 200, 57, 69, 76, 137, 212, 249, 195, 145, 175, 202, 145, 94, 234, 194, 236, 135, 30, 19, 243, 3, 109, 122, 29, 37, 128, 139, 235, 3, 21, 34, 39, 212, 139, 111, 71, 112, 182, 230, 83, 14, 115, 179, 65, 119, 94, 75, 103 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("7b944e6b-d1f0-4853-863c-d4322ec4a9cc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("9990f432-a69d-49cf-b8c2-088d970f6bc4") });
        }
    }
}
