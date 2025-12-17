using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroMagia.Api.Migrations
{
    /// <inheritdoc />
    public partial class v102 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Careers_CareerId",
                table: "Courses");

            migrationBuilder.AlterColumn<Guid>(
                name: "CareerId",
                table: "Courses",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Careers_CareerId",
                table: "Courses",
                column: "CareerId",
                principalTable: "Careers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Careers_CareerId",
                table: "Courses");

            migrationBuilder.AlterColumn<Guid>(
                name: "CareerId",
                table: "Courses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Careers_CareerId",
                table: "Courses",
                column: "CareerId",
                principalTable: "Careers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
