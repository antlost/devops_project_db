using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserService.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_RegestrationDb",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    email = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    forename = table.Column<string>(nullable: true),
                    surename = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__RegestrationDb", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "_RegestrationDb",
                columns: new[] { "id", "email", "forename", "password", "surename" },
                values: new object[] { 1, "conor@version1.com", "Conor", "conor123", "ONeill" });

            migrationBuilder.InsertData(
                table: "_RegestrationDb",
                columns: new[] { "id", "email", "forename", "password", "surename" },
                values: new object[] { 2, "uncle.bob@gmail.com", "Uncle", "bob123", "Bob" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_RegestrationDb");
        }
    }
}
