using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vscode.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bohaterowie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Podklasy = table.Column<string>(nullable: false),
                    Imie = table.Column<string>(nullable: true),
                    Stan = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bohaterowie", x => x.Id);
                });

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
                name: "Rozgrywki",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    SezonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rozgrywki", x => x.Id);
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
                name: "TypyMap",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Typ = table.Column<int>(nullable: false),
                    LiczbaCeli = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypyMap", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Umiejetnosci",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    BohaterId = table.Column<int>(nullable: false),
                    Nazwa = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    PunktyObrazen = table.Column<int>(nullable: false),
                    PunktyLeczenia = table.Column<int>(nullable: false),
                    PunktyTarczy = table.Column<int>(nullable: false),
                    Klawisz = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Umiejetnosci", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Umiejetnosci_Bohaterowie_BohaterId",
                        column: x => x.BohaterId,
                        principalTable: "Bohaterowie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "RozgrywkiGraczy",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    RozgrywkaId = table.Column<int>(nullable: false),
                    GraczId = table.Column<int>(nullable: false),
                    Wynik = table.Column<string>(nullable: true),
                    PrzyrostPoziomu = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RozgrywkiGraczy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RozgrywkiGraczy_Gracze_GraczId",
                        column: x => x.GraczId,
                        principalTable: "Gracze",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RozgrywkiGraczy_Rozgrywki_RozgrywkaId",
                        column: x => x.RozgrywkaId,
                        principalTable: "Rozgrywki",
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

            migrationBuilder.CreateTable(
                name: "Mapy",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    TypId = table.Column<int>(nullable: false),
                    Nazwa = table.Column<string>(nullable: true),
                    IloscRund = table.Column<int>(nullable: false),
                    RozgrywkaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mapy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mapy_Rozgrywki_RozgrywkaId",
                        column: x => x.RozgrywkaId,
                        principalTable: "Rozgrywki",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mapy_TypyMap_TypId",
                        column: x => x.TypId,
                        principalTable: "TypyMap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StatystykiBohaterami",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    RozgrywkaGraczaId = table.Column<int>(nullable: false),
                    BohaterId = table.Column<int>(nullable: false),
                    LiczbaZabojstw = table.Column<int>(nullable: false),
                    LiczbaZgonow = table.Column<int>(nullable: false),
                    LiczbaAsyst = table.Column<int>(nullable: false),
                    CzasGry = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatystykiBohaterami", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatystykiBohaterami_Bohaterowie_BohaterId",
                        column: x => x.BohaterId,
                        principalTable: "Bohaterowie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StatystykiBohaterami_RozgrywkiGraczy_RozgrywkaGraczaId",
                        column: x => x.RozgrywkaGraczaId,
                        principalTable: "RozgrywkiGraczy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MapToMap",
                columns: table => new
                {
                    Mapa1Id = table.Column<int>(nullable: false),
                    Mapa2Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapToMap", x => new { x.Mapa1Id, x.Mapa2Id });
                    table.ForeignKey(
                        name: "FK_MapToMap_Mapy_Mapa1Id",
                        column: x => x.Mapa1Id,
                        principalTable: "Mapy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MapToMap_Mapy_Mapa2Id",
                        column: x => x.Mapa2Id,
                        principalTable: "Mapy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MapToMap_Mapa2Id",
                table: "MapToMap",
                column: "Mapa2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Mapy_RozgrywkaId",
                table: "Mapy",
                column: "RozgrywkaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mapy_TypId",
                table: "Mapy",
                column: "TypId");

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

            migrationBuilder.CreateIndex(
                name: "IX_RozgrywkiGraczy_GraczId",
                table: "RozgrywkiGraczy",
                column: "GraczId");

            migrationBuilder.CreateIndex(
                name: "IX_RozgrywkiGraczy_RozgrywkaId",
                table: "RozgrywkiGraczy",
                column: "RozgrywkaId");

            migrationBuilder.CreateIndex(
                name: "IX_StatystykiBohaterami_BohaterId",
                table: "StatystykiBohaterami",
                column: "BohaterId");

            migrationBuilder.CreateIndex(
                name: "IX_StatystykiBohaterami_RozgrywkaGraczaId",
                table: "StatystykiBohaterami",
                column: "RozgrywkaGraczaId");

            migrationBuilder.CreateIndex(
                name: "IX_Umiejetnosci_BohaterId",
                table: "Umiejetnosci",
                column: "BohaterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MapToMap");

            migrationBuilder.DropTable(
                name: "OsiagnieciaGracza");

            migrationBuilder.DropTable(
                name: "Rankingi");

            migrationBuilder.DropTable(
                name: "StatystykiBohaterami");

            migrationBuilder.DropTable(
                name: "Umiejetnosci");

            migrationBuilder.DropTable(
                name: "Mapy");

            migrationBuilder.DropTable(
                name: "Osiagniecia");

            migrationBuilder.DropTable(
                name: "Sezony");

            migrationBuilder.DropTable(
                name: "RozgrywkiGraczy");

            migrationBuilder.DropTable(
                name: "Bohaterowie");

            migrationBuilder.DropTable(
                name: "TypyMap");

            migrationBuilder.DropTable(
                name: "Gracze");

            migrationBuilder.DropTable(
                name: "Rozgrywki");
        }
    }
}
