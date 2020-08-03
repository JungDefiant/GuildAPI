using Microsoft.EntityFrameworkCore.Migrations;

namespace GuildAPI.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Guilds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guilds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameGuilds",
                columns: table => new
                {
                    GameId = table.Column<int>(nullable: false),
                    GuildId = table.Column<int>(nullable: false),
                    GamesId = table.Column<int>(nullable: true),
                    GuildsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameGuilds", x => new { x.GameId, x.GuildId });
                    table.ForeignKey(
                        name: "FK_GameGuilds_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameGuilds_Guilds_GuildsId",
                        column: x => x.GuildsId,
                        principalTable: "Guilds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Guild Clashes 2" },
                    { 2, "The World of NonCraft" },
                    { 3, "City of Zeroes" }
                });

            migrationBuilder.InsertData(
                table: "Guilds",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Guild of Average People" },
                    { 2, "BroForce" },
                    { 3, "" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameGuilds_GamesId",
                table: "GameGuilds",
                column: "GamesId");

            migrationBuilder.CreateIndex(
                name: "IX_GameGuilds_GuildsId",
                table: "GameGuilds",
                column: "GuildsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameGuilds");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Guilds");
        }
    }
}
