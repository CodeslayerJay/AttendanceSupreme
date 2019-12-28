using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AttendanceSupreme.Data.Migrations
{
    public partial class ScheduledTimesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScheduledTimes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ScheduledDateTime = table.Column<DateTime>(nullable: false),
                    ScheduledWork = table.Column<double>(nullable: false),
                    ScheduledBreak = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduledTimes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledTimes_UserId",
                table: "ScheduledTimes",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduledTimes");
        }
    }
}
