﻿// <auto-generated />
using System;
using EventLookup.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EventLookup.Migrations
{
    [DbContext(typeof(EventLookupContext))]
    [Migration("20200405113054_authorizationValidation")]
    partial class authorizationValidation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EventLookup.Domain.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("Lat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lng")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street2")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AddressId");

                    b.HasIndex("EventId")
                        .IsUnique()
                        .HasFilter("[EventId] IS NOT NULL");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            AddressId = 1,
                            City = "Vilnius",
                            Country = "Lietuva",
                            EventId = 1,
                            Lat = "54.6804524",
                            Lng = "25.2811559",
                            Street1 = "Vokiečių g. 15"
                        },
                        new
                        {
                            AddressId = 2,
                            City = "Kaunas",
                            Country = "Lietuva",
                            EventId = 2,
                            Lat = "54.8965887",
                            Lng = "23.9244845",
                            Street1 = "Laisvės al. 3"
                        },
                        new
                        {
                            AddressId = 3,
                            City = "Berlynas",
                            Country = "Vokietija",
                            EventId = 3,
                            Lat = "50.8821039",
                            Lng = "10.4400291",
                            Street1 = "Grichitz st. 15"
                        },
                        new
                        {
                            AddressId = 4,
                            City = "Klaipėda",
                            Country = "Lietuva",
                            EventId = 4,
                            Lat = "55.7373152",
                            Lng = "21.0837908",
                            Street1 = "Melnragės paplūdimys"
                        },
                        new
                        {
                            AddressId = 5,
                            City = "Kaunas",
                            Country = "Lietuva",
                            District = "Rumšiškės",
                            EventId = 5,
                            Lat = "54.8685114",
                            Lng = "24.1786306",
                            Street1 = "Vokiečių g. 15"
                        });
                });

            modelBuilder.Entity("EventLookup.Domain.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DaysEventActive")
                        .HasColumnType("int");

                    b.Property<DateTime>("FinishDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GoingPeopleCount")
                        .HasColumnType("int");

                    b.Property<int>("InterestedPeopleCount")
                        .HasColumnType("int");

                    b.Property<string>("LongDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventId");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            EventId = 1,
                            DaysEventActive = 3,
                            FinishDate = new DateTime(2020, 5, 5, 14, 30, 53, 845, DateTimeKind.Local).AddTicks(8168),
                            GoingPeopleCount = 247,
                            InterestedPeopleCount = 792,
                            LongDescription = "Ne tik patogioje vietoje bet ir su super patraukliomis kainomis",
                            ShortDescription = "\"Užsuk\" restoranas patogioje Vilniaus vietoje",
                            StartDate = new DateTime(2020, 4, 5, 14, 30, 53, 841, DateTimeKind.Local).AddTicks(5763),
                            Title = "\"Užsuk\" Restorano atidarymas"
                        },
                        new
                        {
                            EventId = 2,
                            DaysEventActive = 3,
                            FinishDate = new DateTime(2020, 5, 5, 14, 30, 53, 845, DateTimeKind.Local).AddTicks(9354),
                            GoingPeopleCount = 159,
                            InterestedPeopleCount = 981,
                            LongDescription = "Ne tik patogioje vietoje bet ir su super patraukliomis kainomis, ir ne niekas nepakratys jūsų čia",
                            ShortDescription = "\"Užsuk\" restoranas patogioje Kauno vietoje",
                            StartDate = new DateTime(2020, 4, 7, 14, 30, 53, 845, DateTimeKind.Local).AddTicks(9312),
                            Title = "\"Pakrisk\" Restorano atidarymas"
                        },
                        new
                        {
                            EventId = 3,
                            DaysEventActive = 3,
                            FinishDate = new DateTime(2020, 5, 13, 14, 30, 53, 845, DateTimeKind.Local).AddTicks(9382),
                            GoingPeopleCount = 25505,
                            InterestedPeopleCount = 70151,
                            LongDescription = "Festivalis jau daug metų iš eilės vykstantis Vokietijoje į kurį susirenka dešimtimis tūkstančių žmonių, kuriems reikia vieno - pašvęst taip kaip niekad dar nebuvo matę",
                            ShortDescription = "Popiuliarumas išmatuojamas skaičiais - kokybė tai kur kas daugiau",
                            StartDate = new DateTime(2020, 5, 10, 14, 30, 53, 845, DateTimeKind.Local).AddTicks(9378),
                            Title = "Ultra Music Festival"
                        },
                        new
                        {
                            EventId = 4,
                            DaysEventActive = 4,
                            FinishDate = new DateTime(2020, 4, 17, 14, 30, 53, 845, DateTimeKind.Local).AddTicks(9389),
                            GoingPeopleCount = 4210,
                            InterestedPeopleCount = 7057,
                            LongDescription = "Daug metų besitęsiantis muzikos festivalis su begale pramogų, o svarbiausia ir marozų yra",
                            ShortDescription = "Atmosfera, muzika, garsas, jūros krantas, nuotaika",
                            StartDate = new DateTime(2020, 4, 13, 14, 30, 53, 845, DateTimeKind.Local).AddTicks(9386),
                            Title = "Karklės festivalis"
                        },
                        new
                        {
                            EventId = 5,
                            DaysEventActive = 3,
                            FinishDate = new DateTime(2020, 5, 9, 14, 30, 53, 845, DateTimeKind.Local).AddTicks(9396),
                            GoingPeopleCount = 2235,
                            InterestedPeopleCount = 6853,
                            LongDescription = "Kažkur prie Kauno vykstantis festivalis, nu netoli, dega ir namai ir chebra nešasi alkoholį per tvoras, kažkas beria savo konfeti iš žavaus pilvuko vidaus, kažkas gaudo miško žveris naktį, o kiti tik šoka ir šoka, šoka, šoka, nieko daugiau nemato, nu dar alaus plastikinę stiklinę laiko į kurią poto įstringa paukštuktas ir nusišauna su R45 revolveriu",
                            ShortDescription = "Apsuptas miškų! Daugiau nei reikia",
                            StartDate = new DateTime(2020, 5, 6, 14, 30, 53, 845, DateTimeKind.Local).AddTicks(9393),
                            Title = "Granatų festivalis"
                        });
                });

            modelBuilder.Entity("EventLookup.Domain.Models.Image", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Caption")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<bool>("IsCover")
                        .HasColumnType("bit");

                    b.Property<string>("PathOnServer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TicketId")
                        .HasColumnType("int");

                    b.HasKey("ImageId");

                    b.HasIndex("EventId");

                    b.HasIndex("TicketId")
                        .IsUnique()
                        .HasFilter("[TicketId] IS NOT NULL");

                    b.ToTable("Images");

                    b.HasData(
                        new
                        {
                            ImageId = 1,
                            Caption = "event1",
                            EventId = 1,
                            IsCover = true,
                            PathOnServer = "D:\\MOKSLAI KTU\\4 kursas\\II semestras\\EventLookup-backend\\EventLookup\\EventLookup\\Shared\\Files\\Images\\event1.jpg"
                        },
                        new
                        {
                            ImageId = 2,
                            Caption = "event2",
                            EventId = 2,
                            IsCover = true,
                            PathOnServer = "D:\\MOKSLAI KTU\\4 kursas\\II semestras\\EventLookup-backend\\EventLookup\\EventLookup\\Shared\\Files\\Images\\event2.jpg"
                        },
                        new
                        {
                            ImageId = 3,
                            Caption = "event3",
                            EventId = 3,
                            IsCover = true,
                            PathOnServer = "D:\\MOKSLAI KTU\\4 kursas\\II semestras\\EventLookup-backend\\EventLookup\\EventLookup\\Shared\\Files\\Images\\event3.jpg"
                        },
                        new
                        {
                            ImageId = 4,
                            Caption = "event4",
                            EventId = 4,
                            IsCover = true,
                            PathOnServer = "D:\\MOKSLAI KTU\\4 kursas\\II semestras\\EventLookup-backend\\EventLookup\\EventLookup\\Shared\\Files\\Images\\event4.jpg"
                        },
                        new
                        {
                            ImageId = 5,
                            Caption = "event5",
                            EventId = 5,
                            IsCover = true,
                            PathOnServer = "D:\\MOKSLAI KTU\\4 kursas\\II semestras\\EventLookup-backend\\EventLookup\\EventLookup\\Shared\\Files\\Images\\event5.jpg"
                        },
                        new
                        {
                            ImageId = 6,
                            Caption = "event2_2",
                            EventId = 2,
                            IsCover = true,
                            PathOnServer = "D:\\MOKSLAI KTU\\4 kursas\\II semestras\\EventLookup-backend\\EventLookup\\EventLookup\\Shared\\Files\\Images\\event2_2.jpg"
                        },
                        new
                        {
                            ImageId = 7,
                            Caption = "event2_3",
                            EventId = 2,
                            IsCover = true,
                            PathOnServer = "D:\\MOKSLAI KTU\\4 kursas\\II semestras\\EventLookup-backend\\EventLookup\\EventLookup\\Shared\\Files\\Images\\event2_3.jpg"
                        });
                });

            modelBuilder.Entity("EventLookup.Domain.Models.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("Distributor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DistributorUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("TicketId");

                    b.HasIndex("EventId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("EventLookup.Domain.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Biography")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EventLookup.Domain.Models.UserEvent", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<bool>("Created")
                        .HasColumnType("bit");

                    b.Property<bool>("Going")
                        .HasColumnType("bit");

                    b.Property<bool>("Interested")
                        .HasColumnType("bit");

                    b.HasKey("UserId", "EventId");

                    b.HasIndex("EventId");

                    b.ToTable("UserEvent");
                });

            modelBuilder.Entity("EventLookup.Domain.Models.Address", b =>
                {
                    b.HasOne("EventLookup.Domain.Models.Event", "Event")
                        .WithOne("Address")
                        .HasForeignKey("EventLookup.Domain.Models.Address", "EventId");
                });

            modelBuilder.Entity("EventLookup.Domain.Models.Image", b =>
                {
                    b.HasOne("EventLookup.Domain.Models.Event", "Event")
                        .WithMany("Images")
                        .HasForeignKey("EventId");

                    b.HasOne("EventLookup.Domain.Models.Ticket", "Ticket")
                        .WithOne("Image")
                        .HasForeignKey("EventLookup.Domain.Models.Image", "TicketId");
                });

            modelBuilder.Entity("EventLookup.Domain.Models.Ticket", b =>
                {
                    b.HasOne("EventLookup.Domain.Models.Event", "Event")
                        .WithMany("Tickets")
                        .HasForeignKey("EventId");
                });

            modelBuilder.Entity("EventLookup.Domain.Models.UserEvent", b =>
                {
                    b.HasOne("EventLookup.Domain.Models.Event", "Event")
                        .WithMany("UserEvents")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventLookup.Domain.Models.User", "User")
                        .WithMany("UserEvents")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}