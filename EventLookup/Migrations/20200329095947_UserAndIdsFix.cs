using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventLookup.Migrations
{
    public partial class UserAndIdsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Events_EventId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Events_EventId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Tickets_TicketId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Events_EventId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

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
                name: "Id",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Base64Format",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Addresses");

            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "Tickets",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Images",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Events",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Addresses",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "TicketId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "ImageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "AddressId");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserEvent",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEvent", x => new { x.UserId, x.EventId });
                    table.ForeignKey(
                        name: "FK_UserEvent_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserEvent_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "DaysEventActive", "FinishDate", "GoingPeopleCount", "InterestedPeopleCount", "LongDescription", "ShortDescription", "StartDate", "Title" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2020, 4, 29, 12, 59, 47, 222, DateTimeKind.Local).AddTicks(7663), 247, 792, "Ne tik patogioje vietoje bet ir su super patraukliomis kainomis", "\"Užsuk\" restoranas patogioje Vilniaus vietoje", new DateTime(2020, 3, 29, 12, 59, 47, 219, DateTimeKind.Local).AddTicks(4855), "\"Užsuk\" Restorano atidarymas" },
                    { 2, 3, new DateTime(2020, 4, 29, 12, 59, 47, 222, DateTimeKind.Local).AddTicks(9770), 159, 981, "Ne tik patogioje vietoje bet ir su super patraukliomis kainomis, ir ne niekas nepakratys jūsų čia", "\"Užsuk\" restoranas patogioje Kauno vietoje", new DateTime(2020, 3, 31, 12, 59, 47, 222, DateTimeKind.Local).AddTicks(9720), "\"Pakrisk\" Restorano atidarymas" },
                    { 3, 3, new DateTime(2020, 5, 7, 12, 59, 47, 222, DateTimeKind.Local).AddTicks(9804), 25505, 70151, "Festivalis jau daug metų iš eilės vykstantis Vokietijoje į kurį susirenka dešimtimis tūkstančių žmonių, kuriems reikia vieno - pašvęst taip kaip niekad dar nebuvo matę", "Popiuliarumas išmatuojamas skaičiais - kokybė tai kur kas daugiau", new DateTime(2020, 5, 4, 12, 59, 47, 222, DateTimeKind.Local).AddTicks(9800), "Ultra Music Festival" },
                    { 4, 4, new DateTime(2020, 4, 10, 12, 59, 47, 222, DateTimeKind.Local).AddTicks(9811), 4210, 7057, "Daug metų besitęsiantis muzikos festivalis su begale pramogų, o svarbiausia ir marozų yra", "Atmosfera, muzika, garsas, jūros krantas, nuotaika", new DateTime(2020, 4, 6, 12, 59, 47, 222, DateTimeKind.Local).AddTicks(9808), "Karklės festivalis" },
                    { 5, 3, new DateTime(2020, 5, 3, 12, 59, 47, 222, DateTimeKind.Local).AddTicks(9819), 2235, 6853, "Kažkur prie Kauno vykstantis festivalis, nu netoli, dega ir namai ir chebra nešasi alkoholį per tvoras, kažkas beria savo konfeti iš žavaus pilvuko vidaus, kažkas gaudo miško žveris naktį, o kiti tik šoka ir šoka, šoka, šoka, nieko daugiau nemato, nu dar alaus plastikinę stiklinę laiko į kurią poto įstringa paukštuktas ir nusišauna su R45 revolveriu", "Apsuptas miškų! Daugiau nei reikia", new DateTime(2020, 4, 30, 12, 59, 47, 222, DateTimeKind.Local).AddTicks(9816), "Granatų festivalis" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "City", "Country", "District", "EventId", "Lat", "Lng", "Street1", "Street2" },
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
                columns: new[] { "ImageId", "Caption", "EventId", "IsCover", "PathOnServer", "TicketId" },
                values: new object[,]
                {
                    { 1, "event1", 1, true, "D:\\MOKSLAI KTU\\4 kursas\\II semestras\\EventLookup-backend\\EventLookup\\EventLookup\\Shared\\Files\\Images\\event1.jpg", null },
                    { 2, "event2", 2, true, "D:\\MOKSLAI KTU\\4 kursas\\II semestras\\EventLookup-backend\\EventLookup\\EventLookup\\Shared\\Files\\Images\\event2.jpg", null },
                    { 6, "event2_2", 2, true, "D:\\MOKSLAI KTU\\4 kursas\\II semestras\\EventLookup-backend\\EventLookup\\EventLookup\\Shared\\Files\\Images\\event2_2.jpg", null },
                    { 7, "event2_3", 2, true, "D:\\MOKSLAI KTU\\4 kursas\\II semestras\\EventLookup-backend\\EventLookup\\EventLookup\\Shared\\Files\\Images\\event2_3.jpg", null },
                    { 3, "event3", 3, true, "D:\\MOKSLAI KTU\\4 kursas\\II semestras\\EventLookup-backend\\EventLookup\\EventLookup\\Shared\\Files\\Images\\event3.jpg", null },
                    { 4, "event4", 4, true, "D:\\MOKSLAI KTU\\4 kursas\\II semestras\\EventLookup-backend\\EventLookup\\EventLookup\\Shared\\Files\\Images\\event4.jpg", null },
                    { 5, "event5", 5, true, "D:\\MOKSLAI KTU\\4 kursas\\II semestras\\EventLookup-backend\\EventLookup\\EventLookup\\Shared\\Files\\Images\\event5.jpg", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserEvent_EventId",
                table: "UserEvent",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Events_EventId",
                table: "Addresses",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Events_EventId",
                table: "Images",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Tickets_TicketId",
                table: "Images",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "TicketId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Events_EventId",
                table: "Tickets",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Events_EventId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Events_EventId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Tickets_TicketId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Events_EventId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "UserEvent");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Addresses");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Base64Format",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Events_EventId",
                table: "Addresses",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Events_EventId",
                table: "Images",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Tickets_TicketId",
                table: "Images",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Events_EventId",
                table: "Tickets",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
