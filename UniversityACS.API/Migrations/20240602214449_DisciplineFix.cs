using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityACS.API.Migrations
{
    /// <inheritdoc />
    public partial class DisciplineFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuditoryTasks",
                table: "Disciplines",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Exams",
                table: "Disciplines",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tests",
                table: "Disciplines",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e5893a5d-e0de-4e6e-9a35-9190d7f18675", "AQAAAAIAAYagAAAAEIZDDoPMotc+0MrE+fiQHamlRIiJen67MFfQgnEglw4Tz8QZJtV31/fL8HgJLKYbeg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuditoryTasks",
                table: "Disciplines");

            migrationBuilder.DropColumn(
                name: "Exams",
                table: "Disciplines");

            migrationBuilder.DropColumn(
                name: "Tests",
                table: "Disciplines");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e6a38374-d4f8-4b08-93a8-8740fea03690", "AQAAAAIAAYagAAAAEHD1FqDazTXKGMF9ncpIwFgMvQ6CkC7t2HK0JF30my6sVTDZTHHx0CQUA3lyE9drzw==" });
        }
    }
}
