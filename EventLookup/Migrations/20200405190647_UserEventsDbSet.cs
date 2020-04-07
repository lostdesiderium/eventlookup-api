using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventLookup.Migrations
{
    public partial class UserEventsDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserEvent_Events_EventId",
                table: "UserEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEvent_Users_UserId",
                table: "UserEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserEvent",
                table: "UserEvent");

            migrationBuilder.RenameTable(
                name: "UserEvent",
                newName: "UserEvents");

            migrationBuilder.RenameIndex(
                name: "IX_UserEvent_EventId",
                table: "UserEvents",
                newName: "IX_UserEvents_EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserEvents",
                table: "UserEvents",
                columns: new[] { "UserId", "EventId" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "FinishDate", "StartDate" },
                values: new object[] { new DateTime(2020, 5, 5, 22, 6, 47, 40, DateTimeKind.Local).AddTicks(2696), new DateTime(2020, 4, 5, 22, 6, 47, 36, DateTimeKind.Local).AddTicks(2761) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 2,
                columns: new[] { "FinishDate", "StartDate" },
                values: new object[] { new DateTime(2020, 5, 5, 22, 6, 47, 40, DateTimeKind.Local).AddTicks(4726), new DateTime(2020, 4, 7, 22, 6, 47, 40, DateTimeKind.Local).AddTicks(4678) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 3,
                columns: new[] { "FinishDate", "StartDate" },
                values: new object[] { new DateTime(2020, 5, 13, 22, 6, 47, 40, DateTimeKind.Local).AddTicks(4754), new DateTime(2020, 5, 10, 22, 6, 47, 40, DateTimeKind.Local).AddTicks(4750) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 4,
                columns: new[] { "FinishDate", "StartDate" },
                values: new object[] { new DateTime(2020, 4, 17, 22, 6, 47, 40, DateTimeKind.Local).AddTicks(4761), new DateTime(2020, 4, 13, 22, 6, 47, 40, DateTimeKind.Local).AddTicks(4758) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 5,
                columns: new[] { "FinishDate", "StartDate" },
                values: new object[] { new DateTime(2020, 5, 9, 22, 6, 47, 40, DateTimeKind.Local).AddTicks(4768), new DateTime(2020, 5, 6, 22, 6, 47, 40, DateTimeKind.Local).AddTicks(4765) });

            migrationBuilder.AddForeignKey(
                name: "FK_UserEvents_Events_EventId",
                table: "UserEvents",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserEvents_Users_UserId",
                table: "UserEvents",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserEvents_Events_EventId",
                table: "UserEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEvents_Users_UserId",
                table: "UserEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserEvents",
                table: "UserEvents");

            migrationBuilder.RenameTable(
                name: "UserEvents",
                newName: "UserEvent");

            migrationBuilder.RenameIndex(
                name: "IX_UserEvents_EventId",
                table: "UserEvent",
                newName: "IX_UserEvent_EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserEvent",
                table: "UserEvent",
                columns: new[] { "UserId", "EventId" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "FinishDate", "StartDate" },
                values: new object[] { new DateTime(2020, 5, 5, 14, 30, 53, 845, DateTimeKind.Local).AddTicks(8168), new DateTime(2020, 4, 5, 14, 30, 53, 841, DateTimeKind.Local).AddTicks(5763) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 2,
                columns: new[] { "FinishDate", "StartDate" },
                values: new object[] { new DateTime(2020, 5, 5, 14, 30, 53, 845, DateTimeKind.Local).AddTicks(9354), new DateTime(2020, 4, 7, 14, 30, 53, 845, DateTimeKind.Local).AddTicks(9312) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 3,
                columns: new[] { "FinishDate", "StartDate" },
                values: new object[] { new DateTime(2020, 5, 13, 14, 30, 53, 845, DateTimeKind.Local).AddTicks(9382), new DateTime(2020, 5, 10, 14, 30, 53, 845, DateTimeKind.Local).AddTicks(9378) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 4,
                columns: new[] { "FinishDate", "StartDate" },
                values: new object[] { new DateTime(2020, 4, 17, 14, 30, 53, 845, DateTimeKind.Local).AddTicks(9389), new DateTime(2020, 4, 13, 14, 30, 53, 845, DateTimeKind.Local).AddTicks(9386) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 5,
                columns: new[] { "FinishDate", "StartDate" },
                values: new object[] { new DateTime(2020, 5, 9, 14, 30, 53, 845, DateTimeKind.Local).AddTicks(9396), new DateTime(2020, 5, 6, 14, 30, 53, 845, DateTimeKind.Local).AddTicks(9393) });

            migrationBuilder.AddForeignKey(
                name: "FK_UserEvent_Events_EventId",
                table: "UserEvent",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserEvent_Users_UserId",
                table: "UserEvent",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
