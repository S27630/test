using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication4.Migrations
{
    /// <inheritdoc />
    public partial class MIG4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "ID", "FirstName", "LastName" },
                values: new object[] { 1, "John", "Doe" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ID", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Product A", 10.5m },
                    { 2, "Product B", 15.75m }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "Completed" }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "ID", "ClientID", "CreatedAt", "FulfilledAt", "StatusID" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 6, 6, 19, 18, 18, 113, DateTimeKind.Local).AddTicks(3060), null, 1 },
                    { 2, 1, new DateTime(2024, 6, 5, 19, 18, 18, 113, DateTimeKind.Local).AddTicks(3149), null, 2 }
                });

            migrationBuilder.InsertData(
                table: "Product_Order",
                columns: new[] { "OrderID", "ProductID", "Amount" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 2, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product_Order",
                keyColumns: new[] { "OrderID", "ProductID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Product_Order",
                keyColumns: new[] { "OrderID", "ProductID" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "ID",
                keyValue: 2);
        }
    }
}
