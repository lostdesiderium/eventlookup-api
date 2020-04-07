using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventLookup.Migrations
{
    public partial class AddressAndSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Street1",
                table: "Addresses",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Addresses",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Addresses",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "Addresses",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "DaysEventActive", "FinishDate", "GoingPeopleCount", "InterestedPeopleCount", "LongDescription", "ShortDescription", "StartDate", "Title" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(1, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 247, 792, "Ne tik patogioje vietoje bet ir su super patraukliomis kainomis", "\"Užsuk\" restoranas patogioje Vilniaus vietoje", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "\"Užsuk\" Restorano atidarymas" },
                    { 2, 3, new DateTime(1, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 159, 981, "Ne tik patogioje vietoje bet ir su super patraukliomis kainomis, ir ne niekas nepakratys jūsų čia", "\"Užsuk\" restoranas patogioje Kauno vietoje", new DateTime(1, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "\"Pakrisk\" Restorano atidarymas" },
                    { 3, 3, new DateTime(1, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 25505, 70151, "Festivalis jau daug metų iš eilės vykstantis Vokietijoje į kurį susirenka dešimtimis tūkstančių žmonių, kuriems reikia vieno - pašvęst taip kaip niekad dar nebuvo matę", "Popiuliarumas išmatuojamas skaičiais - kokybė tai kur kas daugiau", new DateTime(1, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ultra Music Festival" },
                    { 4, 4, new DateTime(1, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 4210, 7057, "Daug metų besitęsiantis muzikos festivalis su begale pramogų, o svarbiausia ir marozų yra", "Atmosfera, muzika, garsas, jūros krantas, nuotaika", new DateTime(1, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Karklės festivalis" },
                    { 5, 3, new DateTime(1, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2235, 6853, "Kažkur prie Kauno vykstantis festivalis, nu netoli, dega ir namai ir chebra nešasi alkoholį per tvoras, kažkas beria savo konfeti iš žavaus pilvuko vidaus, kažkas gaudo miško žveris naktį, o kiti tik šoka ir šoka, šoka, šoka, nieko daugiau nemato, nu dar alaus plastikinę stiklinę laiko į kurią poto įstringa paukštuktas ir nusišauna su R45 revolveriu", "Apsuptas miškų! Daugiau nei reikia", new DateTime(1, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Granatų festivalis" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "District", "EventId", "Lat", "Lng", "Street1", "Street2" },
                values: new object[,]
                {
                    { 1, "Vilnius", "Lietuva", null, 1, null, null, "Vokiečių g. 15", null },
                    { 2, "Kaunas", "Lietuva", null, 2, null, null, "Laisvės al. 3", null },
                    { 3, "Berlynas", "Vokietija", null, 3, null, null, "Grichitz st. 15", null },
                    { 4, "Klaipėda", "Lietuva", null, 4, null, null, "Melnragės paplūdimys", null },
                    { 5, "Kaunas", "Lietuva", "Rumšiškės", 5, "54.8685114", "24.1786306", "Vokiečių g. 15", null }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Base64Format", "Caption", "EventId", "IsCover", "PathOnServer", "TicketId" },
                values: new object[,]
                {
                    { 1, null, "event1", 1, true, "D:\\MOKSLAI KTU\\4 kursas\\II semestras\\EventLookup-backend\\EventLookup\\EventLookup\\Shared\\Files\\Images\\event1.jpg", null },
                    { 2, null, "event2", 2, true, "D:\\MOKSLAI KTU\\4 kursas\\II semestras\\EventLookup-backend\\EventLookup\\EventLookup\\Shared\\Files\\Images\\event2.jpg", null },
                    { 3, null, "event3", 3, true, "D:\\MOKSLAI KTU\\4 kursas\\II semestras\\EventLookup-backend\\EventLookup\\EventLookup\\Shared\\Files\\Images\\event3.jpg", null },
                    { 4, null, "event4", 4, true, "D:\\MOKSLAI KTU\\4 kursas\\II semestras\\EventLookup-backend\\EventLookup\\EventLookup\\Shared\\Files\\Images\\event4.jpg", null },
                    { 5, null, "event5", 5, true, "D:\\MOKSLAI KTU\\4 kursas\\II semestras\\EventLookup-backend\\EventLookup\\EventLookup\\Shared\\Files\\Images\\event5.jpg", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "District",
                table: "Addresses");

            migrationBuilder.AlterColumn<string>(
                name: "Street1",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
