using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CalorieTracker.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class Defaultexercisevalues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "ExerciseTypeId", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Running", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Walking", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cycling", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Swimming", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Weightlifting", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yoga", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pilates", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dancing", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Boxing", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "ExerciseTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "ExerciseTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "ExerciseTypeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "ExerciseTypeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "ExerciseTypeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "ExerciseTypeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "ExerciseTypeId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "ExerciseTypeId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "ExerciseTypeId",
                keyValue: 9);
        }
    }
}
