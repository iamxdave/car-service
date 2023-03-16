﻿// <auto-generated />
using System;
using Entities.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace backend.Migrations
{
    [DbContext(typeof(CarServiceContext))]
    partial class CarServiceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Entities.Models.Call", b =>
                {
                    b.Property<int>("IdCall")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdCall"));

                    b.Property<int?>("CustomerIdPerson")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("IdCSRepresentative")
                        .HasColumnType("integer");

                    b.Property<int>("IdCustomer")
                        .HasColumnType("integer");

                    b.HasKey("IdCall");

                    b.HasIndex("CustomerIdPerson");

                    b.HasIndex("IdCSRepresentative");

                    b.HasIndex("IdCustomer");

                    b.ToTable("Calls");
                });

            modelBuilder.Entity("Entities.Models.Car", b =>
                {
                    b.Property<int>("IdCar")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdCar"));

                    b.Property<int?>("CustomerIdPerson")
                        .HasColumnType("integer");

                    b.Property<int>("IdCustomer")
                        .HasColumnType("integer");

                    b.Property<int>("IdService")
                        .HasColumnType("integer");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("IdCar");

                    b.HasIndex("CustomerIdPerson");

                    b.HasIndex("IdCustomer");

                    b.HasIndex("IdService");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            IdCar = 1,
                            IdCustomer = 1,
                            IdService = 1,
                            Model = "Astra",
                            Type = 0
                        },
                        new
                        {
                            IdCar = 2,
                            IdCustomer = 2,
                            IdService = 2,
                            Model = "Golf",
                            Type = 1
                        },
                        new
                        {
                            IdCar = 3,
                            IdCustomer = 3,
                            IdService = 3,
                            Model = "Civic",
                            Type = 0
                        },
                        new
                        {
                            IdCar = 4,
                            IdCustomer = 4,
                            IdService = 3,
                            Model = "Fiesta",
                            Type = 1
                        });
                });

            modelBuilder.Entity("Entities.Models.CarRepairPart", b =>
                {
                    b.Property<int>("IdCarRepairPart")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdCarRepairPart"));

                    b.Property<int>("IdCarRepair")
                        .HasColumnType("integer");

                    b.Property<int>("IdPart")
                        .HasColumnType("integer");

                    b.HasKey("IdCarRepairPart");

                    b.HasIndex("IdCarRepair");

                    b.HasIndex("IdPart");

                    b.ToTable("CarRepairParts");

                    b.HasData(
                        new
                        {
                            IdCarRepairPart = 1,
                            IdCarRepair = 1,
                            IdPart = 1
                        },
                        new
                        {
                            IdCarRepairPart = 2,
                            IdCarRepair = 1,
                            IdPart = 2
                        },
                        new
                        {
                            IdCarRepairPart = 3,
                            IdCarRepair = 1,
                            IdPart = 3
                        },
                        new
                        {
                            IdCarRepairPart = 4,
                            IdCarRepair = 2,
                            IdPart = 4
                        },
                        new
                        {
                            IdCarRepairPart = 5,
                            IdCarRepair = 2,
                            IdPart = 5
                        },
                        new
                        {
                            IdCarRepairPart = 6,
                            IdCarRepair = 2,
                            IdPart = 6
                        },
                        new
                        {
                            IdCarRepairPart = 7,
                            IdCarRepair = 3,
                            IdPart = 7
                        },
                        new
                        {
                            IdCarRepairPart = 8,
                            IdCarRepair = 3,
                            IdPart = 8
                        },
                        new
                        {
                            IdCarRepairPart = 9,
                            IdCarRepair = 4,
                            IdPart = 9
                        },
                        new
                        {
                            IdCarRepairPart = 10,
                            IdCarRepair = 4,
                            IdPart = 10
                        });
                });

            modelBuilder.Entity("Entities.Models.MechanicOrder", b =>
                {
                    b.Property<int>("IdMechanicOrder")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdMechanicOrder"));

                    b.Property<int>("IdMechanic")
                        .HasColumnType("integer");

                    b.Property<int>("IdOrder")
                        .HasColumnType("integer");

                    b.HasKey("IdMechanicOrder");

                    b.HasIndex("IdMechanic");

                    b.HasIndex("IdOrder");

                    b.ToTable("MechanicOrders");

                    b.HasData(
                        new
                        {
                            IdMechanicOrder = 1,
                            IdMechanic = 4,
                            IdOrder = 1
                        },
                        new
                        {
                            IdMechanicOrder = 2,
                            IdMechanic = 4,
                            IdOrder = 2
                        },
                        new
                        {
                            IdMechanicOrder = 3,
                            IdMechanic = 5,
                            IdOrder = 3
                        },
                        new
                        {
                            IdMechanicOrder = 4,
                            IdMechanic = 5,
                            IdOrder = 4
                        },
                        new
                        {
                            IdMechanicOrder = 5,
                            IdMechanic = 5,
                            IdOrder = 5
                        },
                        new
                        {
                            IdMechanicOrder = 6,
                            IdMechanic = 6,
                            IdOrder = 6
                        });
                });

            modelBuilder.Entity("Entities.Models.MechanicSTask", b =>
                {
                    b.Property<int>("IdMechanicSTask")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdMechanicSTask"));

                    b.Property<int>("IdMechanic")
                        .HasColumnType("integer");

                    b.Property<int>("IdSTask")
                        .HasColumnType("integer");

                    b.HasKey("IdMechanicSTask");

                    b.HasIndex("IdMechanic");

                    b.HasIndex("IdSTask");

                    b.ToTable("MechanicSTasks");

                    b.HasData(
                        new
                        {
                            IdMechanicSTask = 1,
                            IdMechanic = 4,
                            IdSTask = 1
                        },
                        new
                        {
                            IdMechanicSTask = 2,
                            IdMechanic = 4,
                            IdSTask = 2
                        },
                        new
                        {
                            IdMechanicSTask = 3,
                            IdMechanic = 5,
                            IdSTask = 3
                        },
                        new
                        {
                            IdMechanicSTask = 4,
                            IdMechanic = 6,
                            IdSTask = 2
                        },
                        new
                        {
                            IdMechanicSTask = 5,
                            IdMechanic = 6,
                            IdSTask = 4
                        });
                });

            modelBuilder.Entity("Entities.Models.Order", b =>
                {
                    b.Property<int>("IdOrder")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdOrder"));

                    b.Property<decimal>("Cost")
                        .HasColumnType("numeric");

                    b.Property<int?>("CustomerIdPerson")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DateCompleted")
                        .IsRequired()
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("IdCustomer")
                        .HasColumnType("integer");

                    b.Property<int>("IdSTask")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("IdOrder");

                    b.HasIndex("CustomerIdPerson");

                    b.HasIndex("IdCustomer");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            IdOrder = 1,
                            Cost = 500m,
                            DateCompleted = new DateTime(2022, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateCreated = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdCustomer = 1,
                            IdSTask = 2,
                            Status = 2
                        },
                        new
                        {
                            IdOrder = 2,
                            Cost = 800m,
                            DateCompleted = new DateTime(2022, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateCreated = new DateTime(2022, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdCustomer = 1,
                            IdSTask = 3,
                            Status = 2
                        },
                        new
                        {
                            IdOrder = 3,
                            Cost = 200m,
                            DateCompleted = new DateTime(2022, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateCreated = new DateTime(2022, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdCustomer = 2,
                            IdSTask = 1,
                            Status = 1
                        },
                        new
                        {
                            IdOrder = 4,
                            Cost = 1000m,
                            DateCompleted = new DateTime(2022, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateCreated = new DateTime(2022, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdCustomer = 2,
                            IdSTask = 3,
                            Status = 1
                        },
                        new
                        {
                            IdOrder = 5,
                            Cost = 300m,
                            DateCompleted = new DateTime(2022, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateCreated = new DateTime(2022, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdCustomer = 3,
                            IdSTask = 2,
                            Status = 1
                        },
                        new
                        {
                            IdOrder = 6,
                            Cost = 150m,
                            DateCompleted = new DateTime(2022, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateCreated = new DateTime(2022, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdCustomer = 3,
                            IdSTask = 1,
                            Status = 1
                        });
                });

            modelBuilder.Entity("Entities.Models.Part", b =>
                {
                    b.Property<int>("IdPart")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdPart"));

                    b.Property<decimal>("Cost")
                        .HasColumnType("numeric");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdPart");

                    b.ToTable("Parts");

                    b.HasData(
                        new
                        {
                            IdPart = 1,
                            Cost = 50m,
                            Name = "Brake pads"
                        },
                        new
                        {
                            IdPart = 2,
                            Cost = 10m,
                            Name = "Oil filter"
                        },
                        new
                        {
                            IdPart = 3,
                            Cost = 20m,
                            Name = "Spark plugs"
                        },
                        new
                        {
                            IdPart = 4,
                            Cost = 15m,
                            Name = "Air filter"
                        },
                        new
                        {
                            IdPart = 5,
                            Cost = 150m,
                            Name = "Alternator"
                        },
                        new
                        {
                            IdPart = 6,
                            Cost = 80m,
                            Name = "Battery"
                        },
                        new
                        {
                            IdPart = 7,
                            Cost = 100m,
                            Name = "Radiator"
                        },
                        new
                        {
                            IdPart = 8,
                            Cost = 70m,
                            Name = "Water pump"
                        },
                        new
                        {
                            IdPart = 9,
                            Cost = 120m,
                            Name = "Starter motor"
                        },
                        new
                        {
                            IdPart = 10,
                            Cost = 90m,
                            Name = "Fuel pump"
                        });
                });

            modelBuilder.Entity("Entities.Models.Person", b =>
                {
                    b.Property<int>("IdPerson")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdPerson"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdPerson");

                    b.ToTable("People");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");
                });

            modelBuilder.Entity("Entities.Models.Service", b =>
                {
                    b.Property<int>("IdService")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdService"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdService");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            IdService = 1,
                            Address = "123 Main Street, Anytown USA",
                            Name = "Car Service Center",
                            PhoneNumber = "123-456-7890"
                        },
                        new
                        {
                            IdService = 2,
                            Address = "456 Park Avenue, Anytown USA",
                            Name = "Auto Repair Shop",
                            PhoneNumber = "555-123-4567"
                        },
                        new
                        {
                            IdService = 3,
                            Address = "789 Elm Street, Anytown USA",
                            Name = "Mechanic Shop",
                            PhoneNumber = "999-888-7777"
                        });
                });

            modelBuilder.Entity("Entities.Models.STask", b =>
                {
                    b.Property<int>("IdSTask")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdSTask"));

                    b.Property<decimal>("Cost")
                        .HasColumnType("numeric");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("IdCar")
                        .HasColumnType("integer");

                    b.Property<int>("IdOrder")
                        .HasColumnType("integer");

                    b.HasKey("IdSTask");

                    b.HasIndex("IdCar");

                    b.HasIndex("IdOrder")
                        .IsUnique();

                    b.ToTable("STasks");

                    b.HasDiscriminator<string>("Discriminator").HasValue("STask");
                });

            modelBuilder.Entity("Entities.Models.CarRepair", b =>
                {
                    b.HasBaseType("Entities.Models.STask");

                    b.HasDiscriminator().HasValue("CarRepair");

                    b.HasData(
                        new
                        {
                            IdSTask = 1,
                            Cost = 150.00m,
                            IdCar = 1,
                            IdOrder = 1
                        },
                        new
                        {
                            IdSTask = 2,
                            Cost = 450.00m,
                            IdCar = 2,
                            IdOrder = 2
                        },
                        new
                        {
                            IdSTask = 3,
                            Cost = 2500.00m,
                            IdCar = 3,
                            IdOrder = 3
                        },
                        new
                        {
                            IdSTask = 4,
                            Cost = 50.00m,
                            IdCar = 4,
                            IdOrder = 4
                        });
                });

            modelBuilder.Entity("Entities.Models.CarSale", b =>
                {
                    b.HasBaseType("Entities.Models.STask");

                    b.Property<int>("ManufacturerWarranty")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasDiscriminator().HasValue("CarSale");

                    b.HasData(
                        new
                        {
                            IdSTask = 5,
                            Cost = 20000.00m,
                            IdCar = 1,
                            IdOrder = 5,
                            ManufacturerWarranty = 24,
                            Price = 22000.00m
                        },
                        new
                        {
                            IdSTask = 6,
                            Cost = 35000.00m,
                            IdCar = 2,
                            IdOrder = 6,
                            ManufacturerWarranty = 36,
                            Price = 38000.00m
                        });
                });

            modelBuilder.Entity("Entities.Models.Customer", b =>
                {
                    b.HasBaseType("Entities.Models.Person");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("Customer");

                    b.HasData(
                        new
                        {
                            IdPerson = 1,
                            BirthDate = new DateTime(1985, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "John",
                            Surname = "Smith",
                            Address = "123 Main Street, Anytown USA",
                            Email = "john.smith@example.com",
                            ZipCode = "12345"
                        },
                        new
                        {
                            IdPerson = 2,
                            BirthDate = new DateTime(1990, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Sarah",
                            Surname = "Johnson",
                            Address = "456 Park Avenue, Anytown USA",
                            Email = "sarah.johnson@example.com",
                            ZipCode = "67890"
                        },
                        new
                        {
                            IdPerson = 3,
                            BirthDate = new DateTime(1982, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Tom",
                            Surname = "Wilson",
                            Address = "789 Elm Street, Anytown USA",
                            Email = "tom.wilson@example.com",
                            ZipCode = "54321"
                        });
                });

            modelBuilder.Entity("Entities.Models.Employee", b =>
                {
                    b.HasBaseType("Entities.Models.Person");

                    b.Property<DateTime>("EmploymentDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("IdService")
                        .HasColumnType("integer");

                    b.Property<decimal>("MonthlySalary")
                        .HasColumnType("numeric");

                    b.HasIndex("IdService");

                    b.HasDiscriminator().HasValue("Employee");
                });

            modelBuilder.Entity("Entities.Models.CSRepresentative", b =>
                {
                    b.HasBaseType("Entities.Models.Employee");

                    b.Property<int>("ProcessedCallsCount")
                        .HasColumnType("integer");

                    b.HasDiscriminator().HasValue("CSRepresentative");
                });

            modelBuilder.Entity("Entities.Models.Mechanic", b =>
                {
                    b.HasBaseType("Entities.Models.Employee");

                    b.Property<int>("RepairedCarsCount")
                        .HasColumnType("integer");

                    b.HasDiscriminator().HasValue("Mechanic");

                    b.HasData(
                        new
                        {
                            IdPerson = 4,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Adam",
                            Surname = "Nowak",
                            EmploymentDate = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdService = 1,
                            MonthlySalary = 3000m,
                            RepairedCarsCount = 10
                        },
                        new
                        {
                            IdPerson = 5,
                            BirthDate = new DateTime(1992, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Ewa",
                            Surname = "Kowalska",
                            EmploymentDate = new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdService = 1,
                            MonthlySalary = 3200m,
                            RepairedCarsCount = 12
                        },
                        new
                        {
                            IdPerson = 6,
                            BirthDate = new DateTime(1988, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Tomasz",
                            Surname = "Lis",
                            EmploymentDate = new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdService = 2,
                            MonthlySalary = 3500m,
                            RepairedCarsCount = 8
                        });
                });

            modelBuilder.Entity("Entities.Models.Call", b =>
                {
                    b.HasOne("Entities.Models.Customer", null)
                        .WithMany("Calls")
                        .HasForeignKey("CustomerIdPerson");

                    b.HasOne("Entities.Models.CSRepresentative", "CSRepresentative")
                        .WithMany("Calls")
                        .HasForeignKey("IdCSRepresentative")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Person", "Customer")
                        .WithMany()
                        .HasForeignKey("IdCustomer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CSRepresentative");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Entities.Models.Car", b =>
                {
                    b.HasOne("Entities.Models.Customer", null)
                        .WithMany("Cars")
                        .HasForeignKey("CustomerIdPerson");

                    b.HasOne("Entities.Models.Person", "Customer")
                        .WithMany()
                        .HasForeignKey("IdCustomer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Service", "Service")
                        .WithMany("Cars")
                        .HasForeignKey("IdService")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Entities.Models.CarRepairPart", b =>
                {
                    b.HasOne("Entities.Models.CarRepair", "CarRepair")
                        .WithMany("CarRepairParts")
                        .HasForeignKey("IdCarRepair")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Part", "Part")
                        .WithMany("CarRepairParts")
                        .HasForeignKey("IdPart")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarRepair");

                    b.Navigation("Part");
                });

            modelBuilder.Entity("Entities.Models.MechanicOrder", b =>
                {
                    b.HasOne("Entities.Models.Mechanic", "Mechanic")
                        .WithMany("MechanicOrders")
                        .HasForeignKey("IdMechanic")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Order", "Order")
                        .WithMany("MechanicOrders")
                        .HasForeignKey("IdOrder")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mechanic");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Entities.Models.MechanicSTask", b =>
                {
                    b.HasOne("Entities.Models.Mechanic", "Mechanic")
                        .WithMany("MechanicSTasks")
                        .HasForeignKey("IdMechanic")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.STask", "STask")
                        .WithMany("MechanicSTasks")
                        .HasForeignKey("IdSTask")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mechanic");

                    b.Navigation("STask");
                });

            modelBuilder.Entity("Entities.Models.Order", b =>
                {
                    b.HasOne("Entities.Models.Customer", null)
                        .WithMany("Orders")
                        .HasForeignKey("CustomerIdPerson");

                    b.HasOne("Entities.Models.Person", "Customer")
                        .WithMany()
                        .HasForeignKey("IdCustomer")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Entities.Models.STask", b =>
                {
                    b.HasOne("Entities.Models.Car", "Car")
                        .WithMany("STasks")
                        .HasForeignKey("IdCar")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Order", "Order")
                        .WithOne("STask")
                        .HasForeignKey("Entities.Models.STask", "IdOrder")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Entities.Models.Employee", b =>
                {
                    b.HasOne("Entities.Models.Service", "Service")
                        .WithMany("Employees")
                        .HasForeignKey("IdService")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Entities.Models.Car", b =>
                {
                    b.Navigation("STasks");
                });

            modelBuilder.Entity("Entities.Models.Order", b =>
                {
                    b.Navigation("MechanicOrders");

                    b.Navigation("STask")
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Models.Part", b =>
                {
                    b.Navigation("CarRepairParts");
                });

            modelBuilder.Entity("Entities.Models.Service", b =>
                {
                    b.Navigation("Cars");

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Entities.Models.STask", b =>
                {
                    b.Navigation("MechanicSTasks");
                });

            modelBuilder.Entity("Entities.Models.CarRepair", b =>
                {
                    b.Navigation("CarRepairParts");
                });

            modelBuilder.Entity("Entities.Models.Customer", b =>
                {
                    b.Navigation("Calls");

                    b.Navigation("Cars");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Entities.Models.CSRepresentative", b =>
                {
                    b.Navigation("Calls");
                });

            modelBuilder.Entity("Entities.Models.Mechanic", b =>
                {
                    b.Navigation("MechanicOrders");

                    b.Navigation("MechanicSTasks");
                });
#pragma warning restore 612, 618
        }
    }
}
