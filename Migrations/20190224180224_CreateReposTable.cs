using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GitRepos.Migrations
{
    public partial class CreateReposTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Repositories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<int>(nullable: false),
                    UpdatedAt = table.Column<int>(nullable: false),
                    StargazersCount = table.Column<int>(nullable: false),
                    GitUrl = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    OwnerHtmlUrl = table.Column<string>(nullable: true),
                    HtmlUrl = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repositories", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Repositories");
        }
    }
}
