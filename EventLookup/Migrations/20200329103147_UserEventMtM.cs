using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventLookup.Migrations
{
    public partial class UserEventMtM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Going",
                table: "UserEvent",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Interested",
                table: "UserEvent",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "FinishDate", "StartDate" },
                values: new object[] { new DateTime(2020, 4, 29, 13, 31, 46, 731, DateTimeKind.Local).AddTicks(6057), new DateTime(2020, 3, 29, 13, 31, 46, 728, DateTimeKind.Local).AddTicks(6833) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 2,
                columns: new[] { "FinishDate", "StartDate" },
                values: new object[] { new DateTime(2020, 4, 29, 13, 31, 46, 731, DateTimeKind.Local).AddTicks(7237), new DateTime(2020, 3, 31, 13, 31, 46, 731, DateTimeKind.Local).AddTicks(7187) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 3,
                columns: new[] { "FinishDate", "StartDate" },
                values: new object[] { new DateTime(2020, 5, 7, 13, 31, 46, 731, DateTimeKind.Local).AddTicks(7277), new DateTime(2020, 5, 4, 13, 31, 46, 731, DateTimeKind.Local).AddTicks(7273) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 4,
                columns: new[] { "FinishDate", "StartDate" },
                values: new object[] { new DateTime(2020, 4, 10, 13, 31, 46, 731, DateTimeKind.Local).AddTicks(7284), new DateTime(2020, 4, 6, 13, 31, 46, 731, DateTimeKind.Local).AddTicks(7281) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 5,
                columns: new[] { "FinishDate", "StartDate" },
                values: new object[] { new DateTime(2020, 5, 3, 13, 31, 46, 731, DateTimeKind.Local).AddTicks(7291), new DateTime(2020, 4, 30, 13, 31, 46, 731, DateTimeKind.Local).AddTicks(7288) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Going",
                table: "UserEvent");

            migrationBuilder.DropColumn(
                name: "Interested",
                table: "UserEvent");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "FinishDate", "StartDate" },
                values: new object[] { new DateTime(2020, 4, 29, 12, 59, 47, 222, DateTimeKind.Local).AddTicks(7663), new DateTime(2020, 3, 29, 12, 59, 47, 219, DateTimeKind.Local).AddTicks(4855) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 2,
                columns: new[] { "FinishDate", "StartDate" },
                values: new object[] { new DateTime(2020, 4, 29, 12, 59, 47, 222, DateTimeKind.Local).AddTicks(9770), new DateTime(2020, 3, 31, 12, 59, 47, 222, DateTimeKind.Local).AddTicks(9720) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 3,
                columns: new[] { "FinishDate", "StartDate" },
                values: new object[] { new DateTime(2020, 5, 7, 12, 59, 47, 222, DateTimeKind.Local).AddTicks(9804), new DateTime(2020, 5, 4, 12, 59, 47, 222, DateTimeKind.Local).AddTicks(9800) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 4,
                columns: new[] { "FinishDate", "StartDate" },
                values: new object[] { new DateTime(2020, 4, 10, 12, 59, 47, 222, DateTimeKind.Local).AddTicks(9811), new DateTime(2020, 4, 6, 12, 59, 47, 222, DateTimeKind.Local).AddTicks(9808) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 5,
                columns: new[] { "FinishDate", "StartDate" },
                values: new object[] { new DateTime(2020, 5, 3, 12, 59, 47, 222, DateTimeKind.Local).AddTicks(9819), new DateTime(2020, 4, 30, 12, 59, 47, 222, DateTimeKind.Local).AddTicks(9816) });
        }
    }
}
