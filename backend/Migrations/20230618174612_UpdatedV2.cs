using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Orders");

            migrationBuilder.AlterColumn<decimal>(
                name: "SaleCost",
                table: "Orders",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCompleted",
                table: "Orders",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "IdCar", "Brand", "Cost", "Description", "Discriminator", "IdWorkshop", "Model", "UserIdPerson", "Warranty" },
                values: new object[,]
                {
                    { new Guid("04ff24d5-5f73-4f3d-8d59-9060ce1bc71d"), "Volkswagen", 40000, "The Volkswagen Golf is an iconic compact car known for its solid construction, precise handling, and high-quality materials. It offers a versatile package and a wide range of features.", "CarToBuy", 2, "Golf", null, 5 },
                    { new Guid("16e805d8-369b-4f5b-b9bb-32235100f473"), "Porsche", 250000, "The Porsche 911 is an iconic sports car that combines timeless design with exceptional performance. Its precise handling, powerful engine, and luxurious interior make it a dream car for enthusiasts.", "CarToBuy", 3, "911", null, 5 },
                    { new Guid("1c87940e-33b7-43d8-9d21-d0495e5c69a3"), "Lamborghini", 300000, "The Lamborghini Huracan is a high-performance supercar that embodies speed, luxury, and style. With its powerful engine and eye-catching design, it delivers an exhilarating driving experience.", "CarToBuy", 3, "Huracan", null, 5 },
                    { new Guid("39b7a5c4-80c3-42fe-ad55-4e1147f0f0c9"), "Tesla", 70000, "The Tesla Elektra is a luxury electric car with a futuristic design. It boasts an impressive range and advanced autonomous features, making it a perfect choice for tech enthusiasts.", "CarToBuy", 2, "Elektra", null, 5 },
                    { new Guid("3d616b2d-7091-47d7-a09a-909ddcf4997b"), "BMW", 55000, "The BMW Swiftsport is a sporty car with refined style and a powerful engine. It offers dynamic driving and unmatched excitement behind the wheel, satisfying the needs of sports car enthusiasts.", "CarToBuy", 2, "Swiftsport", null, 5 },
                    { new Guid("7168fd34-b9b6-4b2a-b1c4-e8c5712c9a8f"), "Opel", 50000, "The Opel Astra is a compact car known for its elegant style and high-quality craftsmanship. It offers advanced technologies, a comfortable interior, and a great driving experience on longer journeys.", "CarToBuy", 1, "Astra", null, 5 },
                    { new Guid("7689c111-18f7-4d17-b06f-7e41aeed9b02"), "Toyota", 25000, "The Toyota Venture is a compact crossover that excels in urban conditions. Equipped with advanced safety systems and an economical engine, it is an ideal companion for daily commuting.", "CarToBuy", 3, "Venture", null, 5 },
                    { new Guid("941c92ee-348f-44bd-bb4d-bb2832d6f896"), "Mercedes", 90000, "The Mercedes Aventura is a luxurious SUV that combines elegance and comfort with impressive all-wheel drive capabilities. Its spacious interior and advanced safety systems make every journey a true pleasure.", "CarToBuy", 2, "Aventura", null, 5 },
                    { new Guid("a28b6244-0f41-4df2-b025-03831fd93121"), "Audi", 75000, "The Audi Horizon is an elegant sedan with modern technological solutions. Its refined interior and exceptional acoustics ensure a comfortable journey on any route.", "CarToBuy", 2, "Horizon", null, 5 },
                    { new Guid("b3de4850-5013-4ef7-9263-1d8580ea3af3"), "Ford", 30000, "The Ford Fiesta is a popular compact car known for its affordability and energetic performance. It offers a comfortable ride and is an excellent choice for city driving.", "CarToBuy", 1, "Fiesta", null, 5 },
                    { new Guid("ba68abad-a171-4e42-a56b-a941f50adb48"), "Honda", 20000, "The Honda Civic is a reliable and fuel-efficient compact car. It combines a stylish design, spacious interior, and advanced features, making it a versatile option for various needs.", "CarToBuy", 1, "Civic", null, 5 },
                    { new Guid("f0f46155-b4c7-4be1-9617-5eac3c1f5ac1"), "Ferrari", 350000, "The Ferrari 488 GTB is a legendary Italian supercar that represents the pinnacle of automotive engineering. With its breathtaking speed, aerodynamic design, and luxurious features, it is a symbol of automotive excellence.", "CarToBuy", 3, "488 GTB", null, 5 }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "IdPerson", "BookedDates", "Discriminator", "IdWorkshop", "Name", "Surname" },
                values: new object[,]
                {
                    { new Guid("1ac92ee0-61c6-40dd-874d-caec78eb9dde"), new List<DateTime>(), "Mechanic", 2, "Tomasz", "Lis" },
                    { new Guid("b943bdc7-1667-43c2-8b1a-1b6f2b56ec31"), new List<DateTime> { new DateTime(2023, 6, 19, 0, 0, 0, 0, DateTimeKind.Local) }, "Mechanic", 1, "Adam", "Nowak" },
                    { new Guid("dd84450e-2249-4325-8fbb-f2d064994322"), new List<DateTime> { new DateTime(2023, 6, 26, 0, 0, 0, 0, DateTimeKind.Local) }, "Mechanic", 1, "Ewa", "Kowalska" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("04ff24d5-5f73-4f3d-8d59-9060ce1bc71d"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("16e805d8-369b-4f5b-b9bb-32235100f473"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("1c87940e-33b7-43d8-9d21-d0495e5c69a3"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("39b7a5c4-80c3-42fe-ad55-4e1147f0f0c9"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("3d616b2d-7091-47d7-a09a-909ddcf4997b"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("7168fd34-b9b6-4b2a-b1c4-e8c5712c9a8f"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("7689c111-18f7-4d17-b06f-7e41aeed9b02"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("941c92ee-348f-44bd-bb4d-bb2832d6f896"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("a28b6244-0f41-4df2-b025-03831fd93121"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("b3de4850-5013-4ef7-9263-1d8580ea3af3"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("ba68abad-a171-4e42-a56b-a941f50adb48"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("f0f46155-b4c7-4be1-9617-5eac3c1f5ac1"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "IdPerson",
                keyValue: new Guid("1ac92ee0-61c6-40dd-874d-caec78eb9dde"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "IdPerson",
                keyValue: new Guid("b943bdc7-1667-43c2-8b1a-1b6f2b56ec31"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "IdPerson",
                keyValue: new Guid("dd84450e-2249-4325-8fbb-f2d064994322"));

            migrationBuilder.AlterColumn<int>(
                name: "SaleCost",
                table: "Orders",
                type: "integer",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCompleted",
                table: "Orders",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Orders",
                type: "numeric",
                nullable: true);

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
    }
}
