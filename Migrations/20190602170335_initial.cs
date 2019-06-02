using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vscode.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gracze",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Imie = table.Column<string>(nullable: true),
                    Nazwisko = table.Column<string>(nullable: true),
                    Pseudonim = table.Column<string>(nullable: true),
                    BattleTag = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gracze", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Osiagniecia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Nazwa = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Opis = table.Column<string>(nullable: true),
                    MaksymalnyWynik = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Osiagniecia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sezony",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    MaxIloscPunktow = table.Column<int>(nullable: false),
                    MinIloscPunktow = table.Column<int>(nullable: false),
                    DataRozpoczecia = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sezony", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OsiagnieciaGracza",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    GraczId = table.Column<int>(nullable: false),
                    OsiagniecieId = table.Column<int>(nullable: false),
                    AktualnyStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OsiagnieciaGracza", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OsiagnieciaGracza_Gracze_GraczId",
                        column: x => x.GraczId,
                        principalTable: "Gracze",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OsiagnieciaGracza_Osiagniecia_OsiagniecieId",
                        column: x => x.OsiagniecieId,
                        principalTable: "Osiagniecia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rankingi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    GraczId = table.Column<int>(nullable: false),
                    SezonId = table.Column<int>(nullable: false),
                    Poziom = table.Column<int>(nullable: false),
                    PozycjaRankingowa = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rankingi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rankingi_Gracze_GraczId",
                        column: x => x.GraczId,
                        principalTable: "Gracze",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rankingi_Sezony_SezonId",
                        column: x => x.SezonId,
                        principalTable: "Sezony",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OsiagnieciaGracza_GraczId",
                table: "OsiagnieciaGracza",
                column: "GraczId");

            migrationBuilder.CreateIndex(
                name: "IX_OsiagnieciaGracza_OsiagniecieId",
                table: "OsiagnieciaGracza",
                column: "OsiagniecieId");

            migrationBuilder.CreateIndex(
                name: "IX_Rankingi_GraczId",
                table: "Rankingi",
                column: "GraczId");

            migrationBuilder.CreateIndex(
                name: "IX_Rankingi_SezonId",
                table: "Rankingi",
                column: "SezonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OsiagnieciaGracza");

            migrationBuilder.DropTable(
                name: "Rankingi");

            migrationBuilder.DropTable(
                name: "Osiagniecia");

            migrationBuilder.DropTable(
                name: "Gracze");

            migrationBuilder.DropTable(
                name: "Sezony");
        }
    }
}
