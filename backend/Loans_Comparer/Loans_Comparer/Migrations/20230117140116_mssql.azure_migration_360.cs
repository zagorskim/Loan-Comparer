using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loans_Comparer.Migrations
{
    public partial class mssqlazure_migration_360 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "59cf55e4-a340-4098-b6f8-b7d3abf0bb7f", "2a2fb68f-5673-43c4-8831-9a04a695fc22" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f40d6799-593c-4291-b919-16724b593270", "4f1a1198-807a-4ca5-8e7b-f09086dfa19a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8b606135-1228-4cc8-9536-d13645a9f9cd", "9b9dfbf8-20e4-498a-9738-08596e4320ca" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59cf55e4-a340-4098-b6f8-b7d3abf0bb7f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b606135-1228-4cc8-9536-d13645a9f9cd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f40d6799-593c-4291-b919-16724b593270");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a2fb68f-5673-43c4-8831-9a04a695fc22");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f1a1198-807a-4ca5-8e7b-f09086dfa19a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b9dfbf8-20e4-498a-9738-08596e4320ca");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6aa11642-c200-4a76-8ff3-bb16a3955d9f", "e49faa84-0c49-422b-8317-20c45d5e1d6f", "Employee", "EMPLOYEE" },
                    { "b3398788-4652-4ec8-ad74-57a2debf2189", "41d84787-6836-4a3a-b123-5ff47c409edd", "Admin", "ADMIN" },
                    { "df9d9caf-1b55-482b-928f-92bec67b5ecc", "f487463c-bad4-4e62-8c82-c00fcfe18c05", "Simple", "SIMPLE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BankId", "BirthDate", "ConcurrencyStamp", "CreationDate", "Discriminator", "Email", "EmailConfirmed", "FirstName", "GovernmentId", "GovernmentIdType", "JobEndDate", "JobStartDate", "JobType", "LastName", "LevelIncome", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "SecurityStamp", "TokenCreated", "TokenExpires", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "031e619a-b25e-4e4c-9a8b-a6c4736a3f98", 0, null, "01.01.2023", "0fa36844-1c08-49be-badf-674232244a16", new DateTime(2023, 1, 17, 15, 1, 15, 724, DateTimeKind.Local).AddTicks(6965), "User", "admin@gmail.com", false, "Admin", "", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "AdminLastName", 0, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEG4GO1UTtZV8T+VwRaBclEfFBTqM12fhWna18cCX6ht/UHUulzuzEZp62CjZgCwocw==", null, false, "", "4d828b1e-9989-4be0-9e2f-d100a7632c7f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "admin@gmail.com" },
                    { "85f1c88a-d1d5-41f1-8625-1b139a83ad7f", 0, 0, "01.01.2023", "f24f7439-1824-4120-9f2c-fa7fe7bdb18f", new DateTime(2023, 1, 17, 15, 1, 15, 724, DateTimeKind.Local).AddTicks(7078), "User", "employee@gmail.com", false, "Employee", "", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "EmployeeLastName", 0, false, null, "EMPLOYEE@GMAIL.COM", "EMPLOYEE@GMAIL.COM", "AQAAAAEAACcQAAAAEDuiqWKN4TByC8z2rxv77ayAadXlDy2R7NRwHZ6HVH3sH0ydjir5TawNi2kCyKpqUg==", null, false, "", "b86ae7be-3842-4d75-a106-898165f6369f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "employee@gmail.com" },
                    { "dc6c1325-f867-437a-9a82-6f3e8e1eb089", 0, null, "01.01.2023", "3d323fb4-0a12-422b-91ef-753d92de173c", new DateTime(2023, 1, 17, 15, 1, 15, 724, DateTimeKind.Local).AddTicks(7047), "User", "simple@gmail.com", false, "Simple", "", 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 37, "SimpleLastName", 0, false, null, "SIMPLE@GMAIL.COM", "SIMPLE@GMAIL.COM", "AQAAAAEAACcQAAAAEDrvELD8LdaCnaSbXPRaOw6sDCa/sGZ/JmQF9hOlEaQdvLl9gGaYaIZALoYoQKy8/Q==", null, false, "", "cf94114c-1d04-487e-a338-ea4ec0ed2f91", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "simple@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b3398788-4652-4ec8-ad74-57a2debf2189", "031e619a-b25e-4e4c-9a8b-a6c4736a3f98" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6aa11642-c200-4a76-8ff3-bb16a3955d9f", "85f1c88a-d1d5-41f1-8625-1b139a83ad7f" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "df9d9caf-1b55-482b-928f-92bec67b5ecc", "dc6c1325-f867-437a-9a82-6f3e8e1eb089" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b3398788-4652-4ec8-ad74-57a2debf2189", "031e619a-b25e-4e4c-9a8b-a6c4736a3f98" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6aa11642-c200-4a76-8ff3-bb16a3955d9f", "85f1c88a-d1d5-41f1-8625-1b139a83ad7f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "df9d9caf-1b55-482b-928f-92bec67b5ecc", "dc6c1325-f867-437a-9a82-6f3e8e1eb089" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6aa11642-c200-4a76-8ff3-bb16a3955d9f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3398788-4652-4ec8-ad74-57a2debf2189");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df9d9caf-1b55-482b-928f-92bec67b5ecc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "031e619a-b25e-4e4c-9a8b-a6c4736a3f98");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85f1c88a-d1d5-41f1-8625-1b139a83ad7f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dc6c1325-f867-437a-9a82-6f3e8e1eb089");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "59cf55e4-a340-4098-b6f8-b7d3abf0bb7f", "9b619545-ec2e-4511-8861-1d3759d99d5e", "Employee", "EMPLOYEE" },
                    { "8b606135-1228-4cc8-9536-d13645a9f9cd", "c1875ada-7042-47af-bde7-1cee7fa37082", "Simple", "SIMPLE" },
                    { "f40d6799-593c-4291-b919-16724b593270", "f03a697b-b1f8-46a4-ab9f-03e0c3c34b9f", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BankId", "BirthDate", "ConcurrencyStamp", "CreationDate", "Discriminator", "Email", "EmailConfirmed", "FirstName", "GovernmentId", "GovernmentIdType", "JobEndDate", "JobStartDate", "JobType", "LastName", "LevelIncome", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "SecurityStamp", "TokenCreated", "TokenExpires", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2a2fb68f-5673-43c4-8831-9a04a695fc22", 0, 0, "01.01.2023", "85c06d16-6981-46a7-a18e-f3b3c9f466c8", new DateTime(2023, 1, 16, 22, 11, 28, 479, DateTimeKind.Local).AddTicks(5801), "User", "employee@gmail.com", false, "Employee", "", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "EmployeeLastName", 0, false, null, "EMPLOYEE@GMAIL.COM", "EMPLOYEE@GMAIL.COM", "AQAAAAEAACcQAAAAEKhfupOLFGuIrVcpUUdzY5T8QEpjICEsauPHK2hpNd/qrlB8TfU/z4IJnRCwybK6xg==", null, false, "", "4ffe409a-a879-4f30-a565-2484c8542682", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "employee@gmail.com" },
                    { "4f1a1198-807a-4ca5-8e7b-f09086dfa19a", 0, null, "01.01.2023", "e27e3e09-0a1d-46e3-abcb-7faa6f6eedc5", new DateTime(2023, 1, 16, 22, 11, 28, 479, DateTimeKind.Local).AddTicks(5564), "User", "admin@gmail.com", false, "Admin", "", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "AdminLastName", 0, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEH4j7eNjyr+uKhSUX02UIOCB4r+7LTgiHxEPLvGoUjvb6HAy8r8vHm9BAj4O438NlQ==", null, false, "", "1c15781d-b2dc-423c-8cc4-70222db97992", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "admin@gmail.com" },
                    { "9b9dfbf8-20e4-498a-9738-08596e4320ca", 0, null, "01.01.2023", "93bc779f-fde9-4f3a-a1af-3d79a7041d88", new DateTime(2023, 1, 16, 22, 11, 28, 479, DateTimeKind.Local).AddTicks(5644), "User", "simple@gmail.com", false, "Simple", "", 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 37, "SimpleLastName", 0, false, null, "SIMPLE@GMAIL.COM", "SIMPLE@GMAIL.COM", "AQAAAAEAACcQAAAAEIXrvHM8AMKN7ENkheUhyLR86h8FRNcifBqUQuIz8NOTSKZnyxAJoLbS1aZya387xA==", null, false, "", "d5ff7c18-7223-4c37-b839-8157b71c460a", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "simple@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "59cf55e4-a340-4098-b6f8-b7d3abf0bb7f", "2a2fb68f-5673-43c4-8831-9a04a695fc22" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f40d6799-593c-4291-b919-16724b593270", "4f1a1198-807a-4ca5-8e7b-f09086dfa19a" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8b606135-1228-4cc8-9536-d13645a9f9cd", "9b9dfbf8-20e4-498a-9738-08596e4320ca" });
        }
    }
}
