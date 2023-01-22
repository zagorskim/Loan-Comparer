using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loans_Comparer.Migrations
{
    public partial class UserBirthday : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "BirthDate",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "44f8c542-ee06-4496-be04-fe93041c22c6", "ad15cfb5-686f-432e-994c-0ba7b6930e08", "Employee", "EMPLOYEE" },
                    { "50870953-0a56-4010-92a0-cd89449e6178", "0f429384-7566-46a9-a6e2-2e23690f2b6d", "Simple", "SIMPLE" },
                    { "92a4dc17-a83b-4cc2-8147-0d48d2f497f2", "f4f466c1-660b-4deb-805b-18ca30203c6f", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BankId", "BirthDate", "ConcurrencyStamp", "CreationDate", "Discriminator", "Email", "EmailConfirmed", "FirstName", "GovernmentId", "GovernmentIdType", "JobEndDate", "JobStartDate", "JobType", "LastName", "LevelIncome", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "SecurityStamp", "TokenCreated", "TokenExpires", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "5ab6b1a0-6338-46e8-b53e-e413964f2563", 0, null, "01.01.2023", "3d6cae94-e173-43b8-855f-0fbfae5d28cd", new DateTime(2023, 1, 16, 22, 10, 31, 148, DateTimeKind.Local).AddTicks(4379), "User", "admin@gmail.com", false, "Admin", "", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "AdminLastName", 0, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEG4qIjEL1l1ZkKOFSpKpxP7QzKFcNHaLokqWIvYd8E/NrXa6ZqZR8OlhIvnOokCRIg==", null, false, "", "ab6825b3-06a2-4f13-9191-a952a8e9095b", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "admin@gmail.com" },
                    { "af611be3-0469-4f94-97f9-cfedcb59c281", 0, 0, "01.01.2023", "8133d53d-fdc6-49b6-a9e6-8a77e8df9f99", new DateTime(2023, 1, 16, 22, 10, 31, 148, DateTimeKind.Local).AddTicks(4468), "User", "employee@gmail.com", false, "Employee", "", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "EmployeeLastName", 0, false, null, "EMPLOYEE@GMAIL.COM", "EMPLOYEE@GMAIL.COM", "AQAAAAEAACcQAAAAEES42RqgDzF3+av/82Lu+uQMFgtjtL+vdWSCn8ONu9lNspVl4wXjlb09XSkHB1VPsg==", null, false, "", "2e6c8ec1-423e-4acf-81c5-e79b4b3f7936", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "employee@gmail.com" },
                    { "f3188d78-2afa-41a7-a4f0-0d843e330e61", 0, null, "01.01.2023", "721fed4e-2642-461c-8949-6d7541c423b7", new DateTime(2023, 1, 16, 22, 10, 31, 148, DateTimeKind.Local).AddTicks(4448), "User", "simple@gmail.com", false, "Simple", "", 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 37, "SimpleLastName", 0, false, null, "SIMPLE@GMAIL.COM", "SIMPLE@GMAIL.COM", "AQAAAAEAACcQAAAAEKEeDT7CyRzCboN+nvx5+MeQ5yAcJlLPxpvWXOKkwy3yG+RG3PdLZvE/CkW52mfO3g==", null, false, "", "e9ef817b-a41d-4f19-b968-bc256a2865c5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "simple@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "92a4dc17-a83b-4cc2-8147-0d48d2f497f2", "5ab6b1a0-6338-46e8-b53e-e413964f2563" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "44f8c542-ee06-4496-be04-fe93041c22c6", "af611be3-0469-4f94-97f9-cfedcb59c281" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "50870953-0a56-4010-92a0-cd89449e6178", "f3188d78-2afa-41a7-a4f0-0d843e330e61" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "92a4dc17-a83b-4cc2-8147-0d48d2f497f2", "5ab6b1a0-6338-46e8-b53e-e413964f2563" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "44f8c542-ee06-4496-be04-fe93041c22c6", "af611be3-0469-4f94-97f9-cfedcb59c281" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "50870953-0a56-4010-92a0-cd89449e6178", "f3188d78-2afa-41a7-a4f0-0d843e330e61" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44f8c542-ee06-4496-be04-fe93041c22c6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50870953-0a56-4010-92a0-cd89449e6178");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92a4dc17-a83b-4cc2-8147-0d48d2f497f2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5ab6b1a0-6338-46e8-b53e-e413964f2563");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "af611be3-0469-4f94-97f9-cfedcb59c281");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3188d78-2afa-41a7-a4f0-0d843e330e61");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "AspNetUsers");

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
    }
}
