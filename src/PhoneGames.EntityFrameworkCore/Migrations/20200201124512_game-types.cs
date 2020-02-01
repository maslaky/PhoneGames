using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneGames.Migrations
{
    public partial class gametypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameTypeId",
                table: "GameInstances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GameTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    GameName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "GameTypes",
                columns: new[] { "Id", "CreationTime", "CreatorUserId", "DeleterUserId", "DeletionTime", "GameName", "IsDeleted", "LastModificationTime", "LastModifierUserId" },
                values: new object[] { 1, new DateTime(2020, 2, 1, 13, 45, 11, 602, DateTimeKind.Local).AddTicks(2332), null, null, null, "AnswerRepair", false, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_GameInstances_GameTypeId",
                table: "GameInstances",
                column: "GameTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameInstances_GameTypes_GameTypeId",
                table: "GameInstances",
                column: "GameTypeId",
                principalTable: "GameTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameInstances_GameTypes_GameTypeId",
                table: "GameInstances");

            migrationBuilder.DropTable(
                name: "GameTypes");

            migrationBuilder.DropIndex(
                name: "IX_GameInstances_GameTypeId",
                table: "GameInstances");

            migrationBuilder.DropColumn(
                name: "GameTypeId",
                table: "GameInstances");
        }
    }
}
