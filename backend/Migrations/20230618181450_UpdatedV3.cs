using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "SaleCost",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "IdCar", "Brand", "Cost", "Description", "Discriminator", "IdWorkshop", "Model", "UserIdPerson", "Warranty" },
                values: new object[,]
                {
                    { new Guid("251020c5-0eb4-4dcf-812c-36f9d02207c2"), "Tesla", 70000, "The Tesla Elektra is a luxury electric car with a futuristic design. It boasts an impressive range and advanced autonomous features, making it a perfect choice for tech enthusiasts.", "CarToBuy", 2, "Elektra", null, 5 },
                    { new Guid("42487c4e-8cf3-40d9-b73e-5b18fd891dcb"), "Ford", 30000, "The Ford Fiesta is a popular compact car known for its affordability and energetic performance. It offers a comfortable ride and is an excellent choice for city driving.", "CarToBuy", 1, "Fiesta", null, 5 },
                    { new Guid("55ce1e3d-252e-43e8-829a-6dd2a55ce52b"), "Lamborghini", 300000, "The Lamborghini Huracan is a high-performance supercar that embodies speed, luxury, and style. With its powerful engine and eye-catching design, it delivers an exhilarating driving experience.", "CarToBuy", 3, "Huracan", null, 5 },
                    { new Guid("623a34da-b372-4b1b-9324-59d376252964"), "BMW", 55000, "The BMW Swiftsport is a sporty car with refined style and a powerful engine. It offers dynamic driving and unmatched excitement behind the wheel, satisfying the needs of sports car enthusiasts.", "CarToBuy", 2, "Swiftsport", null, 5 },
                    { new Guid("65b84f60-cc8f-4465-a5c1-2de7ccd77554"), "Opel", 50000, "The Opel Astra is a compact car known for its elegant style and high-quality craftsmanship. It offers advanced technologies, a comfortable interior, and a great driving experience on longer journeys.", "CarToBuy", 1, "Astra", null, 5 },
                    { new Guid("963baaa1-1578-4665-a246-96e28c8d59fd"), "Toyota", 25000, "The Toyota Venture is a compact crossover that excels in urban conditions. Equipped with advanced safety systems and an economical engine, it is an ideal companion for daily commuting.", "CarToBuy", 3, "Venture", null, 5 },
                    { new Guid("9ed68e37-d66f-4c46-912e-fa8a070d6a6a"), "Ferrari", 350000, "The Ferrari 488 GTB is a legendary Italian supercar that represents the pinnacle of automotive engineering. With its breathtaking speed, aerodynamic design, and luxurious features, it is a symbol of automotive excellence.", "CarToBuy", 3, "488 GTB", null, 5 },
                    { new Guid("dc5f245c-fe86-49b2-98a7-0e27f323e19f"), "Audi", 75000, "The Audi Horizon is an elegant sedan with modern technological solutions. Its refined interior and exceptional acoustics ensure a comfortable journey on any route.", "CarToBuy", 2, "Horizon", null, 5 },
                    { new Guid("de2d4f71-8ad6-4f97-93f3-e6fa5555ab2f"), "Porsche", 250000, "The Porsche 911 is an iconic sports car that combines timeless design with exceptional performance. Its precise handling, powerful engine, and luxurious interior make it a dream car for enthusiasts.", "CarToBuy", 3, "911", null, 5 },
                    { new Guid("e281f618-8558-4869-b402-c155da5efb1e"), "Volkswagen", 40000, "The Volkswagen Golf is an iconic compact car known for its solid construction, precise handling, and high-quality materials. It offers a versatile package and a wide range of features.", "CarToBuy", 2, "Golf", null, 5 },
                    { new Guid("e8ae6ada-c1f9-407d-b8b0-2eba477ac092"), "Mercedes", 90000, "The Mercedes Aventura is a luxurious SUV that combines elegance and comfort with impressive all-wheel drive capabilities. Its spacious interior and advanced safety systems make every journey a true pleasure.", "CarToBuy", 2, "Aventura", null, 5 },
                    { new Guid("ed259129-03cf-4f56-81ce-04785793d546"), "Honda", 20000, "The Honda Civic is a reliable and fuel-efficient compact car. It combines a stylish design, spacious interior, and advanced features, making it a versatile option for various needs.", "CarToBuy", 1, "Civic", null, 5 }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "IdPerson", "BookedDates", "Discriminator", "IdWorkshop", "Name", "Surname" },
                values: new object[,]
                {
                    { new Guid("2276ac38-0b83-424e-bdd6-e84d3fc28b93"), new List<DateTime> { new DateTime(2023, 6, 26, 0, 0, 0, 0, DateTimeKind.Local) }, "Mechanic", 1, "Ewa", "Kowalska" },
                    { new Guid("4c324fa8-088d-4c73-8b2d-587eb8ccf8dd"), new List<DateTime>(), "Mechanic", 2, "Tomasz", "Lis" },
                    { new Guid("b867fb67-44ba-4a62-a828-c493bb87ea3e"), new List<DateTime> { new DateTime(2023, 6, 19, 0, 0, 0, 0, DateTimeKind.Local) }, "Mechanic", 1, "Adam", "Nowak" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("251020c5-0eb4-4dcf-812c-36f9d02207c2"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("42487c4e-8cf3-40d9-b73e-5b18fd891dcb"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("55ce1e3d-252e-43e8-829a-6dd2a55ce52b"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("623a34da-b372-4b1b-9324-59d376252964"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("65b84f60-cc8f-4465-a5c1-2de7ccd77554"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("963baaa1-1578-4665-a246-96e28c8d59fd"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("9ed68e37-d66f-4c46-912e-fa8a070d6a6a"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("dc5f245c-fe86-49b2-98a7-0e27f323e19f"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("de2d4f71-8ad6-4f97-93f3-e6fa5555ab2f"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("e281f618-8558-4869-b402-c155da5efb1e"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("e8ae6ada-c1f9-407d-b8b0-2eba477ac092"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("ed259129-03cf-4f56-81ce-04785793d546"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "IdPerson",
                keyValue: new Guid("2276ac38-0b83-424e-bdd6-e84d3fc28b93"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "IdPerson",
                keyValue: new Guid("4c324fa8-088d-4c73-8b2d-587eb8ccf8dd"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "IdPerson",
                keyValue: new Guid("b867fb67-44ba-4a62-a828-c493bb87ea3e"));

            migrationBuilder.AddColumn<decimal>(
                name: "SaleCost",
                table: "Orders",
                type: "numeric",
                nullable: true);

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
    }
}
