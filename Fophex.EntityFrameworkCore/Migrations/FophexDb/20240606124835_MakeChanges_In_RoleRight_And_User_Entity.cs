using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fophex.EntityFrameworkCore.Migrations.FophexDb
{
    /// <inheritdoc />
    public partial class MakeChanges_In_RoleRight_And_User_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "lastName",
                schema: "access_manag",
                table: "Users",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                schema: "access_manag",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "RoleId",
                schema: "access_manag",
                table: "RoleRights",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_RoleRights_RoleId",
                schema: "access_manag",
                table: "RoleRights",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleRights_Roles_RoleId",
                schema: "access_manag",
                table: "RoleRights",
                column: "RoleId",
                principalSchema: "access_manag",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleRights_Roles_RoleId",
                schema: "access_manag",
                table: "RoleRights");

            migrationBuilder.DropIndex(
                name: "IX_RoleRights_RoleId",
                schema: "access_manag",
                table: "RoleRights");

            migrationBuilder.DropColumn(
                name: "Password",
                schema: "access_manag",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoleId",
                schema: "access_manag",
                table: "RoleRights");

            migrationBuilder.RenameColumn(
                name: "LastName",
                schema: "access_manag",
                table: "Users",
                newName: "lastName");
        }
    }
}
