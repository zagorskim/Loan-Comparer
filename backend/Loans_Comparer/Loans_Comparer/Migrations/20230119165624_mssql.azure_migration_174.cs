using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loans_Comparer.Migrations
{
    public partial class mssqlazure_migration_174 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cf5a42b8-f6ff-4a3f-8ad7-886a845f4eaf", "48f7898a-277f-4c66-9064-1d882948a696" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5588f0db-17dc-4727-8e81-4f781ae91fe4", "8a6c0ca7-7998-4018-8f96-121ca17b7fa4" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "93529ba9-b4fa-4d3a-82cf-1525e51ccedc", "9c6d5bd0-eaf5-46bc-8b8a-0b299bf4f8dc" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5588f0db-17dc-4727-8e81-4f781ae91fe4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93529ba9-b4fa-4d3a-82cf-1525e51ccedc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf5a42b8-f6ff-4a3f-8ad7-886a845f4eaf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "48f7898a-277f-4c66-9064-1d882948a696");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a6c0ca7-7998-4018-8f96-121ca17b7fa4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c6d5bd0-eaf5-46bc-8b8a-0b299bf4f8dc");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "5588f0db-17dc-4727-8e81-4f781ae91fe4", "71c7f9e9-08d5-4df1-a180-4da6a93bdef8", "Admin", "ADMIN" },
                    { "93529ba9-b4fa-4d3a-82cf-1525e51ccedc", "e4976ebe-3b0e-44c0-9576-6a9bfdab0612", "Employee", "EMPLOYEE" },
                    { "cf5a42b8-f6ff-4a3f-8ad7-886a845f4eaf", "f279de9c-1372-4a1d-8c05-93fcd11449c0", "Simple", "SIMPLE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "CreationDate", "Discriminator", "Email", "EmailConfirmed", "FirstName", "GovernmentId", "GovernmentIdType", "JobEndDate", "JobStartDate", "JobType", "LastName", "LevelIncome", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "SecurityStamp", "TokenCreated", "TokenExpires", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "48f7898a-277f-4c66-9064-1d882948a696", 0, "01.01.2023", "668af7a4-8038-4818-9f96-e8b19c72d9e8", new DateTime(2023, 1, 19, 12, 4, 37, 532, DateTimeKind.Local).AddTicks(4855), "User", "simple@gmail.com", false, "Simple", "", 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 37, "SimpleLastName", 0, false, null, "SIMPLE@GMAIL.COM", "SIMPLE@GMAIL.COM", "AQAAAAEAACcQAAAAEL7wrUmsIv74KJw01QbCJlq21DhUxV4Nc54spOrqIujRBj2yH+cjawKrin8BwYt+gQ==", null, false, "", "03b50fbf-1e4d-4f83-b916-c6c96413ec95", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "simple@gmail.com" },
                    { "8a6c0ca7-7998-4018-8f96-121ca17b7fa4", 0, "01.01.2023", "a749260b-ebcd-4b72-a577-a7afa0a58a84", new DateTime(2023, 1, 19, 12, 4, 37, 532, DateTimeKind.Local).AddTicks(4801), "User", "admin@gmail.com", false, "Admin", "", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "AdminLastName", 0, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAELXwNYUMeWvmc2HLrt9nfdTbD2m6i02t8SqG3ehVUTU2sBphTaWdEMRcXhf+LGwLyg==", null, false, "", "a26fbc37-7a0c-4624-9d32-129231ec0de3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "admin@gmail.com" },
                    { "9c6d5bd0-eaf5-46bc-8b8a-0b299bf4f8dc", 0, "01.01.2023", "000d9bd3-331f-443f-8c30-2cba35afeeda", new DateTime(2023, 1, 19, 12, 4, 37, 532, DateTimeKind.Local).AddTicks(4870), "User", "employee@gmail.com", false, "Employee", "", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "EmployeeLastName", 0, false, null, "EMPLOYEE@GMAIL.COM", "EMPLOYEE@GMAIL.COM", "AQAAAAEAACcQAAAAEIgo4hgGE3t3huGjHv+TmW7cTIVe3fqQRBmNlxxVaCxpIesf2/C1LOLJjMioOUT6Aw==", null, false, "", "5b75c4cd-c850-4dc5-9923-784ec6e64c4b", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "employee@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cf5a42b8-f6ff-4a3f-8ad7-886a845f4eaf", "48f7898a-277f-4c66-9064-1d882948a696" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5588f0db-17dc-4727-8e81-4f781ae91fe4", "8a6c0ca7-7998-4018-8f96-121ca17b7fa4" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "93529ba9-b4fa-4d3a-82cf-1525e51ccedc", "9c6d5bd0-eaf5-46bc-8b8a-0b299bf4f8dc" });
        }
    }
}
