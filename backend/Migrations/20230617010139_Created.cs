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
                    Brand = table.Column<string>(type: "text", nullable: false),
                    Model = table.Column<string>(type: "text", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    UserIdPerson = table.Column<Guid>(type: "uuid", nullable: true),
                    Cost = table.Column<int>(type: "integer", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
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
                    TotalPartCost = table.Column<decimal>(type: "numeric", nullable: true),
                    SaleCost = table.Column<int>(type: "integer", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: true),
                    Warranty = table.Column<int>(type: "integer", nullable: true)
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
                    Cost = table.Column<decimal>(type: "numeric", nullable: false),
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
                columns: new[] { "IdCar", "Brand", "Cost", "Description", "Discriminator", "IdWorkshop", "Model", "UserIdPerson", "Warranty" },
                values: new object[,]
                {
                    { new Guid("0a93fc24-22d7-409c-828c-313ee036f58d"), "Audi", 75000, "The Audi Horizon is an elegant sedan with modern technological solutions. Its refined interior and exceptional acoustics ensure a comfortable journey on any route.", "CarToBuy", 2, "Horizon", null, 5 },
                    { new Guid("3234ec57-a066-4eaa-a855-68367d770107"), "Porsche", 250000, "The Porsche 911 is an iconic sports car that combines timeless design with exceptional performance. Its precise handling, powerful engine, and luxurious interior make it a dream car for enthusiasts.", "CarToBuy", 3, "911", null, 5 },
                    { new Guid("341adbcc-f730-44c3-bfa8-db4ef79c7b88"), "Toyota", 25000, "The Toyota Venture is a compact crossover that excels in urban conditions. Equipped with advanced safety systems and an economical engine, it is an ideal companion for daily commuting.", "CarToBuy", 3, "Venture", null, 5 },
                    { new Guid("35e50fdf-5695-429b-b772-f28ea6265f3d"), "Opel", 50000, "The Opel Astra is a compact car known for its elegant style and high-quality craftsmanship. It offers advanced technologies, a comfortable interior, and a great driving experience on longer journeys.", "CarToBuy", 1, "Astra", null, 5 },
                    { new Guid("39f1a638-e31e-4aee-b16c-099d7afd79a6"), "Volkswagen", 40000, "The Volkswagen Golf is an iconic compact car known for its solid construction, precise handling, and high-quality materials. It offers a versatile package and a wide range of features.", "CarToBuy", 2, "Golf", null, 5 },
                    { new Guid("4b94905e-0181-401c-8e14-c1ce19c34247"), "Ford", 30000, "The Ford Fiesta is a popular compact car known for its affordability and energetic performance. It offers a comfortable ride and is an excellent choice for city driving.", "CarToBuy", 1, "Fiesta", null, 5 },
                    { new Guid("9ede1d1e-7d83-4eef-89bf-9a8995609a26"), "Ferrari", 350000, "The Ferrari 488 GTB is a legendary Italian supercar that represents the pinnacle of automotive engineering. With its breathtaking speed, aerodynamic design, and luxurious features, it is a symbol of automotive excellence.", "CarToBuy", 3, "488 GTB", null, 5 },
                    { new Guid("c76c8fbb-c1d3-4af4-a609-4b1f2302ef42"), "Honda", 20000, "The Honda Civic is a reliable and fuel-efficient compact car. It combines a stylish design, spacious interior, and advanced features, making it a versatile option for various needs.", "CarToBuy", 1, "Civic", null, 5 },
                    { new Guid("dca0b583-8a40-4693-a3df-cb7da2c1ff50"), "Lamborghini", 300000, "The Lamborghini Huracan is a high-performance supercar that embodies speed, luxury, and style. With its powerful engine and eye-catching design, it delivers an exhilarating driving experience.", "CarToBuy", 3, "Huracan", null, 5 },
                    { new Guid("e4df4b32-31bc-42cb-8cb5-d5bd8e261ca8"), "Mercedes", 90000, "The Mercedes Aventura is a luxurious SUV that combines elegance and comfort with impressive all-wheel drive capabilities. Its spacious interior and advanced safety systems make every journey a true pleasure.", "CarToBuy", 2, "Aventura", null, 5 },
                    { new Guid("e7f2bea5-a943-4234-aa6d-06cf7fa48f40"), "BMW", 55000, "The BMW Swiftsport is a sporty car with refined style and a powerful engine. It offers dynamic driving and unmatched excitement behind the wheel, satisfying the needs of sports car enthusiasts.", "CarToBuy", 2, "Swiftsport", null, 5 },
                    { new Guid("fa756a6f-7547-4050-bc0d-61b1606c1889"), "Tesla", 70000, "The Tesla Elektra is a luxury electric car with a futuristic design. It boasts an impressive range and advanced autonomous features, making it a perfect choice for tech enthusiasts.", "CarToBuy", 2, "Elektra", null, 5 }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "IdPerson", "BookedDates", "Discriminator", "IdWorkshop", "Name", "Surname" },
                values: new object[,]
                {
                    { new Guid("1c8dbd81-0b99-4cca-8430-3cb65d6560b0"), new List<DateTime> { new DateTime(2023, 6, 25, 0, 0, 0, 0, DateTimeKind.Local) }, "Mechanic", 1, "Ewa", "Kowalska" },
                    { new Guid("bd8553c1-81b9-4a6e-9302-97fd11b8d6c6"), new List<DateTime> { new DateTime(2023, 6, 18, 0, 0, 0, 0, DateTimeKind.Local) }, "Mechanic", 1, "Adam", "Nowak" },
                    { new Guid("d7a8be52-893b-42e0-aefb-0e8d251ee7de"), new List<DateTime>(), "Mechanic", 2, "Tomasz", "Lis" }
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
