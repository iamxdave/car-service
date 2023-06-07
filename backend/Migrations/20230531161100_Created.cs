using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class Created : Migration
    {
        /// <inheritdoc />
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
                    IdWorkshop = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.IdWorkshop);
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
                    Password = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    ZipCode = table.Column<string>(type: "text", nullable: true),
                    IdWorkshop = table.Column<int>(type: "integer", nullable: true),
                    EmploymentDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    MonthlySalary = table.Column<decimal>(type: "numeric", nullable: true),
                    ProcessedCallsCount = table.Column<int>(type: "integer", nullable: true),
                    BookedDates = table.Column<List<DateTime>>(type: "timestamp without time zone[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.IdPerson);
                    table.ForeignKey(
                        name: "FK_People_Services_IdWorkshop",
                        column: x => x.IdWorkshop,
                        principalTable: "Services",
                        principalColumn: "IdWorkshop",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Calls",
                columns: table => new
                {
                    IdCall = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdCustomer = table.Column<int>(type: "integer", nullable: false),
                    IdCustomerServiceRepresentative = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
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
                        name: "FK_Calls_People_IdCustomer",
                        column: x => x.IdCustomer,
                        principalTable: "People",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Calls_People_IdCustomerServiceRepresentative",
                        column: x => x.IdCustomerServiceRepresentative,
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
                    IdService = table.Column<int>(type: "integer", nullable: false),
                    Model = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    CustomerIdPerson = table.Column<int>(type: "integer", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    Cost = table.Column<int>(type: "integer", nullable: true),
                    Warranty = table.Column<int>(type: "integer", nullable: true),
                    IdCustomer = table.Column<int>(type: "integer", nullable: true)
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
                        principalColumn: "IdWorkshop",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assistances",
                columns: table => new
                {
                    IdAssistance = table.Column<int>(type: "integer", nullable: false)
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
                    table.PrimaryKey("PK_Assistances", x => x.IdAssistance);
                    table.ForeignKey(
                        name: "FK_Assistances_Cars_IdCar",
                        column: x => x.IdCar,
                        principalTable: "Cars",
                        principalColumn: "IdCar",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MechanicAssistance",
                columns: table => new
                {
                    IdMechanicSTask = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdMechanic = table.Column<int>(type: "integer", nullable: false),
                    IdAssistance = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MechanicAssistance", x => x.IdMechanicSTask);
                    table.ForeignKey(
                        name: "FK_MechanicAssistance_Assistances_IdAssistance",
                        column: x => x.IdAssistance,
                        principalTable: "Assistances",
                        principalColumn: "IdAssistance",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MechanicAssistance_People_IdMechanic",
                        column: x => x.IdMechanic,
                        principalTable: "People",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    IdOrder = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdCustomer = table.Column<int>(type: "integer", nullable: false),
                    IdAssistance = table.Column<int>(type: "integer", nullable: false),
                    IdMechanic = table.Column<int>(type: "integer", nullable: false),
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
                        name: "FK_Orders_Assistances_IdAssistance",
                        column: x => x.IdAssistance,
                        principalTable: "Assistances",
                        principalColumn: "IdAssistance",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_People_CustomerIdPerson",
                        column: x => x.CustomerIdPerson,
                        principalTable: "People",
                        principalColumn: "IdPerson");
                    table.ForeignKey(
                        name: "FK_Orders_People_IdCustomer",
                        column: x => x.IdCustomer,
                        principalTable: "People",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_People_IdMechanic",
                        column: x => x.IdMechanic,
                        principalTable: "People",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RepairParts",
                columns: table => new
                {
                    IdRepairPart = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdRepair = table.Column<int>(type: "integer", nullable: false),
                    IdPart = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairParts", x => x.IdRepairPart);
                    table.ForeignKey(
                        name: "FK_RepairParts_Assistances_IdRepair",
                        column: x => x.IdRepair,
                        principalTable: "Assistances",
                        principalColumn: "IdAssistance",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RepairParts_Parts_IdPart",
                        column: x => x.IdPart,
                        principalTable: "Parts",
                        principalColumn: "IdPart",
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
                table: "Services",
                columns: new[] { "IdWorkshop", "Address", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "123 Main Street, Anytown USA", "Car Service Center", "123-456-7890" },
                    { 2, "456 Park Avenue, Anytown USA", "Auto Repair Shop", "555-123-4567" },
                    { 3, "789 Elm Street, Anytown USA", "Mechanic Shop", "999-888-7777" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "IdCar", "Cost", "CustomerIdPerson", "Discriminator", "IdService", "Model", "Type", "Warranty" },
                values: new object[,]
                {
                    { 1, 50000, null, "CarForSale", 1, "Astra", 0, 3 },
                    { 2, 40000, null, "CarForSale", 2, "Golf", 1, 4 },
                    { 3, 20000, null, "CarForSale", 3, "Civic", 0, 2 },
                    { 4, 30000, null, "CarForSale", 3, "Fiesta", 1, 5 }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "IdPerson", "BirthDate", "BookedDates", "Discriminator", "EmploymentDate", "IdWorkshop", "MonthlySalary", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new List<DateTime>(), "Mechanic", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3000m, "Adam", "Nowak" },
                    { 2, new DateTime(1992, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new List<DateTime>(), "Mechanic", new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3200m, "Ewa", "Kowalska" },
                    { 3, new DateTime(1988, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new List<DateTime>(), "Mechanic", new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3500m, "Tomasz", "Lis" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assistances_IdCar",
                table: "Assistances",
                column: "IdCar");

            migrationBuilder.CreateIndex(
                name: "IX_Calls_CustomerIdPerson",
                table: "Calls",
                column: "CustomerIdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_Calls_IdCustomer",
                table: "Calls",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Calls_IdCustomerServiceRepresentative",
                table: "Calls",
                column: "IdCustomerServiceRepresentative");

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
                name: "IX_MechanicAssistance_IdAssistance",
                table: "MechanicAssistance",
                column: "IdAssistance");

            migrationBuilder.CreateIndex(
                name: "IX_MechanicAssistance_IdMechanic",
                table: "MechanicAssistance",
                column: "IdMechanic");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerIdPerson",
                table: "Orders",
                column: "CustomerIdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IdAssistance",
                table: "Orders",
                column: "IdAssistance");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IdCustomer",
                table: "Orders",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IdMechanic",
                table: "Orders",
                column: "IdMechanic");

            migrationBuilder.CreateIndex(
                name: "IX_People_Email",
                table: "People",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_IdWorkshop",
                table: "People",
                column: "IdWorkshop");

            migrationBuilder.CreateIndex(
                name: "IX_RepairParts_IdPart",
                table: "RepairParts",
                column: "IdPart");

            migrationBuilder.CreateIndex(
                name: "IX_RepairParts_IdRepair",
                table: "RepairParts",
                column: "IdRepair");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calls");

            migrationBuilder.DropTable(
                name: "MechanicAssistance");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "RepairParts");

            migrationBuilder.DropTable(
                name: "Assistances");

            migrationBuilder.DropTable(
                name: "Parts");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Services");
        }
    }
}
