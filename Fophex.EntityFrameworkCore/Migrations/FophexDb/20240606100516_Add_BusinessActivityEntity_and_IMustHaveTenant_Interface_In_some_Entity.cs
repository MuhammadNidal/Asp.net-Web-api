using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fophex.EntityFrameworkCore.Migrations.FophexDb
{
    /// <inheritdoc />
    public partial class Add_BusinessActivityEntity_and_IMustHaveTenant_Interface_In_some_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Roles",
                schema: "access_manag.",
                newName: "Roles",
                newSchema: "access_manag");

            migrationBuilder.CreateTable(
                name: "BusinessActivities",
                schema: "access_manag",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessActivities", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessActivities",
                schema: "access_manag");

            migrationBuilder.EnsureSchema(
                name: "access_manag.");

            migrationBuilder.RenameTable(
                name: "Roles",
                schema: "access_manag",
                newName: "Roles",
                newSchema: "access_manag.");
        }
    }
}
