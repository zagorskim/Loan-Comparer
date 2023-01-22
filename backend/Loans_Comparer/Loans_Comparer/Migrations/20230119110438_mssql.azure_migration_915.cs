using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loans_Comparer.Migrations
{
    public partial class mssqlazure_migration_915 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c6b5f6af-0247-4795-8b04-e097a5c0bed3", "2606afd5-2056-47fa-b0fb-c6a1a33ba801" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eb3997d0-550a-459b-85b6-3474cd83f13a", "83a089af-cca0-47ef-abef-50973b9a625f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "310008f9-73c9-42a1-8fca-d0389cff7073", "9ae913a9-5e92-4950-8c74-1b2a4ad9c8da" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "310008f9-73c9-42a1-8fca-d0389cff7073");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6b5f6af-0247-4795-8b04-e097a5c0bed3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb3997d0-550a-459b-85b6-3474cd83f13a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2606afd5-2056-47fa-b0fb-c6a1a33ba801");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83a089af-cca0-47ef-abef-50973b9a625f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ae913a9-5e92-4950-8c74-1b2a4ad9c8da");

            migrationBuilder.AddColumn<string>(
                name: "DocumentLink",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DocumentValidDate",
                table: "Offers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "DocumentLink",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "DocumentValidDate",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Offers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "310008f9-73c9-42a1-8fca-d0389cff7073", "50f67b46-78e5-4a6c-8674-33144309ec5d", "Simple", "SIMPLE" },
                    { "c6b5f6af-0247-4795-8b04-e097a5c0bed3", "0e2b5203-8234-4492-acc9-67d422609896", "Employee", "EMPLOYEE" },
                    { "eb3997d0-550a-459b-85b6-3474cd83f13a", "7bc01f11-2b6a-42dc-8e0e-8e10d562c9ca", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "CreationDate", "Discriminator", "Email", "EmailConfirmed", "FirstName", "GovernmentId", "GovernmentIdType", "JobEndDate", "JobStartDate", "JobType", "LastName", "LevelIncome", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "SecurityStamp", "TokenCreated", "TokenExpires", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2606afd5-2056-47fa-b0fb-c6a1a33ba801", 0, "01.01.2023", "c1c9b432-96a3-4099-a03a-75fee96dc1cf", new DateTime(2023, 1, 18, 20, 23, 21, 390, DateTimeKind.Local).AddTicks(5562), "User", "employee@gmail.com", false, "Employee", "", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "EmployeeLastName", 0, false, null, "EMPLOYEE@GMAIL.COM", "EMPLOYEE@GMAIL.COM", "AQAAAAEAACcQAAAAEJVOrI8U0mDes9f5XLR5K90iJckTKnuH0VT3EJqRid46e6fSkkXTHY4fDROXyhrgLw==", null, false, "", "d085c935-1ffd-4554-9aed-83ea18808c65", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "employee@gmail.com" },
                    { "83a089af-cca0-47ef-abef-50973b9a625f", 0, "01.01.2023", "8adf4d7d-165e-443e-9cbb-a31cb508eb5d", new DateTime(2023, 1, 18, 20, 23, 21, 390, DateTimeKind.Local).AddTicks(5494), "User", "admin@gmail.com", false, "Admin", "", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "AdminLastName", 0, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEEdpHfYJPylS62uixrwl/p0095ADimFXzIgl4+RMWbI6J4EvVr5oLSnYVt3Zv8EycA==", null, false, "", "ba9e0885-306b-4f93-8351-c12fc66ec073", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "admin@gmail.com" },
                    { "9ae913a9-5e92-4950-8c74-1b2a4ad9c8da", 0, "01.01.2023", "0a2b4f07-9a7f-4959-80fa-9dbeb053fe5d", new DateTime(2023, 1, 18, 20, 23, 21, 390, DateTimeKind.Local).AddTicks(5544), "User", "simple@gmail.com", false, "Simple", "", 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 37, "SimpleLastName", 0, false, null, "SIMPLE@GMAIL.COM", "SIMPLE@GMAIL.COM", "AQAAAAEAACcQAAAAENjj+SeXg5XF3HkvwJoT+q3a/LciPFsKuFao+vAFjVEX0g9KVipXrxtZymO2g0beCQ==", null, false, "", "56d34a06-53d2-4e76-a940-6ccd2bf7c3c2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "simple@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c6b5f6af-0247-4795-8b04-e097a5c0bed3", "2606afd5-2056-47fa-b0fb-c6a1a33ba801" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "eb3997d0-550a-459b-85b6-3474cd83f13a", "83a089af-cca0-47ef-abef-50973b9a625f" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "310008f9-73c9-42a1-8fca-d0389cff7073", "9ae913a9-5e92-4950-8c74-1b2a4ad9c8da" });
        }
    }
}
