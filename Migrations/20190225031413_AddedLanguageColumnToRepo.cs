using Microsoft.EntityFrameworkCore.Migrations;

namespace GitRepos.Migrations
{
    public partial class AddedLanguageColumnToRepo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Repositories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Language",
                table: "Repositories");
        }
    }
}
