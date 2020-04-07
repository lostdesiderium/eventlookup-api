using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using EventLookup.Domain.Models;
using System.IO;

namespace EventLookup.Persistence.Context
{
    public class EventLookupContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserEvent> UserEvents { get; set; }

        public EventLookupContext(DbContextOptions<EventLookupContext> options) : base(options) 
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserEvent>().HasKey(k => new { k.UserId, k.EventId });
            builder.Entity<UserEvent>().HasOne(ue => ue.User)
                .WithMany(u => u.UserEvents)
                .HasForeignKey(ue => ue.UserId);
            builder.Entity<UserEvent>().HasOne(ue => ue.Event)
                .WithMany(u => u.UserEvents)
                .HasForeignKey(ue => ue.EventId);

            // EVENT SEEDING
            builder.Entity<Event>().HasData(
            new Event
            {
                EventId = 1,
                Title = "\"Užsuk\" Restorano atidarymas",
                ShortDescription = "\"Užsuk\" restoranas patogioje Vilniaus vietoje",
                LongDescription = "Ne tik patogioje vietoje bet ir su super patraukliomis kainomis",
                GoingPeopleCount = 247,
                InterestedPeopleCount = 792,
                StartDate = DateTime.Now,
                FinishDate = DateTime.Now.AddMonths(1),
                DaysEventActive = 3
            },
            new Event
            {
                EventId = 2,
                Title = "\"Pakrisk\" Restorano atidarymas",
                ShortDescription = "\"Užsuk\" restoranas patogioje Kauno vietoje",
                LongDescription = "Ne tik patogioje vietoje bet ir su super patraukliomis kainomis, ir ne niekas nepakratys jūsų čia",
                GoingPeopleCount = 159,
                InterestedPeopleCount = 981,
                StartDate = DateTime.Now.AddDays(2.0),
                FinishDate = DateTime.Now.AddMonths(1),
                DaysEventActive = 3
            },
            new Event
            {
                EventId = 3,
                Title = "Ultra Music Festival",
                ShortDescription = "Popiuliarumas išmatuojamas skaičiais - kokybė tai kur kas daugiau",
                LongDescription = "Festivalis jau daug metų iš eilės vykstantis Vokietijoje į kurį susirenka dešimtimis tūkstančių žmonių" +
                ", kuriems reikia vieno - pašvęst taip kaip niekad dar nebuvo matę",
                GoingPeopleCount = 25505,
                InterestedPeopleCount = 70151,
                StartDate = DateTime.Now.AddMonths(1).AddDays(5.0),
                FinishDate = DateTime.Now.AddMonths(1).AddDays(8.0),
                DaysEventActive = 3
            },
            new Event
            {
                EventId = 4,
                Title = "Karklės festivalis",
                ShortDescription = "Atmosfera, muzika, garsas, jūros krantas, nuotaika",
                LongDescription = "Daug metų besitęsiantis muzikos festivalis su begale pramogų, o svarbiausia ir marozų yra",
                GoingPeopleCount = 4210,
                InterestedPeopleCount = 7057,
                StartDate = DateTime.Now.AddDays(8.0),
                FinishDate = DateTime.Now.AddDays(12.0),
                DaysEventActive = 4
            },
            new Event
            {
                EventId = 5,
                Title = "Granatų festivalis",
                ShortDescription = "Apsuptas miškų! Daugiau nei reikia",
                LongDescription = "Kažkur prie Kauno vykstantis festivalis, nu netoli, dega ir namai ir chebra nešasi alkoholį per tvoras" +
                ", kažkas beria savo konfeti iš žavaus pilvuko vidaus, kažkas gaudo miško žveris naktį, o kiti tik šoka ir šoka, šoka, šoka, " +
                "nieko daugiau nemato, nu dar alaus plastikinę stiklinę laiko į kurią poto įstringa paukštuktas ir nusišauna su R45 revolveriu",
                GoingPeopleCount = 2235,
                InterestedPeopleCount = 6853,
                StartDate = DateTime.Now.AddMonths(1).AddDays(1.0),
                FinishDate = DateTime.Now.AddMonths(1).AddDays(4.0),
                DaysEventActive = 3
            }
            );
            // EVENTS SEEDING END


