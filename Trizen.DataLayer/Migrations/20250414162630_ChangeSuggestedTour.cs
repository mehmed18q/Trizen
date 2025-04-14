using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trizen.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSuggestedTour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuggestedTours_Personalities_PersonalityId",
                table: "SuggestedTours");

            migrationBuilder.AlterColumn<int>(
                name: "UserAge",
                table: "SuggestedTours",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PersonalityId",
                table: "SuggestedTours",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "SuggestedTours",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_SuggestedTours_Personalities_PersonalityId",
                table: "SuggestedTours",
                column: "PersonalityId",
                principalTable: "Personalities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuggestedTours_Personalities_PersonalityId",
                table: "SuggestedTours");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "SuggestedTours");

            migrationBuilder.AlterColumn<int>(
                name: "UserAge",
                table: "SuggestedTours",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonalityId",
                table: "SuggestedTours",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SuggestedTours_Personalities_PersonalityId",
                table: "SuggestedTours",
                column: "PersonalityId",
                principalTable: "Personalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
