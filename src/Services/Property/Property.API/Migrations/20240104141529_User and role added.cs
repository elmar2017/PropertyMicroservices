using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Property.API.Migrations
{
    /// <inheritdoc />
    public partial class Userandroleadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Homes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "PropertyUser",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyRole_PropertyUser_UserId",
                        column: x => x.UserId,
                        principalTable: "PropertyUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Homes_UserId",
                table: "Homes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyRole_UserId",
                table: "PropertyRole",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Homes_PropertyUser_UserId",
                table: "Homes",
                column: "UserId",
                principalTable: "PropertyUser",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Homes_PropertyUser_UserId",
                table: "Homes");

            migrationBuilder.DropTable(
                name: "PropertyRole");

            migrationBuilder.DropTable(
                name: "PropertyUser");

            migrationBuilder.DropIndex(
                name: "IX_Homes_UserId",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Homes");
        }
    }
}
