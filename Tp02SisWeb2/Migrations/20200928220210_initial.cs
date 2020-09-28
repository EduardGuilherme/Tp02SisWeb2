using Microsoft.EntityFrameworkCore.Migrations;

namespace Tp02SisWeb2.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BLs",
                columns: table => new
                {
                    IdBl = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num = table.Column<int>(nullable: false),
                    Consigner = table.Column<string>(nullable: true),
                    Navio = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BLs", x => x.IdBl);
                });

            migrationBuilder.CreateTable(
                name: "Containers",
                columns: table => new
                {
                    IdContainer = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numContainer = table.Column<int>(nullable: false),
                    Tipo = table.Column<string>(nullable: true),
                    tamanho = table.Column<string>(nullable: true),
                    IdBl = table.Column<int>(nullable: false),
                    BLIdBl = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Containers", x => x.IdContainer);
                    table.ForeignKey(
                        name: "FK_Containers_BLs_BLIdBl",
                        column: x => x.BLIdBl,
                        principalTable: "BLs",
                        principalColumn: "IdBl",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Containers_BLIdBl",
                table: "Containers",
                column: "BLIdBl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Containers");

            migrationBuilder.DropTable(
                name: "BLs");
        }
    }
}
