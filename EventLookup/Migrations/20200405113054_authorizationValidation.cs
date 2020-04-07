using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventLookup.Migrations
{
    public partial class authorizationValidation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Biography",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Created",
                table: "UserEvent",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 1,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { "54.6804524", "25.2811559" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 2,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { "54.8965887", "23.9244845" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 3,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { "50.8821039", "10.4400291" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 4,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { "55.7373152", "21.0837908" });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Biography",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "UserEvent");

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 1,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 2,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 3,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 4,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { null, null });

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
    }
}
