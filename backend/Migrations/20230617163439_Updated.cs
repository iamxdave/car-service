using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class Updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("0a93fc24-22d7-409c-828c-313ee036f58d"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("3234ec57-a066-4eaa-a855-68367d770107"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("341adbcc-f730-44c3-bfa8-db4ef79c7b88"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("35e50fdf-5695-429b-b772-f28ea6265f3d"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("39f1a638-e31e-4aee-b16c-099d7afd79a6"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("4b94905e-0181-401c-8e14-c1ce19c34247"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("9ede1d1e-7d83-4eef-89bf-9a8995609a26"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("c76c8fbb-c1d3-4af4-a609-4b1f2302ef42"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("dca0b583-8a40-4693-a3df-cb7da2c1ff50"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("e4df4b32-31bc-42cb-8cb5-d5bd8e261ca8"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("e7f2bea5-a943-4234-aa6d-06cf7fa48f40"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("fa756a6f-7547-4050-bc0d-61b1606c1889"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "IdPerson",
                keyValue: new Guid("1c8dbd81-0b99-4cca-8430-3cb65d6560b0"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "IdPerson",
                keyValue: new Guid("bd8553c1-81b9-4a6e-9302-97fd11b8d6c6"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "IdPerson",
                keyValue: new Guid("d7a8be52-893b-42e0-aefb-0e8d251ee7de"));

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "IdCar", "Brand", "Cost", "Description", "Discriminator", "IdWorkshop", "Model", "UserIdPerson", "Warranty" },
                values: new object[,]
                {
                    { new Guid("0580f1c6-0e68-4ecd-a5bd-7c5a96748725"), "Porsche", 250000, "The Porsche 911 is an iconic sports car that combines timeless design with exceptional performance. Its precise handling, powerful engine, and luxurious interior make it a dream car for enthusiasts.", "CarToBuy", 3, "911", null, 5 },
                    { new Guid("1d63d892-1867-4ba8-98a4-252e723615cd"), "BMW", 55000, "The BMW Swiftsport is a sporty car with refined style and a powerful engine. It offers dynamic driving and unmatched excitement behind the wheel, satisfying the needs of sports car enthusiasts.", "CarToBuy", 2, "Swiftsport", null, 5 },
                    { new Guid("2abacb67-c94b-433f-9a82-0dc071d5023e"), "Audi", 75000, "The Audi Horizon is an elegant sedan with modern technological solutions. Its refined interior and exceptional acoustics ensure a comfortable journey on any route.", "CarToBuy", 2, "Horizon", null, 5 },
                    { new Guid("3ddddc92-c323-413e-9732-c0c7e31d1ce3"), "Honda", 20000, "The Honda Civic is a reliable and fuel-efficient compact car. It combines a stylish design, spacious interior, and advanced features, making it a versatile option for various needs.", "CarToBuy", 1, "Civic", null, 5 },
                    { new Guid("417048fb-3337-40bb-a81c-551940a351b9"), "Opel", 50000, "The Opel Astra is a compact car known for its elegant style and high-quality craftsmanship. It offers advanced technologies, a comfortable interior, and a great driving experience on longer journeys.", "CarToBuy", 1, "Astra", null, 5 },
                    { new Guid("4fbc4616-35aa-4de8-829d-405ba2ce6e44"), "Ford", 30000, "The Ford Fiesta is a popular compact car known for its affordability and energetic performance. It offers a comfortable ride and is an excellent choice for city driving.", "CarToBuy", 1, "Fiesta", null, 5 },
                    { new Guid("6aca1fa5-d30c-4e61-9f4d-070d74ece0b3"), "Ferrari", 350000, "The Ferrari 488 GTB is a legendary Italian supercar that represents the pinnacle of automotive engineering. With its breathtaking speed, aerodynamic design, and luxurious features, it is a symbol of automotive excellence.", "CarToBuy", 3, "488 GTB", null, 5 },
                    { new Guid("6fb0ee70-9487-4705-836a-03c884bbd5e6"), "Tesla", 70000, "The Tesla Elektra is a luxury electric car with a futuristic design. It boasts an impressive range and advanced autonomous features, making it a perfect choice for tech enthusiasts.", "CarToBuy", 2, "Elektra", null, 5 },
                    { new Guid("9d405965-6c64-4c4b-ac9e-ca668bc3c7bf"), "Volkswagen", 40000, "The Volkswagen Golf is an iconic compact car known for its solid construction, precise handling, and high-quality materials. It offers a versatile package and a wide range of features.", "CarToBuy", 2, "Golf", null, 5 },
                    { new Guid("d18e37de-1452-408c-abb6-75695f3019cc"), "Toyota", 25000, "The Toyota Venture is a compact crossover that excels in urban conditions. Equipped with advanced safety systems and an economical engine, it is an ideal companion for daily commuting.", "CarToBuy", 3, "Venture", null, 5 },
                    { new Guid("e90e1701-6e1a-4360-8dbf-3890b2f674a8"), "Lamborghini", 300000, "The Lamborghini Huracan is a high-performance supercar that embodies speed, luxury, and style. With its powerful engine and eye-catching design, it delivers an exhilarating driving experience.", "CarToBuy", 3, "Huracan", null, 5 },
                    { new Guid("f815ae48-cf08-44f0-b1bd-35f61f1a3c6e"), "Mercedes", 90000, "The Mercedes Aventura is a luxurious SUV that combines elegance and comfort with impressive all-wheel drive capabilities. Its spacious interior and advanced safety systems make every journey a true pleasure.", "CarToBuy", 2, "Aventura", null, 5 }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "IdPerson", "BookedDates", "Discriminator", "IdWorkshop", "Name", "Surname" },
                values: new object[,]
                {
                    { new Guid("61dfba1f-46e9-4636-808e-8d594827a2af"), new List<DateTime> { new DateTime(2023, 6, 25, 0, 0, 0, 0, DateTimeKind.Local) }, "Mechanic", 1, "Ewa", "Kowalska" },
                    { new Guid("e302e450-f536-4d46-b6d8-c4230dc11615"), new List<DateTime>(), "Mechanic", 2, "Tomasz", "Lis" },
                    { new Guid("ed328242-5a1d-49bb-b552-d6e999af2fb3"), new List<DateTime> { new DateTime(2023, 6, 18, 0, 0, 0, 0, DateTimeKind.Local) }, "Mechanic", 1, "Adam", "Nowak" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("0580f1c6-0e68-4ecd-a5bd-7c5a96748725"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("1d63d892-1867-4ba8-98a4-252e723615cd"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("2abacb67-c94b-433f-9a82-0dc071d5023e"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("3ddddc92-c323-413e-9732-c0c7e31d1ce3"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("417048fb-3337-40bb-a81c-551940a351b9"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("4fbc4616-35aa-4de8-829d-405ba2ce6e44"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("6aca1fa5-d30c-4e61-9f4d-070d74ece0b3"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("6fb0ee70-9487-4705-836a-03c884bbd5e6"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("9d405965-6c64-4c4b-ac9e-ca668bc3c7bf"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("d18e37de-1452-408c-abb6-75695f3019cc"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("e90e1701-6e1a-4360-8dbf-3890b2f674a8"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("f815ae48-cf08-44f0-b1bd-35f61f1a3c6e"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "IdPerson",
                keyValue: new Guid("61dfba1f-46e9-4636-808e-8d594827a2af"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "IdPerson",
                keyValue: new Guid("e302e450-f536-4d46-b6d8-c4230dc11615"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "IdPerson",
                keyValue: new Guid("ed328242-5a1d-49bb-b552-d6e999af2fb3"));

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
        }
    }
}
