using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreDrillsApi.Migrations
{
    /// <inheritdoc />
    public partial class AddEmergencyPhoneToStudentProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmergencyPhone",
                table: "StudentProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmergencyPhone",
                table: "StudentProfiles");
        }
    }
}
