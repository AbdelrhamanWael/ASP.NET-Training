using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreDrillsApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedPaymentSummaries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PaymentSummaries",
                columns: new[] { "Id", "EnrollmentId", "PaymentStatus", "RemainingAmount", "TotalPaid", "TotalRequired" },
                values: new object[,]
                {
                    { 1, 1, "PartiallyPaid", 500m, 500m, 1000m },
                    { 2, 2, "Paid", 0m, 1000m, 1000m },
                    { 3, 3, "Paid", 0m, 1200m, 1200m },
                    { 4, 4, "Pending", 1200m, 0m, 1200m },
                    { 5, 5, "PartiallyPaid", 600m, 200m, 800m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PaymentSummaries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PaymentSummaries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PaymentSummaries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PaymentSummaries",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PaymentSummaries",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
