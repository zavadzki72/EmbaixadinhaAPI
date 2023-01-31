using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Embaixadinha.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueConstraintPlayerIp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "score",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 34, 43, 355, DateTimeKind.Local).AddTicks(7044));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "score",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 34, 43, 355, DateTimeKind.Local).AddTicks(6610));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "player",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 34, 43, 355, DateTimeKind.Local).AddTicks(2602));

            migrationBuilder.AlterColumn<string>(
                name: "player_ip",
                table: "player",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "player",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 34, 43, 355, DateTimeKind.Local).AddTicks(2233));

            migrationBuilder.CreateIndex(
                name: "ix_player_player_ip",
                table: "player",
                column: "player_ip",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_player_player_ip",
                table: "player");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "score",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 31, 9, 34, 43, 355, DateTimeKind.Local).AddTicks(7044),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "score",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 31, 9, 34, 43, 355, DateTimeKind.Local).AddTicks(6610),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "player",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 31, 9, 34, 43, 355, DateTimeKind.Local).AddTicks(2602),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<string>(
                name: "player_ip",
                table: "player",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "player",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 31, 9, 34, 43, 355, DateTimeKind.Local).AddTicks(2233),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");
        }
    }
}
