using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EmailConfigApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmailConfigurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    WatchedFolder = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    Provider = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    StoreAttachments = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailConfigurations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "EmailConfigurations",
                columns: new[] { "Id", "Name", "Provider", "StoreAttachments", "WatchedFolder" },
                values: new object[] { 1, "Example Exchange", "Exchange", true, "/inbox/exchange" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailConfigurations");
        }
    }
}
