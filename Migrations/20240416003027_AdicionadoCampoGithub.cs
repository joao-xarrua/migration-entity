using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog2.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoCampoGithub : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Github",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateDate",
                table: "Post",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 16, 0, 30, 27, 72, DateTimeKind.Utc).AddTicks(1686),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2024, 4, 16, 0, 13, 20, 61, DateTimeKind.Utc).AddTicks(1628));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Github",
                table: "User");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateDate",
                table: "Post",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 16, 0, 13, 20, 61, DateTimeKind.Utc).AddTicks(1628),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2024, 4, 16, 0, 30, 27, 72, DateTimeKind.Utc).AddTicks(1686));
        }
    }
}
