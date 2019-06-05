using Microsoft.EntityFrameworkCore.Migrations;

namespace vscode.Migrations
{
    public partial class initialv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Podklasy",
                table: "Bohaterowie",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Podklasy",
                table: "Bohaterowie");
        }
    }
}
