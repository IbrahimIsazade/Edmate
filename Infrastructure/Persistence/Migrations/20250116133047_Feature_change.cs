using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Feature_change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_Books_BookId",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Features_BookId",
                table: "Features");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Features",
                newName: "ItemId");

            migrationBuilder.AddColumn<byte>(
                name: "IsCourseFeature",
                table: "Features",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCourseFeature",
                table: "Features");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "Features",
                newName: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Features_BookId",
                table: "Features",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Books_BookId",
                table: "Features",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id");
        }
    }
}
