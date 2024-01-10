using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Property.API.Migrations
{
    /// <inheritdoc />
    public partial class addedpassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Homes_PropertyUser_UserId",
                table: "Homes");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyRole_PropertyUser_UserId",
                table: "PropertyRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PropertyUser",
                table: "PropertyUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PropertyRole",
                table: "PropertyRole");

            migrationBuilder.RenameTable(
                name: "PropertyUser",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "PropertyRole",
                newName: "Roles");

            migrationBuilder.RenameIndex(
                name: "IX_PropertyRole_UserId",
                table: "Roles",
                newName: "IX_Roles_UserId");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Homes_Users_UserId",
                table: "Homes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Users_UserId",
                table: "Roles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Homes_Users_UserId",
                table: "Homes");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Users_UserId",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "PropertyUser");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "PropertyRole");

            migrationBuilder.RenameIndex(
                name: "IX_Roles_UserId",
                table: "PropertyRole",
                newName: "IX_PropertyRole_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PropertyUser",
                table: "PropertyUser",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PropertyRole",
                table: "PropertyRole",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Homes_PropertyUser_UserId",
                table: "Homes",
                column: "UserId",
                principalTable: "PropertyUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyRole_PropertyUser_UserId",
                table: "PropertyRole",
                column: "UserId",
                principalTable: "PropertyUser",
                principalColumn: "Id");
        }
    }
}
