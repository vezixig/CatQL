using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class today2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BreedId",
                table: "Cats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cats_BreedId",
                table: "Cats",
                column: "BreedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cats_Breeds_BreedId",
                table: "Cats",
                column: "BreedId",
                principalTable: "Breeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cats_Breeds_BreedId",
                table: "Cats");

            migrationBuilder.DropIndex(
                name: "IX_Cats_BreedId",
                table: "Cats");

            migrationBuilder.DropColumn(
                name: "BreedId",
                table: "Cats");
        }
    }
}
