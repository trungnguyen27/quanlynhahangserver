using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanLyNhaHangServer.Migrations
{
    public partial class AddTableID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TableId",
                table: "Tables",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TableId",
                table: "Tables");
        }
    }
}
