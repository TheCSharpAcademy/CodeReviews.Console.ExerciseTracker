using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExerciseTracker.TwilightSaw.Migrations
{
    /// <inheritdoc />
    public partial class OnUpdateType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Exercises");
        }
    }
}
