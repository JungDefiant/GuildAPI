using Microsoft.EntityFrameworkCore.Migrations;

namespace GuildAPI.Migrations
{
    public partial class gamemanagers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameManagersGameId",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GameManagersUserId",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameManagersGameId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GameManagersUserId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GameManagers",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    GameId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameManagers", x => new { x.GameId, x.UserId });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_GameManagersGameId_GameManagersUserId",
                table: "Games",
                columns: new[] { "GameManagersGameId", "GameManagersUserId" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GameManagersGameId_GameManagersUserId",
                table: "AspNetUsers",
                columns: new[] { "GameManagersGameId", "GameManagersUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_GameManagers_GameManagersGameId_GameManagersUserId",
                table: "AspNetUsers",
                columns: new[] { "GameManagersGameId", "GameManagersUserId" },
                principalTable: "GameManagers",
                principalColumns: new[] { "GameId", "UserId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_GameManagers_GameManagersGameId_GameManagersUserId",
                table: "Games",
                columns: new[] { "GameManagersGameId", "GameManagersUserId" },
                principalTable: "GameManagers",
                principalColumns: new[] { "GameId", "UserId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_GameManagers_GameManagersGameId_GameManagersUserId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_GameManagers_GameManagersGameId_GameManagersUserId",
                table: "Games");

            migrationBuilder.DropTable(
                name: "GameManagers");

            migrationBuilder.DropIndex(
                name: "IX_Games_GameManagersGameId_GameManagersUserId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_GameManagersGameId_GameManagersUserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GameManagersGameId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "GameManagersUserId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "GameManagersGameId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GameManagersUserId",
                table: "AspNetUsers");
        }
    }
}
