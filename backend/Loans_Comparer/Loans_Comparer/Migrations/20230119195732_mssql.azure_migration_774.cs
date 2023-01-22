using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loans_Comparer.Migrations
{
    public partial class mssqlazure_migration_774 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "35dbb5dc-f6a7-4b07-9676-27155fe26e6e", "6284b2c9-a6d3-405f-83ac-3a2be2e43a13" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3097e52c-cea4-47ea-9118-3ae3d65570c3", "b9579a20-cca5-4c44-9795-1cc3fff1badc" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f50ad0cd-1170-423c-81d1-dbb864e51779", "fc9ce816-118e-474a-ab95-e6d82ca1df9c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3097e52c-cea4-47ea-9118-3ae3d65570c3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35dbb5dc-f6a7-4b07-9676-27155fe26e6e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f50ad0cd-1170-423c-81d1-dbb864e51779");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6284b2c9-a6d3-405f-83ac-3a2be2e43a13");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b9579a20-cca5-4c44-9795-1cc3fff1badc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc9ce816-118e-474a-ab95-e6d82ca1df9c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d0d6b88d-06ec-4fca-a7fc-65ef5b54c09c", "60b6db11-e8b8-4fbd-97ba-c68dff8b5086", "Simple", "SIMPLE" },
                    { "d3c0bd55-3a5b-43b1-a510-bd3f2ab46eb6", "f45413c0-75a9-465d-85bf-0785a2e0c7d5", "Employee", "EMPLOYEE" },
                    { "e82fe3fe-53cd-477e-8378-421947141467", "0843b47e-a778-430c-9a82-b936a1e4a18a", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "CreationDate", "Discriminator", "Email", "EmailConfirmed", "FirstName", "GovernmentId", "GovernmentIdType", "JobEndDate", "JobStartDate", "JobType", "LastName", "LevelIncome", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "SecurityStamp", "TokenCreated", "TokenExpires", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "4f5d3860-34e6-4e2f-838f-051fe7918e00", 0, "01.01.2023", "3d503ddb-a28c-4b2a-be68-1a6ddcb8ebbf", new DateTime(2023, 1, 19, 20, 57, 31, 510, DateTimeKind.Local).AddTicks(2606), "User", "admin@gmail.com", false, "Admin", "", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "AdminLastName", 0, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEH08YxS29IFr3g4uxvOImcBV2v2NLVmKy8Mj3FQ9evqU+YOHxoovs9ARflsmN4EBeA==", null, false, "", "9bc4f4f0-ddce-4c29-8f16-e0031bfc2475", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "admin@gmail.com" },
                    { "7bca45f5-bb44-461b-b58f-c30a325cf0d3", 0, "01.01.2023", "e72856a2-ce32-4264-a062-3e21844cbb79", new DateTime(2023, 1, 19, 20, 57, 31, 510, DateTimeKind.Local).AddTicks(2679), "User", "employee@gmail.com", false, "Employee", "", 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 44, "EmployeeLastName", 0, false, null, "EMPLOYEE@GMAIL.COM", "EMPLOYEE@GMAIL.COM", "AQAAAAEAACcQAAAAED9zr1zRaclyLXO/k+9PSBBLIlLtcmS7WgGbX8gTpu/3mfl5qWNkUJlnsTraGnEVFA==", null, false, "", "16b6c551-20b1-4311-b967-c1cf24140ae7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "employee@gmail.com" },
                    { "a9258e28-1ff9-4622-b7cc-0af3a8f2d6ee", 0, "01.01.2023", "6ad93811-fe2a-4992-9a6a-85ba69c4b1a5", new DateTime(2023, 1, 19, 20, 57, 31, 510, DateTimeKind.Local).AddTicks(2661), "User", "simple@gmail.com", false, "Simple", "", 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 37, "SimpleLastName", 0, false, null, "SIMPLE@GMAIL.COM", "SIMPLE@GMAIL.COM", "AQAAAAEAACcQAAAAEF885m7tCWZOP5M6SkTHW8B2+UOoRsW0anK0otnQsaCJ4BMkPcU6VdYiEJYVJv1pzQ==", null, false, "", "4af17d4c-709b-443b-bed0-37f56ecc8f08", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "simple@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e82fe3fe-53cd-477e-8378-421947141467", "4f5d3860-34e6-4e2f-838f-051fe7918e00" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d3c0bd55-3a5b-43b1-a510-bd3f2ab46eb6", "7bca45f5-bb44-461b-b58f-c30a325cf0d3" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d0d6b88d-06ec-4fca-a7fc-65ef5b54c09c", "a9258e28-1ff9-4622-b7cc-0af3a8f2d6ee" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e82fe3fe-53cd-477e-8378-421947141467", "4f5d3860-34e6-4e2f-838f-051fe7918e00" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d3c0bd55-3a5b-43b1-a510-bd3f2ab46eb6", "7bca45f5-bb44-461b-b58f-c30a325cf0d3" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d0d6b88d-06ec-4fca-a7fc-65ef5b54c09c", "a9258e28-1ff9-4622-b7cc-0af3a8f2d6ee" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0d6b88d-06ec-4fca-a7fc-65ef5b54c09c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3c0bd55-3a5b-43b1-a510-bd3f2ab46eb6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e82fe3fe-53cd-477e-8378-421947141467");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f5d3860-34e6-4e2f-838f-051fe7918e00");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7bca45f5-bb44-461b-b58f-c30a325cf0d3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a9258e28-1ff9-4622-b7cc-0af3a8f2d6ee");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3097e52c-cea4-47ea-9118-3ae3d65570c3", "d1778681-9dec-4fd9-8214-83fad6698c75", "Admin", "ADMIN" },
                    { "35dbb5dc-f6a7-4b07-9676-27155fe26e6e", "9ef9090c-b53c-4467-a647-0c9b48450957", "Employee", "EMPLOYEE" },
                    { "f50ad0cd-1170-423c-81d1-dbb864e51779", "b8d97f32-4002-4f3d-b16d-72f78ca636a0", "Simple", "SIMPLE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "CreationDate", "Discriminator", "Email", "EmailConfirmed", "FirstName", "GovernmentId", "GovernmentIdType", "JobEndDate", "JobStartDate", "JobType", "LastName", "LevelIncome", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "SecurityStamp", "TokenCreated", "TokenExpires", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6284b2c9-a6d3-405f-83ac-3a2be2e43a13", 0, "01.01.2023", "7bd7641e-487d-49da-bdd9-caea77dbbbbc", new DateTime(2023, 1, 19, 17, 56, 23, 750, DateTimeKind.Local).AddTicks(2501), "User", "employee@gmail.com", false, "Employee", "", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 44, "EmployeeLastName", 0, false, null, "EMPLOYEE@GMAIL.COM", "EMPLOYEE@GMAIL.COM", "AQAAAAEAACcQAAAAEDezMCMvYFBYFDn641X99hCqEAsG66lFy8vo0QSf32DVshP2mw0uvDcGPtsYr0j/CQ==", null, false, "", "c68ac17c-84ed-422e-8c81-a537b526ade6", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "employee@gmail.com" },
                    { "b9579a20-cca5-4c44-9795-1cc3fff1badc", 0, "01.01.2023", "ca1d2b40-71f3-4e40-9a05-eb9c32a02a41", new DateTime(2023, 1, 19, 17, 56, 23, 750, DateTimeKind.Local).AddTicks(2350), "User", "admin@gmail.com", false, "Admin", "", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "AdminLastName", 0, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEP6GAZIm7BLDixjtHUzoinT/LLzEOtrx8NWXW6GpEuHdHrP5ib2flu4J8Qebdb8h+g==", null, false, "", "1b3b4de0-2d24-4b18-82d8-8ab11c49999e", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "admin@gmail.com" },
                    { "fc9ce816-118e-474a-ab95-e6d82ca1df9c", 0, "01.01.2023", "a62540a3-f9b8-4a21-9b58-c8a92e4c093f", new DateTime(2023, 1, 19, 17, 56, 23, 750, DateTimeKind.Local).AddTicks(2401), "User", "simple@gmail.com", false, "Simple", "", 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 37, "SimpleLastName", 0, false, null, "SIMPLE@GMAIL.COM", "SIMPLE@GMAIL.COM", "AQAAAAEAACcQAAAAEGXBx6+veUFP3w7dXnQnLV2nLHxZTy7x7AET3lHKWTjeHNF+IRv9j/Gl/iMPsuOWbQ==", null, false, "", "ff0ca8a5-f670-4786-88b1-9d5af5ff0884", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "simple@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "35dbb5dc-f6a7-4b07-9676-27155fe26e6e", "6284b2c9-a6d3-405f-83ac-3a2be2e43a13" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3097e52c-cea4-47ea-9118-3ae3d65570c3", "b9579a20-cca5-4c44-9795-1cc3fff1badc" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f50ad0cd-1170-423c-81d1-dbb864e51779", "fc9ce816-118e-474a-ab95-e6d82ca1df9c" });
        }
    }
}
