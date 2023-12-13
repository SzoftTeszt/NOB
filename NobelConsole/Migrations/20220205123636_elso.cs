using Microsoft.EntityFrameworkCore.Migrations;

namespace NobelConsole.Migrations
{
    public partial class elso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tipusok",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipusok", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nobel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ev = table.Column<int>(type: "int", nullable: false),
                    TipusId = table.Column<int>(type: "int", nullable: true),
                    KeresztNev = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VezetekNev = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nobel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nobel_Tipusok_TipusId",
                        column: x => x.TipusId,
                        principalTable: "Tipusok",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nobel_TipusId",
                table: "Nobel",
                column: "TipusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nobel");

            migrationBuilder.DropTable(
                name: "Tipusok");
        }
    }
}
