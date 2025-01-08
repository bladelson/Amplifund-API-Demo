using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIDemo.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "APIDemo");

            migrationBuilder.CreateTable(
                name: "TodoItem",
                schema: "APIDemo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(512)", nullable: false, defaultValue: ""),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset(3)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    Modified = table.Column<DateTimeOffset>(type: "datetimeoffset(3)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItem", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TodoItem_Created",
                schema: "APIDemo",
                table: "TodoItem",
                columns: new[] { "Deleted", "Created" })
                .Annotation("SqlServer:FillFactor", 100)
                .Annotation("SqlServer:Online", true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoItem",
                schema: "APIDemo");
        }
    }
}
