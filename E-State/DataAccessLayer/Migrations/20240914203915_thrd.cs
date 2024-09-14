using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class thrd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NeighborhoodId",
                table: "Adverts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_NeighborhoodId",
                table: "Adverts",
                column: "NeighborhoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adverts_Neighborhoods_NeighborhoodId",
                table: "Adverts",
                column: "NeighborhoodId",
                principalTable: "Neighborhoods",
                principalColumn: "NeighborhoodId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adverts_Neighborhoods_NeighborhoodId",
                table: "Adverts");

            migrationBuilder.DropIndex(
                name: "IX_Adverts_NeighborhoodId",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "NeighborhoodId",
                table: "Adverts");
        }
    }
}
