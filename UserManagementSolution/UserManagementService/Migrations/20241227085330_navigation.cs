using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagementService.Migrations
{
    /// <inheritdoc />
    public partial class navigation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Key", "Password" },
                values: new object[] { new byte[] { 97, 64, 151, 195, 63, 200, 98, 43, 34, 104, 153, 9, 164, 228, 78, 180, 142, 136, 179, 233, 186, 77, 230, 208, 104, 178, 178, 59, 37, 168, 200, 43, 165, 109, 160, 82, 189, 255, 16, 166, 73, 203, 46, 52, 99, 76, 69, 170, 103, 41, 233, 131, 49, 235, 83, 32, 81, 237, 71, 76, 52, 57, 41, 33 }, new byte[] { 101, 53, 98, 50, 55, 126, 53, 72, 145, 31, 144, 98, 107, 151, 205, 23, 113, 72, 23, 103, 236, 237, 125, 249, 64, 175, 1, 11, 233, 178, 95, 36 } });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_UserId",
                table: "Patients",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_UserId",
                table: "Doctors",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Users_UserId",
                table: "Doctors",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Users_UserId",
                table: "Patients",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Users_UserId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Users_UserId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_UserId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_UserId",
                table: "Doctors");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Key", "Password" },
                values: new object[] { new byte[] { 188, 91, 42, 2, 90, 35, 236, 199, 7, 99, 100, 70, 88, 156, 106, 62, 173, 239, 54, 161, 71, 114, 21, 199, 196, 64, 97, 152, 216, 157, 224, 133, 114, 157, 4, 29, 253, 135, 84, 128, 47, 224, 50, 113, 107, 206, 85, 251, 12, 165, 2, 102, 166, 42, 232, 224, 182, 37, 10, 23, 13, 208, 107, 242 }, new byte[] { 52, 23, 61, 32, 190, 196, 112, 44, 149, 204, 141, 200, 94, 149, 217, 138, 159, 98, 77, 33, 244, 18, 97, 160, 152, 135, 45, 237, 47, 239, 26, 117 } });
        }
    }
}
