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
                keyValue: new Guid("46864815-9044-4d68-a804-22d3f5723b6a"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("50d82207-0e80-4519-8062-9e50074b60ea"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("6bf62f70-3763-4008-bc42-f0befea85450"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("c08a51ba-d473-4041-9a04-b325a872226c"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "IdPerson",
                keyValue: new Guid("727f407e-e64e-4287-b5c5-16f7b837a4ab"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "IdPerson",
                keyValue: new Guid("8973b72d-2375-4d4a-a0eb-883324b97686"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "IdPerson",
                keyValue: new Guid("a25bed7f-59d5-44e5-bb24-e6ea30cdaf8c"));

            migrationBuilder.RenameColumn(
                name: "ManufacturerWarranty",
                table: "Orders",
                newName: "SaleCost");

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "IdCar", "Cost", "Discriminator", "IdWorkshop", "Model", "UserIdPerson", "Warranty" },
                values: new object[,]
                {
                    { new Guid("08a1f32f-f738-43fb-a34b-f99f0d8b0842"), 30000, "CarToBuy", 3, "Fiesta", null, 5 },
                    { new Guid("3c454538-b2b0-4f00-9086-3b3d0b26830a"), 50000, "CarToBuy", 1, "Astra", null, 3 },
                    { new Guid("42a52d8f-42e4-43a3-ba48-79f89226b2b3"), 40000, "CarToBuy", 2, "Golf", null, 4 },
                    { new Guid("636f9723-8eeb-4c07-a039-31056ace4132"), 20000, "CarToBuy", 3, "Civic", null, 2 }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "IdPerson", "BirthDate", "BookedDates", "Discriminator", "IdWorkshop", "Name", "Surname" },
                values: new object[,]
                {
                    { new Guid("1d736f70-76e7-4dab-8815-34e1acd76837"), new DateTime(1992, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new List<DateTime>(), "Mechanic", 1, "Ewa", "Kowalska" },
                    { new Guid("40b00aee-114a-4cc4-b257-317ddf222d41"), new DateTime(1988, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new List<DateTime>(), "Mechanic", 2, "Tomasz", "Lis" },
                    { new Guid("62988d48-7f31-4edb-a188-95dff0a2c4b5"), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new List<DateTime>(), "Mechanic", 1, "Adam", "Nowak" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("08a1f32f-f738-43fb-a34b-f99f0d8b0842"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("3c454538-b2b0-4f00-9086-3b3d0b26830a"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("42a52d8f-42e4-43a3-ba48-79f89226b2b3"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: new Guid("636f9723-8eeb-4c07-a039-31056ace4132"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "IdPerson",
                keyValue: new Guid("1d736f70-76e7-4dab-8815-34e1acd76837"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "IdPerson",
                keyValue: new Guid("40b00aee-114a-4cc4-b257-317ddf222d41"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "IdPerson",
                keyValue: new Guid("62988d48-7f31-4edb-a188-95dff0a2c4b5"));

            migrationBuilder.RenameColumn(
                name: "SaleCost",
                table: "Orders",
                newName: "ManufacturerWarranty");

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
        }
    }
}
