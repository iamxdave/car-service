using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities.Data
{
    public class CarServiceContext : DbContext
    {
        public DbSet<Car> Cars => Set<Car>();
        public DbSet<CarToBuy> CarToBuys => Set<CarToBuy>();
        public DbSet<CarToRepair> CarToRepairs => Set<CarToRepair>();
        public DbSet<Repair> Repairs => Set<Repair>();
        public DbSet<RepairPart> RepairParts => Set<RepairPart>();
        public DbSet<Buyout> Buyouts => Set<Buyout>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Mechanic> Mechanics => Set<Mechanic>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Part> Parts => Set<Part>();
        public DbSet<Person> People => Set<Person>();
        public DbSet<Workshop> Workshops => Set<Workshop>();

        public CarServiceContext(DbContextOptions<CarServiceContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(e => e.Email)
                .IsUnique();


            modelBuilder.Entity<Workshop>(builder =>
            {
                builder.HasData(
                    new Workshop { IdWorkshop = 1, Name = "Car Service Center", Address = "123 Main Street, Anytown USA", PhoneNumber = "123-456-7890" },
                    new Workshop { IdWorkshop = 2, Name = "Auto Repair Shop", Address = "456 Park Avenue, Anytown USA", PhoneNumber = "555-123-4567" },
                    new Workshop { IdWorkshop = 3, Name = "Mechanic Shop", Address = "789 Elm Street, Anytown USA", PhoneNumber = "999-888-7777" }
                );
            });

            modelBuilder.Entity<CarToBuy>(builder =>
            {
                builder.HasData(
                    new CarToBuy { IdCar = Guid.NewGuid(), IdWorkshop = 1, Brand = "Ford", Model = "Fiesta", Cost = 30000, Description = "The Ford Fiesta is a popular compact car known for its affordability and energetic performance. It offers a comfortable ride and is an excellent choice for city driving." },
                    new CarToBuy { IdCar = Guid.NewGuid(), IdWorkshop = 1, Brand = "Honda", Model = "Civic", Cost = 20000, Description = "The Honda Civic is a reliable and fuel-efficient compact car. It combines a stylish design, spacious interior, and advanced features, making it a versatile option for various needs." },
                    new CarToBuy { IdCar = Guid.NewGuid(), IdWorkshop = 1, Brand = "Opel", Model = "Astra", Cost = 50000, Description = "The Opel Astra is a compact car known for its elegant style and high-quality craftsmanship. It offers advanced technologies, a comfortable interior, and a great driving experience on longer journeys." },
                    new CarToBuy { IdCar = Guid.NewGuid(), IdWorkshop = 2, Brand = "Volkswagen", Model = "Golf", Cost = 40000, Description = "The Volkswagen Golf is an iconic compact car known for its solid construction, precise handling, and high-quality materials. It offers a versatile package and a wide range of features." },
                    new CarToBuy { IdCar = Guid.NewGuid(), IdWorkshop = 2, Brand = "Tesla", Model = "Elektra", Cost = 70000, Description = "The Tesla Elektra is a luxury electric car with a futuristic design. It boasts an impressive range and advanced autonomous features, making it a perfect choice for tech enthusiasts." },
                    new CarToBuy { IdCar = Guid.NewGuid(), IdWorkshop = 2, Brand = "BMW", Model = "Swiftsport", Cost = 55000, Description = "The BMW Swiftsport is a sporty car with refined style and a powerful engine. It offers dynamic driving and unmatched excitement behind the wheel, satisfying the needs of sports car enthusiasts." },
                    new CarToBuy { IdCar = Guid.NewGuid(), IdWorkshop = 2, Brand = "Mercedes", Model = "Aventura", Cost = 90000, Description = "The Mercedes Aventura is a luxurious SUV that combines elegance and comfort with impressive all-wheel drive capabilities. Its spacious interior and advanced safety systems make every journey a true pleasure." },
                    new CarToBuy { IdCar = Guid.NewGuid(), IdWorkshop = 2, Brand = "Audi", Model = "Horizon", Cost = 75000, Description = "The Audi Horizon is an elegant sedan with modern technological solutions. Its refined interior and exceptional acoustics ensure a comfortable journey on any route." },
                    new CarToBuy { IdCar = Guid.NewGuid(), IdWorkshop = 3, Brand = "Toyota", Model = "Venture", Cost = 25000, Description = "The Toyota Venture is a compact crossover that excels in urban conditions. Equipped with advanced safety systems and an economical engine, it is an ideal companion for daily commuting." },
                    new CarToBuy { IdCar = Guid.NewGuid(), IdWorkshop = 3, Brand = "Lamborghini", Model = "Huracan", Cost = 300000, Description = "The Lamborghini Huracan is a high-performance supercar that embodies speed, luxury, and style. With its powerful engine and eye-catching design, it delivers an exhilarating driving experience." },
                    new CarToBuy { IdCar = Guid.NewGuid(), IdWorkshop = 3, Brand = "Porsche", Model = "911", Cost = 250000, Description = "The Porsche 911 is an iconic sports car that combines timeless design with exceptional performance. Its precise handling, powerful engine, and luxurious interior make it a dream car for enthusiasts." },
                    new CarToBuy { IdCar = Guid.NewGuid(), IdWorkshop = 3, Brand = "Ferrari", Model = "488 GTB", Cost = 350000, Description = "The Ferrari 488 GTB is a legendary Italian supercar that represents the pinnacle of automotive engineering. With its breathtaking speed, aerodynamic design, and luxurious features, it is a symbol of automotive excellence." }
                );

            });

            modelBuilder.Entity<Mechanic>(builder =>
            {
                builder.HasData(
                    new Mechanic
                    {
                        IdPerson = Guid.NewGuid(),
                        IdWorkshop = 1,
                        Name = "Adam",
                        Surname = "Nowak",
                        BookedDates = new List<Reservation>()
                    },
                    new Mechanic
                    {
                        IdPerson = Guid.NewGuid(),
                        IdWorkshop = 1,
                        Name = "Ewa",
                        Surname = "Kowalska",
                        BookedDates = new List<Reservation>()
                    },
                    new Mechanic
                    {
                        IdPerson = Guid.NewGuid(),
                        IdWorkshop = 2,
                        Name = "Tomasz",
                        Surname = "Lis",
                        BookedDates = new List<Reservation>()
                    },
                    new Mechanic
                    {
                        IdPerson = Guid.NewGuid(),
                        IdWorkshop = 1,
                        Name = "Jan",
                        Surname = "Kowalski",
                        BookedDates = new List<Reservation>()
                    },
                    new Mechanic
                    {
                        IdPerson = Guid.NewGuid(),
                        IdWorkshop = 2,
                        Name = "Anna",
                        Surname = "Nowakowska",
                        BookedDates = new List<Reservation>()
                    },
                    new Mechanic
                    {
                        IdPerson = Guid.NewGuid(),
                        IdWorkshop = 1,
                        Name = "Piotr",
                        Surname = "Wójcik",
                        BookedDates = new List<Reservation>()
                    },
                    new Mechanic
                    {
                        IdPerson = Guid.NewGuid(),
                        IdWorkshop = 2,
                        Name = "Magdalena",
                        Surname = "Kaczmarek",
                        BookedDates = new List<Reservation>()
                    }
                );
            });

            modelBuilder.Entity<Part>(builder =>
            {
                builder.HasData(
                    new Part { IdPart = 1, Name = "Brake pads"},
                    new Part { IdPart = 2, Name = "Oil filter"},
                    new Part { IdPart = 3, Name = "Spark plugs"},
                    new Part { IdPart = 4, Name = "Air filter"},
                    new Part { IdPart = 5, Name = "Alternator"},
                    new Part { IdPart = 6, Name = "Battery"},
                    new Part { IdPart = 7, Name = "Radiator"},
                    new Part { IdPart = 8, Name = "Water pump"},
                    new Part { IdPart = 9, Name = "Starter motor"},
                    new Part { IdPart = 10, Name = "Fuel pump"}
                );
            });
        }
    }
}