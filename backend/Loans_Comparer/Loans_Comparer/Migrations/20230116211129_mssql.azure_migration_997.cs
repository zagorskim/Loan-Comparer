using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loans_Comparer.Migrations
{
    public partial class mssqlazure_migration_997 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
