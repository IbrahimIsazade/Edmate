using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UserTokens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTokens",
                schema: "Membership",
                table: "UserTokens");

            migrationBuilder.AddColumn<byte>(
                name: "Type",
                schema: "Membership",
                table: "UserTokens",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpireDate",
                schema: "Membership",
                table: "UserTokens",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IsDisable",
                schema: "Membership",
                table: "UserTokens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsSubscriber",
                schema: "Membership",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "Membership",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                schema: "Membership",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTokens",
                schema: "Membership",
                table: "UserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name", "Type", "ExpireDate" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTokens",
                schema: "Membership",
                table: "UserTokens");

            migrationBuilder.DropColumn(
                name: "Type",
                schema: "Membership",
                table: "UserTokens");

            migrationBuilder.DropColumn(
                name: "ExpireDate",
                schema: "Membership",
                table: "UserTokens");

            migrationBuilder.DropColumn(
                name: "IsDisable",
                schema: "Membership",
                table: "UserTokens");

            migrationBuilder.DropColumn(
                name: "IsSubscriber",
                schema: "Membership",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "Membership",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Surname",
                schema: "Membership",
                table: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTokens",
                schema: "Membership",
                table: "UserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });
        }
    }
}
