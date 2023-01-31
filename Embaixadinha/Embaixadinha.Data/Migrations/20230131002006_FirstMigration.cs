using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Embaixadinha.Data.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "player",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime(6)", nullable: false, defaultValue: new DateTime(2023, 1, 30, 21, 20, 6, 289, DateTimeKind.Local).AddTicks(2068)),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime(6)", nullable: false, defaultValue: new DateTime(2023, 1, 30, 21, 20, 6, 289, DateTimeKind.Local).AddTicks(2401))
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "score",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    value = table.Column<int>(type: "int", nullable: false),
                    playerid = table.Column<int>(name: "player_id", type: "int", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime(6)", nullable: false, defaultValue: new DateTime(2023, 1, 30, 21, 20, 6, 289, DateTimeKind.Local).AddTicks(7464)),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime(6)", nullable: false, defaultValue: new DateTime(2023, 1, 30, 21, 20, 6, 289, DateTimeKind.Local).AddTicks(8240))
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_score", x => x.id);
                    table.ForeignKey(
                        name: "fk_score_player_player_id",
                        column: x => x.playerid,
                        principalTable: "player",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "ix_player_name",
                table: "player",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_score_player_id",
                table: "score",
                column: "player_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "score");

            migrationBuilder.DropTable(
                name: "player");
        }
    }
}
