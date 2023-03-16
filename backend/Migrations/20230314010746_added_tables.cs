using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace backend.Migrations
{
    public partial class added_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    IdPart = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Cost = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.IdPart);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    IdService = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.IdService);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    IdPerson = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    ZipCode = table.Column<string>(type: "text", nullable: true),
                    IdService = table.Column<int>(type: "integer", nullable: true),
                    EmploymentDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    MonthlySalary = table.Column<decimal>(type: "numeric", nullable: true),
                    ProcessedCallsCount = table.Column<int>(type: "integer", nullable: true),
                    RepairedCarsCount = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.IdPerson);
                    table.ForeignKey(
                        name: "FK_People_Services_IdService",
                        column: x => x.IdService,
                        principalTable: "Services",
                        principalColumn: "IdService",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Calls",
                columns: table => new
                {
                    IdCall = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdCustomer = table.Column<int>(type: "integer", nullable: false),
                    IdCSRepresentative = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CustomerIdPerson = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calls", x => x.IdCall);
                    table.ForeignKey(
                        name: "FK_Calls_People_CustomerIdPerson",
                        column: x => x.CustomerIdPerson,
                        principalTable: "People",
                        principalColumn: "IdPerson");
                    table.ForeignKey(
                        name: "FK_Calls_People_IdCSRepresentative",
                        column: x => x.IdCSRepresentative,
                        principalTable: "People",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Calls_People_IdCustomer",
                        column: x => x.IdCustomer,
                        principalTable: "People",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    IdCar = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdCustomer = table.Column<int>(type: "integer", nullable: false),
                    IdService = table.Column<int>(type: "integer", nullable: false),
                    Model = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    CustomerIdPerson = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.IdCar);
                    table.ForeignKey(
                        name: "FK_Cars_People_CustomerIdPerson",
                        column: x => x.CustomerIdPerson,
                        principalTable: "People",
                        principalColumn: "IdPerson");
                    table.ForeignKey(
                        name: "FK_Cars_People_IdCustomer",
                        column: x => x.IdCustomer,
                        principalTable: "People",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Services_IdService",
                        column: x => x.IdService,
                        principalTable: "Services",
                        principalColumn: "IdService",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    IdOrder = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdCustomer = table.Column<int>(type: "integer", nullable: false),
                    IdSTask = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateCompleted = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Cost = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CustomerIdPerson = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.IdOrder);
                    table.ForeignKey(
                        name: "FK_Orders_People_CustomerIdPerson",
                        column: x => x.CustomerIdPerson,
                        principalTable: "People",
                        principalColumn: "IdPerson");
                    table.ForeignKey(
                        name: "FK_Orders_People_IdCustomer",
                        column: x => x.IdCustomer,
                        principalTable: "People",
                        principalColumn: "IdPerson");
                });

            migrationBuilder.CreateTable(
                name: "MechanicOrders",
                columns: table => new
                {
                    IdMechanicOrder = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdMechanic = table.Column<int>(type: "integer", nullable: false),
                    IdOrder = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MechanicOrders", x => x.IdMechanicOrder);
                    table.ForeignKey(
                        name: "FK_MechanicOrders_Orders_IdOrder",
                        column: x => x.IdOrder,
                        principalTable: "Orders",
                        principalColumn: "IdOrder",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MechanicOrders_People_IdMechanic",
                        column: x => x.IdMechanic,
                        principalTable: "People",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "STasks",
                columns: table => new
                {
                    IdSTask = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdCar = table.Column<int>(type: "integer", nullable: false),
                    IdOrder = table.Column<int>(type: "integer", nullable: false),
                    Cost = table.Column<decimal>(type: "numeric", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    ManufacturerWarranty = table.Column<int>(type: "integer", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STasks", x => x.IdSTask);
                    table.ForeignKey(
                        name: "FK_STasks_Cars_IdCar",
                        column: x => x.IdCar,
                        principalTable: "Cars",
                        principalColumn: "IdCar",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_STasks_Orders_IdOrder",
                        column: x => x.IdOrder,
                        principalTable: "Orders",
                        principalColumn: "IdOrder");
                });

            migrationBuilder.CreateTable(
                name: "CarRepairParts",
                columns: table => new
                {
                    IdCarRepairPart = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdCarRepair = table.Column<int>(type: "integer", nullable: false),
                    IdPart = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarRepairParts", x => x.IdCarRepairPart);
                    table.ForeignKey(
                        name: "FK_CarRepairParts_Parts_IdPart",
                        column: x => x.IdPart,
                        principalTable: "Parts",
                        principalColumn: "IdPart",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarRepairParts_STasks_IdCarRepair",
                        column: x => x.IdCarRepair,
                        principalTable: "STasks",
                        principalColumn: "IdSTask",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MechanicSTasks",
                columns: table => new
                {
                    IdMechanicSTask = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdMechanic = table.Column<int>(type: "integer", nullable: false),
                    IdSTask = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MechanicSTasks", x => x.IdMechanicSTask);
                    table.ForeignKey(
                        name: "FK_MechanicSTasks_People_IdMechanic",
                        column: x => x.IdMechanic,
                        principalTable: "People",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MechanicSTasks_STasks_IdSTask",
                        column: x => x.IdSTask,
                        principalTable: "STasks",
                        principalColumn: "IdSTask",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "IdPart", "Cost", "Name" },
                values: new object[,]
                {
                    { 1, 50m, "Brake pads" },
                    { 2, 10m, "Oil filter" },
                    { 3, 20m, "Spark plugs" },
                    { 4, 15m, "Air filter" },
                    { 5, 150m, "Alternator" },
                    { 6, 80m, "Battery" },
                    { 7, 100m, "Radiator" },
                    { 8, 70m, "Water pump" },
                    { 9, 120m, "Starter motor" },
                    { 10, 90m, "Fuel pump" }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "IdPerson", "Address", "BirthDate", "Discriminator", "Email", "Name", "Surname", "ZipCode" },
                values: new object[,]
                {
                    { 1, "123 Main Street, Anytown USA", new DateTime(1985, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Customer", "john.smith@example.com", "John", "Smith", "12345" },
                    { 2, "456 Park Avenue, Anytown USA", new DateTime(1990, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Customer", "sarah.johnson@example.com", "Sarah", "Johnson", "67890" },
                    { 3, "789 Elm Street, Anytown USA", new DateTime(1982, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Customer", "tom.wilson@example.com", "Tom", "Wilson", "54321" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "IdService", "Address", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "123 Main Street, Anytown USA", "Car Service Center", "123-456-7890" },
                    { 2, "456 Park Avenue, Anytown USA", "Auto Repair Shop", "555-123-4567" },
                    { 3, "789 Elm Street, Anytown USA", "Mechanic Shop", "999-888-7777" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "IdCar", "CustomerIdPerson", "IdCustomer", "IdService", "Model", "Type" },
                values: new object[,]
                {
                    { 1, null, 1, 1, "Astra", 0 },
                    { 2, null, 2, 2, "Golf", 1 },
                    { 3, null, 3, 3, "Civic", 0 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "IdOrder", "Cost", "CustomerIdPerson", "DateCompleted", "DateCreated", "IdCustomer", "IdSTask", "Status" },
                values: new object[,]
                {
                    { 1, 500m, null, new DateTime(2022, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 2 },
                    { 2, 800m, null, new DateTime(2022, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 2 },
                    { 3, 200m, null, new DateTime(2022, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 1 },
                    { 4, 1000m, null, new DateTime(2022, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, 1 },
                    { 5, 300m, null, new DateTime(2022, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 1 },
                    { 6, 150m, null, new DateTime(2022, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "IdPerson", "BirthDate", "Discriminator", "EmploymentDate", "IdService", "MonthlySalary", "Name", "RepairedCarsCount", "Surname" },
                values: new object[,]
                {
                    { 4, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mechanic", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3000m, "Adam", 10, "Nowak" },
                    { 5, new DateTime(1992, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mechanic", new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3200m, "Ewa", 12, "Kowalska" },
                    { 6, new DateTime(1988, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mechanic", new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3500m, "Tomasz", 8, "Lis" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "IdCar", "CustomerIdPerson", "IdCustomer", "IdService", "Model", "Type" },
                values: new object[] { 4, null, 4, 3, "Fiesta", 1 });

            migrationBuilder.InsertData(
                table: "MechanicOrders",
                columns: new[] { "IdMechanicOrder", "IdMechanic", "IdOrder" },
                values: new object[,]
                {
                    { 1, 4, 1 },
                    { 2, 4, 2 },
                    { 3, 5, 3 },
                    { 4, 5, 4 },
                    { 5, 5, 5 },
                    { 6, 6, 6 }
                });

            migrationBuilder.InsertData(
                table: "STasks",
                columns: new[] { "IdSTask", "Cost", "Discriminator", "IdCar", "IdOrder" },
                values: new object[,]
                {
                    { 1, 150.00m, "CarRepair", 1, 1 },
                    { 2, 450.00m, "CarRepair", 2, 2 },
                    { 3, 2500.00m, "CarRepair", 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "STasks",
                columns: new[] { "IdSTask", "Cost", "Discriminator", "IdCar", "IdOrder", "ManufacturerWarranty", "Price" },
                values: new object[,]
                {
                    { 5, 20000.00m, "CarSale", 1, 5, 24, 22000.00m },
                    { 6, 35000.00m, "CarSale", 2, 6, 36, 38000.00m }
                });

            migrationBuilder.InsertData(
                table: "CarRepairParts",
                columns: new[] { "IdCarRepairPart", "IdCarRepair", "IdPart" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 1, 3 },
                    { 4, 2, 4 },
                    { 5, 2, 5 },
                    { 6, 2, 6 },
                    { 7, 3, 7 },
                    { 8, 3, 8 }
                });

            migrationBuilder.InsertData(
                table: "MechanicSTasks",
                columns: new[] { "IdMechanicSTask", "IdMechanic", "IdSTask" },
                values: new object[,]
                {
                    { 1, 4, 1 },
                    { 2, 4, 2 },
                    { 3, 5, 3 },
                    { 4, 6, 2 }
                });

            migrationBuilder.InsertData(
                table: "STasks",
                columns: new[] { "IdSTask", "Cost", "Discriminator", "IdCar", "IdOrder" },
                values: new object[] { 4, 50.00m, "CarRepair", 4, 4 });

            migrationBuilder.InsertData(
                table: "CarRepairParts",
                columns: new[] { "IdCarRepairPart", "IdCarRepair", "IdPart" },
                values: new object[,]
                {
                    { 9, 4, 9 },
                    { 10, 4, 10 }
                });

            migrationBuilder.InsertData(
                table: "MechanicSTasks",
                columns: new[] { "IdMechanicSTask", "IdMechanic", "IdSTask" },
                values: new object[] { 5, 6, 4 });

            migrationBuilder.CreateIndex(
                name: "IX_Calls_CustomerIdPerson",
                table: "Calls",
                column: "CustomerIdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_Calls_IdCSRepresentative",
                table: "Calls",
                column: "IdCSRepresentative");

            migrationBuilder.CreateIndex(
                name: "IX_Calls_IdCustomer",
                table: "Calls",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_CarRepairParts_IdCarRepair",
                table: "CarRepairParts",
                column: "IdCarRepair");

            migrationBuilder.CreateIndex(
                name: "IX_CarRepairParts_IdPart",
                table: "CarRepairParts",
                column: "IdPart");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CustomerIdPerson",
                table: "Cars",
                column: "CustomerIdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_IdCustomer",
                table: "Cars",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_IdService",
                table: "Cars",
                column: "IdService");

            migrationBuilder.CreateIndex(
                name: "IX_MechanicOrders_IdMechanic",
                table: "MechanicOrders",
                column: "IdMechanic");

            migrationBuilder.CreateIndex(
                name: "IX_MechanicOrders_IdOrder",
                table: "MechanicOrders",
                column: "IdOrder");

            migrationBuilder.CreateIndex(
                name: "IX_MechanicSTasks_IdMechanic",
                table: "MechanicSTasks",
                column: "IdMechanic");

            migrationBuilder.CreateIndex(
                name: "IX_MechanicSTasks_IdSTask",
                table: "MechanicSTasks",
                column: "IdSTask");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerIdPerson",
                table: "Orders",
                column: "CustomerIdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IdCustomer",
                table: "Orders",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_People_IdService",
                table: "People",
                column: "IdService");

            migrationBuilder.CreateIndex(
                name: "IX_STasks_IdCar",
                table: "STasks",
                column: "IdCar");

            migrationBuilder.CreateIndex(
                name: "IX_STasks_IdOrder",
                table: "STasks",
                column: "IdOrder",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calls");

            migrationBuilder.DropTable(
                name: "CarRepairParts");

            migrationBuilder.DropTable(
                name: "MechanicOrders");

            migrationBuilder.DropTable(
                name: "MechanicSTasks");

            migrationBuilder.DropTable(
                name: "Parts");

            migrationBuilder.DropTable(
                name: "STasks");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Services");
        }
    }
}
