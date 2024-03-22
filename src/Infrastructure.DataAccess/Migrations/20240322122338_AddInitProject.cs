using System;
using System.Collections.Generic;
using Domain.Entities.Orders;
using Domain.Enums.ClassTypes;
using Domain.Enums.DocumentTypes;
using Domain.Enums.Genders;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.DataAccess.Migrations
{
    public partial class AddInitProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airlains",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IATACode = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airlains", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IsoNum = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    IsoCode = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    Rate = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IATACode = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CountryId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OfferId = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(20,2)", nullable: false),
                    BaggagePrice = table.Column<decimal>(type: "numeric(20,2)", nullable: true),
                    CurrencyId = table.Column<Guid>(type: "uuid", nullable: false),
                    CurrencyRate = table.Column<decimal>(type: "numeric(20,2)", nullable: false),
                    TicketNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    OrderStatusId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_OrderStatuses_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalTable: "OrderStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    CityId = table.Column<Guid>(type: "uuid", nullable: false),
                    IATACode = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Airports_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    MiddleName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "text", nullable: true),
                    PasswordSalt = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    LastLoginAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CitizenshipId = table.Column<Guid>(type: "uuid", nullable: true),
                    CityResidenceId = table.Column<Guid>(type: "uuid", nullable: true),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CurrencyId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Cities_CityResidenceId",
                        column: x => x.CityResidenceId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Countries_CitizenshipId",
                        column: x => x.CitizenshipId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderPassengers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    MiddleName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Gender = table.Column<GenderEnum>(type: "jsonb", nullable: false),
                    CitizenshipId = table.Column<Guid>(type: "uuid", nullable: false),
                    DocumentType = table.Column<PassengerDocumentTypeEnum>(type: "jsonb", nullable: false),
                    DocumentNumber = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IssueAt = table.Column<DateOnly>(type: "date", nullable: true),
                    ExpiredAt = table.Column<DateOnly>(type: "date", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPassengers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderPassengers_Countries_CitizenshipId",
                        column: x => x.CitizenshipId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderPassengers_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderRoutes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    DurationInSeconds = table.Column<int>(type: "integer", nullable: false),
                    CanRefund = table.Column<bool>(type: "boolean", nullable: false),
                    CanChange = table.Column<bool>(type: "boolean", nullable: false),
                    ArrivalAirportId = table.Column<Guid>(type: "uuid", nullable: false),
                    ArrivalAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DepartureAirportId = table.Column<Guid>(type: "uuid", nullable: false),
                    DepartureAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderRoutes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderRoutes_Airports_ArrivalAirportId",
                        column: x => x.ArrivalAirportId,
                        principalTable: "Airports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderRoutes_Airports_DepartureAirportId",
                        column: x => x.DepartureAirportId,
                        principalTable: "Airports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderRoutes_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderFlights",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoteId = table.Column<Guid>(type: "uuid", nullable: false),
                    Number = table.Column<string>(type: "text", nullable: false),
                    AirlineId = table.Column<Guid>(type: "uuid", nullable: false),
                    Aircraft = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    DurationInSeconds = table.Column<int>(type: "integer", nullable: false),
                    DistanceInKm = table.Column<double>(type: "double precision", nullable: false),
                    ClassType = table.Column<ClassTypeEnum>(type: "jsonb", nullable: false),
                    BaggageJson = table.Column<ICollection<FlightBaggage>>(type: "jsonb", nullable: false),
                    ArrivalAirportId = table.Column<Guid>(type: "uuid", nullable: false),
                    DepatureAirportId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderFlights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderFlights_Airlains_AirlineId",
                        column: x => x.AirlineId,
                        principalTable: "Airlains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderFlights_Airports_ArrivalAirportId",
                        column: x => x.ArrivalAirportId,
                        principalTable: "Airports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderFlights_Airports_DepatureAirportId",
                        column: x => x.DepatureAirportId,
                        principalTable: "Airports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderFlights_OrderRoutes_RoteId",
                        column: x => x.RoteId,
                        principalTable: "OrderRoutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Airlains",
                columns: new[] { "Id", "CreatedAt", "IATACode", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { new Guid("42072f36-e9a0-4184-a189-ace3e0036efa"), new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Utc), "SZ", null, "Somon Air" },
                    { new Guid("66ee2396-d593-4ad9-b6a2-435d82ce5b38"), new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Utc), "UA", null, "United Airlines" },
                    { new Guid("799c5589-e720-4009-a4f8-88d507700d8f"), new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Utc), "EK", null, "Emirates" },
                    { new Guid("98967639-2634-4924-b1be-4de33b90c02f"), new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Utc), "HH", null, "Qanot Sharq" },
                    { new Guid("ea608b7c-5982-4267-a276-69d257829d07"), new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Utc), "U6", null, "Уральские авиалинии" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "CreatedAt", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { new Guid("0541a1ab-fae2-4ffc-a361-1b5c84ca56bf"), "RU", new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Utc), null, "Россия" },
                    { new Guid("4083740c-d960-4950-83cf-65e4f89e4875"), "US", new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Utc), null, "США" },
                    { new Guid("635bf746-fb46-42e7-b98e-d11c8596c798"), "AE", new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Utc), null, "ОАЭ" },
                    { new Guid("675fa316-9670-435b-800f-fd4e076e76ae"), "UZ", new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Utc), null, "Узбекистан" },
                    { new Guid("ae32ad92-286d-41e6-8ea7-436c69c91025"), "TJ", new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Utc), null, "Таджикистан" }
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "CreatedAt", "IsoCode", "IsoNum", "ModifiedAt", "Name", "Rate" },
                values: new object[,]
                {
                    { new Guid("041e859a-4a7b-4883-b7ee-104d22b2542b"), new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Utc), "UZS", "860", null, "Узбекский сум", 0m },
                    { new Guid("4764fd15-1017-43a8-8fef-8f3312f34956"), new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Utc), "EUR", "978", null, "Евро", 0m },
                    { new Guid("53fd9edd-e622-491c-909e-3748b4668764"), new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Utc), "RUB", "643", null, "Российский рубль", 0m },
                    { new Guid("d731c30e-6944-4813-aafc-9c2f789da5bb"), new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Utc), "USD", "840", null, "Американский доллар", 0m },
                    { new Guid("de762a85-2f06-456b-bfb1-75ca0206e8c7"), new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Utc), "TJS", "972", null, "Таджикский сомони", 0m }
                });

            migrationBuilder.InsertData(
                table: "OrderStatuses",
                columns: new[] { "Id", "Code", "CreatedAt", "ModifiedAt", "Name" },
                values: new object[] { new Guid("105abf8d-2f8b-4bc9-9f89-640acd6cce1c"), "Created", new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Utc), null, "Создан" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "CreatedAt", "IATACode", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { new Guid("09f7eea6-ca7c-4bd9-842c-0916d0df8042"), new Guid("ae32ad92-286d-41e6-8ea7-436c69c91025"), new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Utc), "DYU", null, "Душанбе" },
                    { new Guid("0f41b6ff-bdda-42c7-883e-012d82c37791"), new Guid("0541a1ab-fae2-4ffc-a361-1b5c84ca56bf"), new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Utc), "MOW", null, "Москва" },
                    { new Guid("1c83a698-c96c-4bbd-9b05-1b1f2abcce82"), new Guid("0541a1ab-fae2-4ffc-a361-1b5c84ca56bf"), new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Utc), "LED", null, "Санкт-Петербург" },
                    { new Guid("42072f36-e9a0-4184-a189-ace3e0036efa"), new Guid("635bf746-fb46-42e7-b98e-d11c8596c798"), new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Utc), "DXB", null, "Дубай" },
                    { new Guid("8857dc1f-a51c-489e-9586-19db5372c711"), new Guid("4083740c-d960-4950-83cf-65e4f89e4875"), new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Utc), "NYC", null, "Нью-Йорк" },
                    { new Guid("a7f55e3b-4dd1-4903-80d9-40ce44007734"), new Guid("675fa316-9670-435b-800f-fd4e076e76ae"), new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Utc), "AZN", null, "Андижан" },
                    { new Guid("bac8b8e0-b639-4a3b-a063-5f874315e49d"), new Guid("635bf746-fb46-42e7-b98e-d11c8596c798"), new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Utc), "AUH", null, "Абу-Даби" },
                    { new Guid("ee1d374f-f06d-4753-baf3-8ed52881714e"), new Guid("ae32ad92-286d-41e6-8ea7-436c69c91025"), new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Utc), "LBD", null, "Худжанд" },
                    { new Guid("f737ab45-3dee-4024-8e40-639d3680fc14"), new Guid("675fa316-9670-435b-800f-fd4e076e76ae"), new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Utc), "TAS", null, "Ташкент" },
                    { new Guid("ff84a563-0807-453e-a1c2-2c87401726f8"), new Guid("4083740c-d960-4950-83cf-65e4f89e4875"), new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Utc), "LAX", null, "Лос-Анджелес" }
                });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "Id", "CityId", "CreatedAt", "IATACode", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { new Guid("09f7eea6-ca7c-4bd9-842c-0916d0df8042"), new Guid("09f7eea6-ca7c-4bd9-842c-0916d0df8042"), new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Utc), "DYU", null, "Международный аэропорт  Душанбе" },
                    { new Guid("0f41b6ff-bdda-42c7-883e-012d82c37791"), new Guid("0f41b6ff-bdda-42c7-883e-012d82c37791"), new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Utc), "DME", null, "Домодедово" },
                    { new Guid("1c83a698-c96c-4bbd-9b05-1b1f2abcce82"), new Guid("1c83a698-c96c-4bbd-9b05-1b1f2abcce82"), new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Utc), "LED", null, "Аэропорт Пулково" },
                    { new Guid("42072f36-e9a0-4184-a189-ace3e0036efa"), new Guid("42072f36-e9a0-4184-a189-ace3e0036efa"), new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Utc), "DXB", null, "Дубай" },
                    { new Guid("8857dc1f-a51c-489e-9586-19db5372c711"), new Guid("8857dc1f-a51c-489e-9586-19db5372c711"), new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Utc), "NYC", null, "Нью-Йорк" },
                    { new Guid("a7f55e3b-4dd1-4903-80d9-40ce44007734"), new Guid("a7f55e3b-4dd1-4903-80d9-40ce44007734"), new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Utc), "AZN", null, "Андижан" },
                    { new Guid("bac8b8e0-b639-4a3b-a063-5f874315e49d"), new Guid("bac8b8e0-b639-4a3b-a063-5f874315e49d"), new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Utc), "AUH", null, "Абу-Даби" },
                    { new Guid("ee1d374f-f06d-4753-baf3-8ed52881714e"), new Guid("ee1d374f-f06d-4753-baf3-8ed52881714e"), new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Utc), "LBD", null, "Международный аэропорт Худжанд" },
                    { new Guid("f737ab45-3dee-4024-8e40-639d3680fc14"), new Guid("f737ab45-3dee-4024-8e40-639d3680fc14"), new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Utc), "TAS", null, "Ташкент" },
                    { new Guid("ff84a563-0807-453e-a1c2-2c87401726f8"), new Guid("ff84a563-0807-453e-a1c2-2c87401726f8"), new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Utc), "LAX", null, "Лос-Анджелес" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Airports_CityId",
                table: "Airports",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderFlights_AirlineId",
                table: "OrderFlights",
                column: "AirlineId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderFlights_ArrivalAirportId",
                table: "OrderFlights",
                column: "ArrivalAirportId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderFlights_DepatureAirportId",
                table: "OrderFlights",
                column: "DepatureAirportId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderFlights_Number",
                table: "OrderFlights",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderFlights_RoteId",
                table: "OrderFlights",
                column: "RoteId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPassengers_CitizenshipId",
                table: "OrderPassengers",
                column: "CitizenshipId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPassengers_OrderId",
                table: "OrderPassengers",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderRoutes_ArrivalAirportId",
                table: "OrderRoutes",
                column: "ArrivalAirportId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderRoutes_DepartureAirportId",
                table: "OrderRoutes",
                column: "DepartureAirportId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderRoutes_OrderId",
                table: "OrderRoutes",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CurrencyId",
                table: "Orders",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CitizenshipId",
                table: "Users",
                column: "CitizenshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CityResidenceId",
                table: "Users",
                column: "CityResidenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CurrencyId",
                table: "Users",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhoneNumber",
                table: "Users",
                column: "PhoneNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderFlights");

            migrationBuilder.DropTable(
                name: "OrderPassengers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Airlains");

            migrationBuilder.DropTable(
                name: "OrderRoutes");

            migrationBuilder.DropTable(
                name: "Airports");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "OrderStatuses");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
