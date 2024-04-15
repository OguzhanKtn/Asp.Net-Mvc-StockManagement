using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcTraining.Migrations
{
    /// <inheritdoc />
    public partial class tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBLKATEGORILER",
                columns: table => new
                {
                    KATEGORIID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KATEGORIAD = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLKATEGORIAD", x => x.KATEGORIID);
                });

            migrationBuilder.CreateTable(
                name: "TBLMUSTERILER",
                columns: table => new
                {
                    MUSTERIID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MUSTERIAD = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    MUSTERISOYAD = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLMUSTERILER", x => x.MUSTERIID);
                });

            migrationBuilder.CreateTable(
                name: "TBLURUNLER",
                columns: table => new
                {
                    URUNID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    URUNAD = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    MARKA = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    URUNKATEGORI = table.Column<short>(type: "smallint", nullable: true),
                    FIYAT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    STOK = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLURUNLER", x => x.URUNID);
                    table.ForeignKey(
                        name: "FK_TBLURUNLER_TBLKATEGORILER",
                        column: x => x.URUNKATEGORI,
                        principalTable: "TBLKATEGORILER",
                        principalColumn: "KATEGORIID");
                });

            migrationBuilder.CreateTable(
                name: "TBLSATISLAR",
                columns: table => new
                {
                    SATISID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    URUN = table.Column<int>(type: "int", nullable: true),
                    MUSTERI = table.Column<int>(type: "int", nullable: true),
                    ADET = table.Column<byte>(type: "tinyint", nullable: true),
                    FIYAT = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLSATISLAR", x => x.SATISID);
                    table.ForeignKey(
                        name: "FK_TBLSATISLAR_TBLMUSTERILER",
                        column: x => x.MUSTERI,
                        principalTable: "TBLMUSTERILER",
                        principalColumn: "MUSTERIID");
                    table.ForeignKey(
                        name: "FK_TBLSATISLAR_TBLURUNLER",
                        column: x => x.URUN,
                        principalTable: "TBLURUNLER",
                        principalColumn: "URUNID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBLSATISLAR_MUSTERI",
                table: "TBLSATISLAR",
                column: "MUSTERI");

            migrationBuilder.CreateIndex(
                name: "IX_TBLSATISLAR_URUN",
                table: "TBLSATISLAR",
                column: "URUN");

            migrationBuilder.CreateIndex(
                name: "IX_TBLURUNLER_URUNKATEGORI",
                table: "TBLURUNLER",
                column: "URUNKATEGORI");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBLSATISLAR");

            migrationBuilder.DropTable(
                name: "TBLMUSTERILER");

            migrationBuilder.DropTable(
                name: "TBLURUNLER");

            migrationBuilder.DropTable(
                name: "TBLKATEGORILER");
        }
    }
}
