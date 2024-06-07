using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityACS.API.Migrations
{
    /// <inheritdoc />
    public partial class addIndependent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IndependentHours",
                table: "Disciplines",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5e513a30-9a6c-4702-812a-08bc051444e6", "AQAAAAIAAYagAAAAEEgkzTDfmtr+u7iBeWj57Zv0eO1nN1x48hg49egstEVLHTdTa5p/m16uNZ+sG7GIrg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IndependentHours",
                table: "Disciplines");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e5893a5d-e0de-4e6e-9a35-9190d7f18675", "AQAAAAIAAYagAAAAEIZDDoPMotc+0MrE+fiQHamlRIiJen67MFfQgnEglw4Tz8QZJtV31/fL8HgJLKYbeg==" });
        }
    }
}
