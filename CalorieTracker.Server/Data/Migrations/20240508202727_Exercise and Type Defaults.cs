using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CalorieTracker.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExerciseandTypeDefaults : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "ExerciseTypeId", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cardio", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Strength", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Exercise",
                columns: new[] { "ExerciseId", "CreatedAt", "ExerciseTypeId", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Running", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Cycling", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Swimming", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Walking", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Weightlifting", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Bodyweight", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Yoga", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "ExerciseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "ExerciseId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "ExerciseId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "ExerciseId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "ExerciseId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "ExerciseId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "ExerciseId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "ExerciseTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "ExerciseTypeId",
                keyValue: 2);
        }
    }
}
