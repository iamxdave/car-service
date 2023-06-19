using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities.Data
{
    public class CarServiceContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarToBuy> CarToBuys { get; set; }
        public DbSet<CarToRepair> CarToRepairs { get; set; }
        public DbSet<Repair> Repairs { get; set; }
        public DbSet<RepairPart> RepairParts { get; set; }
        public DbSet<Buyout> Buyouts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Mechanic> Mechanics { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Workshop> Workshops { get; set; }

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

            // modelBuilder.Entity<Order>()
            //     .HasOne(e => e.Customer)
            //     .WithMany()
            //     .OnDelete(DeleteBehavior.NoAction);

            // modelBuilder.Entity<Order>()
            //     .HasOne(e => e.STask)
            //     .WithOne(e => e.Order)
            //     .HasForeignKey<STask>(e => e.IdOrder)
            //     .OnDelete(DeleteBehavior.NoAction);

            // modelBuilder.ApplyConfiguration(new CallConfiguration());
            // modelBuilder.ApplyConfiguration(new CarConfiguration());
            // modelBuilder.ApplyConfiguration(new CarRepairConfiguration());
            // modelBuilder.ApplyConfiguration(new CarRepairPartConfiguration());
            // modelBuilder.ApplyConfiguration(new CarSaleConfiguration());
            // modelBuilder.ApplyConfiguration(new CSRepresentativeConfiguration());
            // modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            // modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            // modelBuilder.ApplyConfiguration(new MechanicConfiguration());
            // modelBuilder.ApplyConfiguration(new MechanicSTaskConfiguration());
            // modelBuilder.ApplyConfiguration(new PartConfiguration());
            // modelBuilder.ApplyConfiguration(new PersonConfiguration());
            // modelBuilder.ApplyConfiguration(new ServiceConfiguration());
            // modelBuilder.ApplyConfiguration(new STaskConfiguration());

            // modelBuilder.Entity<Call>();
            // modelBuilder.Entity<CSRepresentative>()
            // .HasBaseType<Employee>();
            // modelBuilder.Entity<Employee>()
            // .HasBaseType<Person>();

            // modelBuilder.Entity<Person>();
            // modelBuilder.Entity<STask>();

            // modelBuilder.Entity<Car>();
            // modelBuilder.Entity<CarRepair>()
            // .HasBaseType<STask>();
            // modelBuilder.Entity<CarRepairPart>();
            // modelBuilder.Entity<CarSale>()
            // .HasBaseType<STask>();
            // modelBuilder.Entity<Customer>()
            // .HasBaseType<Person>();
            // modelBuilder.Entity<Mechanic>()
            // .HasBaseType<Employee>();
            // modelBuilder.Entity<MechanicSTask>();
            // modelBuilder.Entity<Part>();
            // modelBuilder.Entity<Service>();

            // modelBuilder.Entity<Customer>(builder =>
            // {
            //     builder.HasData(
            //         new Customer { IdPerson = 1, Name = "John", Surname = "Smith", BirthDate = new DateTime(1985, 6, 10), Email = "john.smith@example.com", Address = "123 Main Street, Anytown USA", ZipCode = "12345" },
            //         new Customer { IdPerson = 2, Name = "Sarah", Surname = "Johnson", BirthDate = new DateTime(1990, 2, 22), Email = "sarah.johnson@example.com", Address = "456 Park Avenue, Anytown USA", ZipCode = "67890" },
            //         new Customer { IdPerson = 3, Name = "Tom", Surname = "Wilson", BirthDate = new DateTime(1982, 9, 1), Email = "tom.wilson@example.com", Address = "789 Elm Street, Anytown USA", ZipCode = "54321" }
            //     );
            // });

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

            // modelBuilder.Entity<CarToRepair>(builder =>
            // {
            //     builder.HasData(
            //         new CarToRepair { IdCar = 5, IdCustomer = 1, IdService = 1, Model = "Astra", Type = CarType.Sedan},
            //         new CarToRepair { IdCar = 6, IdCustomer = 1, IdService = 2, Model = "Golf", Type = CarType.SUV},
            //         new CarToRepair { IdCar = 7, IdCustomer = 2, IdService = 3, Model = "Civic", Type = CarType.Sedan},
            //         new CarToRepair { IdCar = 8, IdCustomer = 3, IdService = 3, Model = "Fiesta", Type = CarType.SUV}
            //     );
            // });

            modelBuilder.Entity<Mechanic>(builder =>
            {
                builder.HasData(
                    new Mechanic { IdPerson = Guid.NewGuid(), IdWorkshop = 1, Name = "Adam", Surname = "Nowak", BookedDates = new List<DateTime>{DateTime.Today.AddDays(1)}},
                    new Mechanic { IdPerson = Guid.NewGuid(), IdWorkshop = 1, Name = "Ewa", Surname = "Kowalska", BookedDates = new List<DateTime>{DateTime.Today.AddDays(8)}},
                    new Mechanic { IdPerson = Guid.NewGuid(), IdWorkshop = 2, Name = "Tomasz", Surname = "Lis", BookedDates = new List<DateTime>() }
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

            // modelBuilder.Entity<MechanicSTask>(builder => {
            //     builder.HasData(
            //         new MechanicSTask { IdMechanicSTask = 1, IdMechanic = 4, IdSTask = 1 },
            //         new MechanicSTask { IdMechanicSTask = 2, IdMechanic = 4, IdSTask = 2 },
            //         new MechanicSTask { IdMechanicSTask = 3, IdMechanic = 5, IdSTask = 3 },
            //         new MechanicSTask { IdMechanicSTask = 4, IdMechanic = 6, IdSTask = 2 },
            //         new MechanicSTask { IdMechanicSTask = 5, IdMechanic = 6, IdSTask = 4 }
            //     );
            // });

            // modelBuilder.Entity<CarRepair>(builder => {
            //     builder.HasData(
            //         new CarRepair { IdSTask = 1, IdCar = 1, IdOrder = 1, Cost = 150.00m},
            //         new CarRepair { IdSTask = 2, IdCar = 2, IdOrder = 2, Cost = 450.00m},
            //         new CarRepair { IdSTask = 3, IdCar = 3, IdOrder = 3, Cost = 2500.00m},
            //         new CarRepair { IdSTask = 4, IdCar = 4, IdOrder = 4, Cost = 50.00m}
            //     );
            // });

            // modelBuilder.Entity<CarRepairPart>(builder => {
            //     builder.HasData(
            //         new CarRepairPart { IdCarRepairPart = 1, IdCarRepair = 1, IdPart = 1 },
            //         new CarRepairPart { IdCarRepairPart = 2, IdCarRepair = 1, IdPart = 2 },
            //         new CarRepairPart { IdCarRepairPart = 3, IdCarRepair = 1, IdPart = 3 },
            //         new CarRepairPart { IdCarRepairPart = 4, IdCarRepair = 2, IdPart = 4 },
            //         new CarRepairPart { IdCarRepairPart = 5, IdCarRepair = 2, IdPart = 5 },
            //         new CarRepairPart { IdCarRepairPart = 6, IdCarRepair = 2, IdPart = 6 },
            //         new CarRepairPart { IdCarRepairPart = 7, IdCarRepair = 3, IdPart = 7 },
            //         new CarRepairPart { IdCarRepairPart = 8, IdCarRepair = 3, IdPart = 8 },
            //         new CarRepairPart { IdCarRepairPart = 9, IdCarRepair = 4, IdPart = 9 },
            //         new CarRepairPart { IdCarRepairPart = 10, IdCarRepair = 4, IdPart = 10 }
            //     );
            // });

            // modelBuilder.Entity<CarSale>(builder => {
            //         builder.HasData(
            //         new CarSale { IdSTask = 5, IdCar = 1, IdOrder = 5, Cost = 20000.00m, ManufacturerWarranty = 24, Price = 22000.00m},
            //         new CarSale { IdSTask = 6, IdCar = 2, IdOrder = 6, Cost = 35000.00m, ManufacturerWarranty = 36, Price = 38000.00m}
            //     );
            // });

            // modelBuilder.Entity<Order>(builder => {
            //     builder.HasData(
            //         new Order { IdOrder = 1, IdCustomer = 1, IdSTask = 2, IdMechanic = 1, DateCreated = new DateTime(2022, 1, 1), DateCompleted = new DateTime(2022, 1, 3), Cost = 500, Status = OrderStatus.Completed },
            //         new Order { IdOrder = 2, IdCustomer = 1, IdSTask = 3, IdMechanic = 1, DateCreated = new DateTime(2022, 1, 4), DateCompleted = new DateTime(2022, 1, 6), Cost = 800, Status = OrderStatus.Completed },
            //         new Order { IdOrder = 3, IdCustomer = 2, IdSTask = 1, IdMechanic = 2, DateCreated = new DateTime(2022, 1, 2), DateCompleted = new DateTime(2022, 2, 10), Cost = 200, Status = OrderStatus.InProgress },
            //         new Order { IdOrder = 4, IdCustomer = 2, IdSTask = 3, IdMechanic = 2, DateCreated = new DateTime(2022, 1, 5), DateCompleted = new DateTime(2022, 2, 12), Cost = 1000, Status = OrderStatus.InProgress },
            //         new Order { IdOrder = 5, IdCustomer = 3, IdSTask = 2, IdMechanic = 3, DateCreated = new DateTime(2022, 1, 3), DateCompleted = new DateTime(2022, 2, 15), Cost = 300, Status = OrderStatus.InProgress },
            //         new Order { IdOrder = 6, IdCustomer = 3, IdSTask = 1, IdMechanic = 3, DateCreated = new DateTime(2022, 1, 6), DateCompleted = new DateTime(2022, 2, 19), Cost = 150, Status = OrderStatus.InProgress }
            //     );
            // });
        }
    }
}