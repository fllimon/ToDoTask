using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDo.EFDatabase.Migrations
{
    public partial class NewDbShema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Key",
                table: "ToDo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "ToDo",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
