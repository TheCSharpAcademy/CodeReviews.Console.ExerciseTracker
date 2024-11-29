using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExerciseTracker.Mefdev.Migrations
{
    /// <inheritdoc />
    public partial class IntialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Comments", "DateEnd", "DateStart", "Duration", "Type" },
                values: new object[,]
                {
                    { 1, "Morning workout: Running and stretching.", new DateTime(2024, 11, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0), "Cardio" },
                    { 2, "Strength training: Upper body workout.", new DateTime(2024, 11, 2, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0), "Strength" },
                    { 3, "Yoga and stretching session.", new DateTime(2024, 11, 3, 8, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 3, 7, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0), "Flexibility" },
                    { 4, "Cycling and cardio exercises.", new DateTime(2024, 11, 4, 7, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 4, 6, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0), "Cardio" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercises");
        }
    }
}
