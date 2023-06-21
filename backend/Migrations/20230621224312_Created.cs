using System;
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
                name: "Reservation",
                columns: table => new
                {
                    MechanicIdPerson = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Start = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => new { x.MechanicIdPerson, x.Id });
                    table.ForeignKey(
                        name: "FK_Reservation_People_MechanicIdPerson",
                        column: x => x.MechanicIdPerson,
                        principalTable: "People",
                        principalColumn: "IdPerson",
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
                    DateStarted = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateCompleted = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Cost = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    UserIdPerson = table.Column<Guid>(type: "uuid", nullable: true),
                    Warranty = table.Column<int>(type: "integer", nullable: true),
                    TotalPartCost = table.Column<decimal>(type: "numeric", nullable: true)
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
                    { new Guid("25341c76-f260-4105-b71d-01caec95fee5"), "BMW", 55000, "The BMW Swiftsport is a sporty car with refined style and a powerful engine. It offers dynamic driving and unmatched excitement behind the wheel, satisfying the needs of sports car enthusiasts.", "CarToBuy", 2, "Swiftsport", null, 5 },
                    { new Guid("6130edd3-1142-4843-85d3-095f67beeb0a"), "Honda", 20000, "The Honda Civic is a reliable and fuel-efficient compact car. It combines a stylish design, spacious interior, and advanced features, making it a versatile option for various needs.", "CarToBuy", 1, "Civic", null, 5 },
                    { new Guid("65fa622f-b78d-49d2-b2bd-bd80ea192cd0"), "Ferrari", 350000, "The Ferrari 488 GTB is a legendary Italian supercar that represents the pinnacle of automotive engineering. With its breathtaking speed, aerodynamic design, and luxurious features, it is a symbol of automotive excellence.", "CarToBuy", 3, "488 GTB", null, 5 },
                    { new Guid("7cb8309c-fce3-4a76-b362-1c25f9fb6cff"), "Volkswagen", 40000, "The Volkswagen Golf is an iconic compact car known for its solid construction, precise handling, and high-quality materials. It offers a versatile package and a wide range of features.", "CarToBuy", 2, "Golf", null, 5 },
                    { new Guid("83dbe316-445c-4913-90bc-9c6cb478f591"), "Lamborghini", 300000, "The Lamborghini Huracan is a high-performance supercar that embodies speed, luxury, and style. With its powerful engine and eye-catching design, it delivers an exhilarating driving experience.", "CarToBuy", 3, "Huracan", null, 5 },
                    { new Guid("8ab6eca5-8c46-4559-84ca-a47148523abb"), "Porsche", 250000, "The Porsche 911 is an iconic sports car that combines timeless design with exceptional performance. Its precise handling, powerful engine, and luxurious interior make it a dream car for enthusiasts.", "CarToBuy", 3, "911", null, 5 },
                    { new Guid("98538a3c-6dd9-441e-a08c-3dd1c88c6c4e"), "Opel", 50000, "The Opel Astra is a compact car known for its elegant style and high-quality craftsmanship. It offers advanced technologies, a comfortable interior, and a great driving experience on longer journeys.", "CarToBuy", 1, "Astra", null, 5 },
                    { new Guid("a3ebd233-94bf-4514-8ece-d6f442b2fdb5"), "Ford", 30000, "The Ford Fiesta is a popular compact car known for its affordability and energetic performance. It offers a comfortable ride and is an excellent choice for city driving.", "CarToBuy", 1, "Fiesta", null, 5 },
                    { new Guid("a83522c1-1046-475c-b08a-48d0a9598952"), "Toyota", 25000, "The Toyota Venture is a compact crossover that excels in urban conditions. Equipped with advanced safety systems and an economical engine, it is an ideal companion for daily commuting.", "CarToBuy", 3, "Venture", null, 5 },
                    { new Guid("b922a309-a273-4c53-b539-32ad29f34205"), "Tesla", 70000, "The Tesla Elektra is a luxury electric car with a futuristic design. It boasts an impressive range and advanced autonomous features, making it a perfect choice for tech enthusiasts.", "CarToBuy", 2, "Elektra", null, 5 },
                    { new Guid("e81c480f-406d-458e-b799-25c670af10a5"), "Mercedes", 90000, "The Mercedes Aventura is a luxurious SUV that combines elegance and comfort with impressive all-wheel drive capabilities. Its spacious interior and advanced safety systems make every journey a true pleasure.", "CarToBuy", 2, "Aventura", null, 5 },
                    { new Guid("ef82d8fc-61b5-445a-94a7-7115dbd2dffb"), "Audi", 75000, "The Audi Horizon is an elegant sedan with modern technological solutions. Its refined interior and exceptional acoustics ensure a comfortable journey on any route.", "CarToBuy", 2, "Horizon", null, 5 }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "IdPerson", "Discriminator", "IdWorkshop", "Name", "Surname" },
                values: new object[,]
                {
                    { new Guid("5ff12a95-342b-4a7a-ad3d-a33fb47c1217"), "Mechanic", 2, "Anna", "Nowakowska" },
                    { new Guid("833044ae-aeef-48c9-ad98-4f447f87447c"), "Mechanic", 2, "Tomasz", "Lis" },
                    { new Guid("89f77eed-4e8a-4d57-ac76-1a360d87fbcd"), "Mechanic", 1, "Ewa", "Kowalska" },
                    { new Guid("93cca228-dc76-45d1-a6e5-f8677c54f47c"), "Mechanic", 1, "Jan", "Kowalski" },
                    { new Guid("aa2fed81-74c2-4aaf-a844-4f2138ea5eb3"), "Mechanic", 1, "Piotr", "Wójcik" },
                    { new Guid("abccbc6d-e118-4934-ac98-9b163ae4eb2e"), "Mechanic", 2, "Magdalena", "Kaczmarek" },
                    { new Guid("b426d208-512d-4110-a1fe-114cccbe4646"), "Mechanic", 1, "Adam", "Nowak" }
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
                name: "Reservation");

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
