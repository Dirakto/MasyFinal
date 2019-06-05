using Microsoft.EntityFrameworkCore.Migrations;

namespace vscode.Migrations
{
    public partial class initialv4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BohaterowieDefensywni");

            migrationBuilder.DropTable(
                name: "BohaterowieOfensywni");

            migrationBuilder.DropTable(
                name: "BohaterowiePomocniczy");

            migrationBuilder.AddColumn<int>(
                name: "BohaterId",
                table: "Umiejetnosci",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Umiejetnosci_BohaterId",
                table: "Umiejetnosci",
                column: "BohaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Umiejetnosci_Bohaterowie_BohaterId",
                table: "Umiejetnosci",
                column: "BohaterId",
                principalTable: "Bohaterowie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Umiejetnosci_Bohaterowie_BohaterId",
                table: "Umiejetnosci");

            migrationBuilder.DropIndex(
                name: "IX_Umiejetnosci_BohaterId",
                table: "Umiejetnosci");

            migrationBuilder.DropColumn(
                name: "BohaterId",
                table: "Umiejetnosci");

            migrationBuilder.CreateTable(
                name: "BohaterowieDefensywni",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    PunktyWytrzymalosci = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BohaterowieDefensywni", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BohaterowieOfensywni",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    SilaObrazenKrytycznych = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BohaterowieOfensywni", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BohaterowiePomocniczy",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    PrzelicznikLeczenia = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BohaterowiePomocniczy", x => x.Id);
                });
        }
    }
}
