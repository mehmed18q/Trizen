using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trizen.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Fixer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DestinationCategory_Categories_CategoryId",
                table: "DestinationCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_DestinationCategory_Destinations_DestinationId",
                table: "DestinationCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DestinationCategory",
                table: "DestinationCategory");

            migrationBuilder.RenameTable(
                name: "DestinationCategory",
                newName: "DestinationCategories");

            migrationBuilder.RenameIndex(
                name: "IX_DestinationCategory_DestinationId",
                table: "DestinationCategories",
                newName: "IX_DestinationCategories_DestinationId");

            migrationBuilder.RenameIndex(
                name: "IX_DestinationCategory_CategoryId",
                table: "DestinationCategories",
                newName: "IX_DestinationCategories_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DestinationCategories",
                table: "DestinationCategories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DestinationCategories_Categories_CategoryId",
                table: "DestinationCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DestinationCategories_Destinations_DestinationId",
                table: "DestinationCategories",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DestinationCategories_Categories_CategoryId",
                table: "DestinationCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_DestinationCategories_Destinations_DestinationId",
                table: "DestinationCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DestinationCategories",
                table: "DestinationCategories");

            migrationBuilder.RenameTable(
                name: "DestinationCategories",
                newName: "DestinationCategory");

            migrationBuilder.RenameIndex(
                name: "IX_DestinationCategories_DestinationId",
                table: "DestinationCategory",
                newName: "IX_DestinationCategory_DestinationId");

            migrationBuilder.RenameIndex(
                name: "IX_DestinationCategories_CategoryId",
                table: "DestinationCategory",
                newName: "IX_DestinationCategory_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DestinationCategory",
                table: "DestinationCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DestinationCategory_Categories_CategoryId",
                table: "DestinationCategory",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DestinationCategory_Destinations_DestinationId",
                table: "DestinationCategory",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
