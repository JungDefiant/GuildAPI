using Microsoft.EntityFrameworkCore.Migrations;

namespace GuildAPI.Migrations
{
    public partial class updatemodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_GameManagers_GameManagersGameId_GameManagersUserId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_GameManagers_GameManagersGameId_GameManagersUserId",
                table: "Games");

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

            migrationBuilder.CreateIndex(
                name: "IX_GameManagers_UserId",
                table: "GameManagers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameManagers_Games_GameId",
                table: "GameManagers",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameManagers_AspNetUsers_UserId",
                table: "GameManagers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameManagers_Games_GameId",
                table: "GameManagers");

            migrationBuilder.DropForeignKey(
                name: "FK_GameManagers_AspNetUsers_UserId",
                table: "GameManagers");

            migrationBuilder.DropIndex(
                name: "IX_GameManagers_UserId",
                table: "GameManagers");

            migrationBuilder.AddColumn<int>(
                name: "GameManagersGameId",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GameManagersUserId",
                table: "Games",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameManagersGameId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GameManagersUserId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

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
    }
}
