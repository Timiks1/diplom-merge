using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityACS.API.Migrations
{
    /// <inheritdoc />
    public partial class DisciplineUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ECTS",
                table: "Disciplines",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LaboratoryHours",
                table: "Disciplines",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LecturerHours",
                table: "Disciplines",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PracticHours",
                table: "Disciplines",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e6a38374-d4f8-4b08-93a8-8740fea03690", "AQAAAAIAAYagAAAAEHD1FqDazTXKGMF9ncpIwFgMvQ6CkC7t2HK0JF30my6sVTDZTHHx0CQUA3lyE9drzw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ECTS",
                table: "Disciplines");

            migrationBuilder.DropColumn(
                name: "LaboratoryHours",
                table: "Disciplines");

            migrationBuilder.DropColumn(
                name: "LecturerHours",
                table: "Disciplines");

            migrationBuilder.DropColumn(
                name: "PracticHours",
                table: "Disciplines");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6c415af2-8057-4f85-b2c4-8a5b9acc864b", "AQAAAAIAAYagAAAAELua74NiRS5Ja03m2qSns7Dgv1sCbWK8d5zf6hfdR9Q9fgsD1FpyDa8wlJe4E8flbQ==" });
        }
    }
}
