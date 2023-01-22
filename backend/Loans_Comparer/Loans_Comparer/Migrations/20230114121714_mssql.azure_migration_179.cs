using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loans_Comparer.Migrations
{
    public partial class mssqlazure_migration_179 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "da51f302-0e83-44b5-b7c3-81cdae47fdc1", "1b04b24e-1e01-4e35-a375-a01e19cb5004" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c055848a-df37-4df8-8ae2-d891c084950b", "85eca4cd-ce5d-4c55-9721-74afb2ad6b6a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "51bebd5b-cdab-4faf-b767-f018055d5eae", "c55b95eb-99f9-4fe8-971e-11c88fa83a9b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51bebd5b-cdab-4faf-b767-f018055d5eae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c055848a-df37-4df8-8ae2-d891c084950b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da51f302-0e83-44b5-b7c3-81cdae47fdc1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b04b24e-1e01-4e35-a375-a01e19cb5004");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85eca4cd-ce5d-4c55-9721-74afb2ad6b6a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c55b95eb-99f9-4fe8-971e-11c88fa83a9b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5b96d62a-a44c-4581-9dea-ed4c6e5c1f40", "1868f627-8d77-4417-bd85-e7b44b6ed280", "Admin", "ADMIN" },
                    { "9ae73647-fd68-4d80-8173-939fe92370e8", "6b52e7cd-bc5e-45ed-9393-e94eddacd308", "Employee", "EMPLOYEE" },
                    { "e7456c4e-278a-4786-afc3-cef26dba30b9", "8bc58600-a6fd-4676-b545-3f136d759da6", "Simple", "SIMPLE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BankId", "ConcurrencyStamp", "CreationDate", "Discriminator", "Email", "EmailConfirmed", "FirstName", "GovernmentId", "GovernmentIdType", "JobEndDate", "JobStartDate", "JobType", "LastName", "LevelIncome", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "SecurityStamp", "TokenCreated", "TokenExpires", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "755df574-c4ba-4fb1-aaa1-5fcec21bdd3a", 0, 0, "78ee996b-8222-4d1e-b11a-b76efbdd34d4", new DateTime(2023, 1, 14, 13, 17, 13, 238, DateTimeKind.Local).AddTicks(928), "User", "simple@gmail.com", false, "Simple", "", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 37, "SimpleLastName", 0, false, null, "SIMPLE@GMAIL.COM", "SIMPLE@GMAIL.COM", "AQAAAAEAACcQAAAAELMk6Sf0yckxoifOsipnxIjqfrhYEapPtzA3pFusSHZbnNWz4d0elAhNT28a2l6IYg==", null, false, "", "6e8be271-ccc8-4473-91bb-3cb054b91583", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "simple@gmail.com" },
                    { "b5e099e0-fa70-4500-a2c4-aca67a33e26f", 0, 0, "11561c0a-f5ff-403e-920f-184f886dc9b4", new DateTime(2023, 1, 14, 13, 17, 13, 238, DateTimeKind.Local).AddTicks(967), "User", "employee@gmail.com", false, "Employee", "", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "EmployeeLastName", 0, false, null, "EMPLOYEE@GMAIL.COM", "EMPLOYEE@GMAIL.COM", "AQAAAAEAACcQAAAAEK9RvLN5RY2FDGJxB+IupPKqtNukvTnQ7CU1tcoovsDXXcLSOqmIOwZq8JGfOI/A1w==", null, false, "", "cac81f81-4696-4b51-aaac-f92a80161405", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "employee@gmail.com" },
                    { "d2775e03-ab4b-4280-a207-4ba080cc9c61", 0, 0, "2025eac8-817a-4496-85f8-1518b16eb307", new DateTime(2023, 1, 14, 13, 17, 13, 238, DateTimeKind.Local).AddTicks(762), "User", "admin@gmail.com", false, "Admin", "", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "AdminLastName", 0, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEA3pi+Zy2ctb8R3W/ii/fbKenGoacU6cgdpSjErJpytEokgWpdQA/5aDTzu59Goxmw==", null, false, "", "d518f733-6ebf-4e88-b205-04bf77d5d7c7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "admin@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e7456c4e-278a-4786-afc3-cef26dba30b9", "755df574-c4ba-4fb1-aaa1-5fcec21bdd3a" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9ae73647-fd68-4d80-8173-939fe92370e8", "b5e099e0-fa70-4500-a2c4-aca67a33e26f" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5b96d62a-a44c-4581-9dea-ed4c6e5c1f40", "d2775e03-ab4b-4280-a207-4ba080cc9c61" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e7456c4e-278a-4786-afc3-cef26dba30b9", "755df574-c4ba-4fb1-aaa1-5fcec21bdd3a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9ae73647-fd68-4d80-8173-939fe92370e8", "b5e099e0-fa70-4500-a2c4-aca67a33e26f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5b96d62a-a44c-4581-9dea-ed4c6e5c1f40", "d2775e03-ab4b-4280-a207-4ba080cc9c61" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b96d62a-a44c-4581-9dea-ed4c6e5c1f40");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ae73647-fd68-4d80-8173-939fe92370e8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7456c4e-278a-4786-afc3-cef26dba30b9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "755df574-c4ba-4fb1-aaa1-5fcec21bdd3a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b5e099e0-fa70-4500-a2c4-aca67a33e26f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d2775e03-ab4b-4280-a207-4ba080cc9c61");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "51bebd5b-cdab-4faf-b767-f018055d5eae", "77e0f0c5-ea0c-4a02-bfdd-15440dc244af", "Simple", "SIMPLE" },
                    { "c055848a-df37-4df8-8ae2-d891c084950b", "0c28cb3e-089d-454d-9713-f24ec177ba3b", "Employee", "EMPLOYEE" },
                    { "da51f302-0e83-44b5-b7c3-81cdae47fdc1", "70688c97-8ab2-4561-9cbe-4b1e341289ff", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BankId", "ConcurrencyStamp", "CreationDate", "Discriminator", "Email", "EmailConfirmed", "FirstName", "GovernmentId", "GovernmentIdType", "JobEndDate", "JobStartDate", "JobType", "LastName", "LevelIncome", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "SecurityStamp", "TokenCreated", "TokenExpires", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1b04b24e-1e01-4e35-a375-a01e19cb5004", 0, 0, "3023ea7e-0c88-4124-833c-86658fd66877", new DateTime(2023, 1, 14, 12, 59, 38, 533, DateTimeKind.Local).AddTicks(4330), "User", "admin@gmail.com", false, "Admin", "", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "AdminLastName", 0, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEJrsNvfTNfhsB3REhZ9EuSRX3glzOUcKLasGpUukiU8AmCkrboBsljxSZP0RlAEiTg==", null, false, "", "971484b6-0b6b-4ae1-a78a-c262a37d4043", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "admin@gmail.com" },
                    { "85eca4cd-ce5d-4c55-9721-74afb2ad6b6a", 0, 0, "19a99f68-7ffb-44de-ac90-7c250e9b21cf", new DateTime(2023, 1, 14, 12, 59, 38, 533, DateTimeKind.Local).AddTicks(4463), "User", "employee@gmail.com", false, "Employee", "", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "EmployeeLastName", 0, false, null, "EMPLOYEE@GMAIL.COM", "EMPLOYEE@GMAIL.COM", "AQAAAAEAACcQAAAAEEXN3HJIQ3CEEUwTuKpQiFiJjcvuwhloSkVLS3A+y77TiYRstF0FURgWDBhTlP1qhg==", null, false, "", "cc8d9d77-9536-4bc5-9786-14944cec917a", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "employee@gmail.com" },
                    { "c55b95eb-99f9-4fe8-971e-11c88fa83a9b", 0, 0, "e35ef603-a4eb-4b83-86da-1493f6babc13", new DateTime(2023, 1, 14, 12, 59, 38, 533, DateTimeKind.Local).AddTicks(4423), "User", "simple@gmail.com", false, "Simple", "", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 37, "SimpleLastName", 0, false, null, "SIMPLE@GMAIL.COM", "SIMPLE@GMAIL.COM", "AQAAAAEAACcQAAAAEI1nV3m/CflfBzqrQBNUyn1kVvSPOtm8DgSh+GaiE931CtgPflffCNSZCtK3Dm+x5w==", null, false, "", "eb7bd9ce-dd5e-413c-b8fd-7fce1d26607c", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "simple@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "da51f302-0e83-44b5-b7c3-81cdae47fdc1", "1b04b24e-1e01-4e35-a375-a01e19cb5004" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c055848a-df37-4df8-8ae2-d891c084950b", "85eca4cd-ce5d-4c55-9721-74afb2ad6b6a" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "51bebd5b-cdab-4faf-b767-f018055d5eae", "c55b95eb-99f9-4fe8-971e-11c88fa83a9b" });
        }
    }
}
