using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loans_Comparer.Migrations
{
    public partial class mssqlazure_migration_478 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ExternalInquiryId",
                table: "Inquiries");

            migrationBuilder.DropColumn(
                name: "BankId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Offers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Inquiries",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Offers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Inquiries",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExternalInquiryId",
                table: "Inquiries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "BankId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

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
    }
}
