using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities.Data
{
    public class CarServiceContext : DbContext
    {
        public DbSet<Call> Calls { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarForSale> CarForSales { get; set; }
        public DbSet<CarToRepair> CarToRepairs { get; set; }
        public DbSet<Repair> Repairs { get; set; }
        public DbSet<RepairPart> RepairParts { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerServiceRepresentative> CSRepresentatives { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Mechanic> Mechanics { get; set; }
        public DbSet<MechanicAssistance> MechanicAssistance { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Workshop> Services { get; set; }
        public DbSet<Assistance> Assistances { get; set; }

        public CarServiceContext(DbContextOptions<CarServiceContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>()
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

            modelBuilder.Entity<CarForSale>(builder =>
            {
                builder.HasData(
                    new CarForSale { IdCar = 1, IdService = 1, Model = "Astra", Type = CarType.Sedan, Cost = 50000, Warranty = 3},
                    new CarForSale { IdCar = 2, IdService = 2, Model = "Golf", Type = CarType.SUV, Cost = 40000, Warranty = 4},
                    new CarForSale { IdCar = 3, IdService = 3, Model = "Civic", Type = CarType.Sedan, Cost = 20000, Warranty = 2},
                    new CarForSale { IdCar = 4, IdService = 3, Model = "Fiesta", Type = CarType.SUV, Cost = 30000, Warranty = 5}
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
                    new Mechanic { IdPerson = 1, IdWorkshop = 1, Name = "Adam", Surname = "Nowak", BirthDate = new DateTime(1990, 1, 1), EmploymentDate = new DateTime(2020, 1, 1), MonthlySalary = 3000, BookedDates = new List<DateTime>() },
                    new Mechanic { IdPerson = 2, IdWorkshop = 1, Name = "Ewa", Surname = "Kowalska", BirthDate = new DateTime(1992, 2, 1), EmploymentDate = new DateTime(2021, 2, 1), MonthlySalary = 3200, BookedDates = new List<DateTime>() },
                    new Mechanic { IdPerson = 3, IdWorkshop = 2, Name = "Tomasz", Surname = "Lis", BirthDate = new DateTime(1988, 3, 1), EmploymentDate = new DateTime(2022, 3, 1), MonthlySalary = 3500, BookedDates = new List<DateTime>() }
                );
            });

            modelBuilder.Entity<Part>(builder =>
            {
                builder.HasData(
                    new Part { IdPart = 1, Name = "Brake pads", Cost = 50 },
                    new Part { IdPart = 2, Name = "Oil filter", Cost = 10 },
                    new Part { IdPart = 3, Name = "Spark plugs", Cost = 20 },
                    new Part { IdPart = 4, Name = "Air filter", Cost = 15 },
                    new Part { IdPart = 5, Name = "Alternator", Cost = 150 },
                    new Part { IdPart = 6, Name = "Battery", Cost = 80 },
                    new Part { IdPart = 7, Name = "Radiator", Cost = 100 },
                    new Part { IdPart = 8, Name = "Water pump", Cost = 70 },
                    new Part { IdPart = 9, Name = "Starter motor", Cost = 120 },
                    new Part { IdPart = 10, Name = "Fuel pump", Cost = 90 }
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