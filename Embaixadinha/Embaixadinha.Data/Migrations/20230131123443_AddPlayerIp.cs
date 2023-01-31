using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Embaixadinha.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPlayerIp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "score",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 31, 9, 34, 43, 355, DateTimeKind.Local).AddTicks(7044),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 1, 30, 21, 20, 6, 289, DateTimeKind.Local).AddTicks(8240));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "score",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 31, 9, 34, 43, 355, DateTimeKind.Local).AddTicks(6610),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 1, 30, 21, 20, 6, 289, DateTimeKind.Local).AddTicks(7464));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "player",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 31, 9, 34, 43, 355, DateTimeKind.Local).AddTicks(2602),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 1, 30, 21, 20, 6, 289, DateTimeKind.Local).AddTicks(2401));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "player",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 31, 9, 34, 43, 355, DateTimeKind.Local).AddTicks(2233),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 1, 30, 21, 20, 6, 289, DateTimeKind.Local).AddTicks(2068));

            migrationBuilder.AddColumn<string>(
                name: "player_ip",
                table: "player",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "player_ip",
                table: "player");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "score",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 30, 21, 20, 6, 289, DateTimeKind.Local).AddTicks(8240),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 34, 43, 355, DateTimeKind.Local).AddTicks(7044));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "score",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 30, 21, 20, 6, 289, DateTimeKind.Local).AddTicks(7464),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 34, 43, 355, DateTimeKind.Local).AddTicks(6610));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "player",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 30, 21, 20, 6, 289, DateTimeKind.Local).AddTicks(2401),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 34, 43, 355, DateTimeKind.Local).AddTicks(2602));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "player",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 30, 21, 20, 6, 289, DateTimeKind.Local).AddTicks(2068),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 34, 43, 355, DateTimeKind.Local).AddTicks(2233));
        }
    }
}
