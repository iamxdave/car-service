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
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.IdPart);
                });

            migrationBuilder.CreateTable(
                name: "Workshops",
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
                    table.PrimaryKey("PK_Workshops", x => x.IdWorkshop);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    IdPerson = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    BookedDates = table.Column<List<DateTime>>(type: "timestamp without time zone[]", nullable: true),
                    IdWorkshop = table.Column<int>(type: "integer", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.IdPerson);
                    table.ForeignKey(
                        name: "FK_People_Workshops_IdWorkshop",
                        column: x => x.IdWorkshop,
                        principalTable: "Workshops",
                        principalColumn: "IdWorkshop",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    IdCar = table.Column<Guid>(type: "uuid", nullable: false),
                    IdWorkshop = table.Column<int>(type: "integer", nullable: false),
                    Model = table.Column<string>(type: "text", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    UserIdPerson = table.Column<Guid>(type: "uuid", nullable: true),
                    Cost = table.Column<int>(type: "integer", nullable: true),
                    Warranty = table.Column<int>(type: "integer", nullable: true),
                    RegistrationNumber = table.Column<string>(type: "text", nullable: true),
                    IdUser = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.IdCar);
                    table.ForeignKey(
                        name: "FK_Cars_People_IdUser",
                        column: x => x.IdUser,
                        principalTable: "People",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_People_UserIdPerson",
                        column: x => x.UserIdPerson,
                        principalTable: "People",
                        principalColumn: "IdPerson");
                    table.ForeignKey(
                        name: "FK_Cars_Workshops_IdWorkshop",
                        column: x => x.IdWorkshop,
                        principalTable: "Workshops",
                        principalColumn: "IdWorkshop",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    IdOrder = table.Column<Guid>(type: "uuid", nullable: false),
                    IdUser = table.Column<Guid>(type: "uuid", nullable: false),
                    IdMechanic = table.Column<Guid>(type: "uuid", nullable: false),
                    IdCar = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateCompleted = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Cost = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    UserIdPerson = table.Column<Guid>(type: "uuid", nullable: true),
                    TotalPartCost = table.Column<int>(type: "integer", nullable: true),
                    ManufacturerWarranty = table.Column<int>(type: "integer", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.IdOrder);
                    table.ForeignKey(
                        name: "FK_Orders_Cars_IdCar",
                        column: x => x.IdCar,
                        principalTable: "Cars",
                        principalColumn: "IdCar",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_People_IdMechanic",
                        column: x => x.IdMechanic,
                        principalTable: "People",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_People_IdUser",
                        column: x => x.IdUser,
                        principalTable: "People",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_People_UserIdPerson",
                        column: x => x.UserIdPerson,
                        principalTable: "People",
                        principalColumn: "IdPerson");
                });

            migrationBuilder.CreateTable(
                name: "RepairParts",
                columns: table => new
                {
                    IdRepairPart = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Quality = table.Column<int>(type: "integer", nullable: false),
                    Cost = table.Column<int>(type: "integer", nullable: false),
                    IdRepair = table.Column<Guid>(type: "uuid", nullable: false),
                    IdPart = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairParts", x => x.IdRepairPart);
                    table.ForeignKey(
                        name: "FK_RepairParts_Orders_IdRepair",
                        column: x => x.IdRepair,
                        principalTable: "Orders",
                        principalColumn: "IdOrder",
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
                columns: new[] { "IdPart", "Name" },
                values: new object[,]
                {
                    { 1, "Brake pads" },
                    { 2, "Oil filter" },
                    { 3, "Spark plugs" },
                    { 4, "Air filter" },
                    { 5, "Alternator" },
                    { 6, "Battery" },
                    { 7, "Radiator" },
                    { 8, "Water pump" },
                    { 9, "Starter motor" },
                    { 10, "Fuel pump" }
                });

            migrationBuilder.InsertData(
                table: "Workshops",
                columns: new[] { "IdWorkshop", "Address", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "123 Main Street, Anytown USA", "Car Service Center", "123-456-7890" },
                    { 2, "456 Park Avenue, Anytown USA", "Auto Repair Shop", "555-123-4567" },
                    { 3, "789 Elm Street, Anytown USA", "Mechanic Shop", "999-888-7777" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "IdCar", "Cost", "Discriminator", "IdWorkshop", "Model", "UserIdPerson", "Warranty" },
                values: new object[,]
                {
                    { new Guid("46864815-9044-4d68-a804-22d3f5723b6a"), 20000, "CarToBuy", 3, "Civic", null, 2 },
                    { new Guid("50d82207-0e80-4519-8062-9e50074b60ea"), 50000, "CarToBuy", 1, "Astra", null, 3 },
                    { new Guid("6bf62f70-3763-4008-bc42-f0befea85450"), 30000, "CarToBuy", 3, "Fiesta", null, 5 },
                    { new Guid("c08a51ba-d473-4041-9a04-b325a872226c"), 40000, "CarToBuy", 2, "Golf", null, 4 }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "IdPerson", "BirthDate", "BookedDates", "Discriminator", "IdWorkshop", "Name", "Surname" },
                values: new object[,]
                {
                    { new Guid("727f407e-e64e-4287-b5c5-16f7b837a4ab"), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new List<DateTime>(), "Mechanic", 1, "Adam", "Nowak" },
                    { new Guid("8973b72d-2375-4d4a-a0eb-883324b97686"), new DateTime(1992, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new List<DateTime>(), "Mechanic", 1, "Ewa", "Kowalska" },
                    { new Guid("a25bed7f-59d5-44e5-bb24-e6ea30cdaf8c"), new DateTime(1988, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new List<DateTime>(), "Mechanic", 2, "Tomasz", "Lis" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_IdUser",
                table: "Cars",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_IdWorkshop",
                table: "Cars",
                column: "IdWorkshop");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_UserIdPerson",
                table: "Cars",
                column: "UserIdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IdCar",
                table: "Orders",
                column: "IdCar");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IdMechanic",
                table: "Orders",
                column: "IdMechanic");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IdUser",
                table: "Orders",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserIdPerson",
                table: "Orders",
                column: "UserIdPerson");

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
                name: "RepairParts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Parts");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Workshops");
        }
    }
}
