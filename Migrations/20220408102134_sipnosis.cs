using Microsoft.EntityFrameworkCore.Migrations;

namespace Sibolga_Library.Migrations
{
    public partial class sipnosis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sipnosis",
                table: "Buku",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sipnosis",
                table: "Buku");
        }
    }
}