            // ADDRESS SEEDING
            builder.Entity<Address>().HasData(
            new Address 
            {
                AddressId = 1,
                Country = "Lietuva",
                City = "Vilnius",
                Street1 = "Vokiečių g. 15",
                EventId = 1,
                Lat = "54.6804524",
                Lng = "25.2811559"
            },
            new Address
            {
                AddressId = 2,
                Country = "Lietuva",
                City = "Kaunas",
                Street1 = "Laisvės al. 3",
                EventId = 2,
                Lat = "54.8965887",
                Lng = "23.9244845"
            },
            new Address
            {
                AddressId = 3,
                Country = "Vokietija",
                City = "Berlynas",
                Street1 = "Grichitz st. 15",
                EventId = 3,
                Lat = "50.8821039",
                Lng = "10.4400291"
            },
            new Address
            {
                AddressId = 4,
                Country = "Lietuva",
                City = "Klaipėda",
                Street1 = "Melnragės paplūdimys",
                EventId = 4,
                Lat = "55.7373152",
                Lng = "21.0837908"
            },
            new Address
            {
                AddressId = 5,
                Country = "Lietuva",
                City = "Kaunas",
                District = "Rumšiškės",
                Street1 = "Vokiečių g. 15",
                EventId = 5,
                Lat = "54.8685114",
                Lng = "24.1786306"
            }
            );
            // ADDRESS SEEDING END


            // IMAGE SEEDING
            builder.Entity<Image>().HasData(
            new Image
            {
                ImageId = 1,
                Caption = "event1",
                IsCover = true,
                PathOnServer = @"D:\MOKSLAI KTU\4 kursas\II semestras\EventLookup-backend\EventLookup\EventLookup\Shared\Files\Images\event1.jpg",
                EventId = 1
            },
            new Image
            {
                ImageId = 2,
                Caption = "event2",
                IsCover = true,
                PathOnServer = @"D:\MOKSLAI KTU\4 kursas\II semestras\EventLookup-backend\EventLookup\EventLookup\Shared\Files\Images\event2.jpg",
                EventId = 2
            },
            new Image
            {
                ImageId = 3,
                Caption = "event3",
                IsCover = true,
                PathOnServer = @"D:\MOKSLAI KTU\4 kursas\II semestras\EventLookup-backend\EventLookup\EventLookup\Shared\Files\Images\event3.jpg",
                EventId = 3
            },
            new Image
            {
                ImageId = 4,
                Caption = "event4",
                IsCover = true,
                PathOnServer = @"D:\MOKSLAI KTU\4 kursas\II semestras\EventLookup-backend\EventLookup\EventLookup\Shared\Files\Images\event4.jpg",
                EventId = 4
            },
            new Image
            {
                ImageId = 5,
                Caption = "event5",
                IsCover = true,
                PathOnServer = @"D:\MOKSLAI KTU\4 kursas\II semestras\EventLookup-backend\EventLookup\EventLookup\Shared\Files\Images\event5.jpg",
                EventId = 5
            },
            new Image
            {
                ImageId = 6,
                Caption = "event2_2",
                IsCover = true,
                PathOnServer = @"D:\MOKSLAI KTU\4 kursas\II semestras\EventLookup-backend\EventLookup\EventLookup\Shared\Files\Images\event2_2.jpg",
                EventId = 2
            },
            new Image
            {
                ImageId = 7,
                Caption = "event2_3",
                IsCover = true,
                PathOnServer = @"D:\MOKSLAI KTU\4 kursas\II semestras\EventLookup-backend\EventLookup\EventLookup\Shared\Files\Images\event2_3.jpg",
                EventId = 2
            }
            );
            // IMAGE SEEDING END


        }


    }
}
