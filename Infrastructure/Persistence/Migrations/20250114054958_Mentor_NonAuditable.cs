using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Mentor_NonAuditable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Mentors");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Mentors");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Mentors");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Mentors");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Mentors");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Mentors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Mentors",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Mentors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Mentors",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "Mentors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Mentors",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "Mentors",
                type: "int",
                nullable: true);
        }
    }
}
