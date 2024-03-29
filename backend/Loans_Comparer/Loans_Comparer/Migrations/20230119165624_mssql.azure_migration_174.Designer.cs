﻿// <auto-generated />
using System;
using Loans_Comparer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Loans_Comparer.Migrations
{
    [DbContext(typeof(LoanComparerDbContext))]
    [Migration("20230119165624_mssql.azure_migration_174")]
    partial class mssqlazure_migration_174
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Loans_Comparer.Entites.Inquiry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BankId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("InstallmentsAmount")
                        .HasColumnType("int");

                    b.Property<double>("MoneyAmount")
                        .HasColumnType("float");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Inquiries");
                });

            modelBuilder.Entity("Loans_Comparer.Entites.Offer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BankId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DocumentLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DocumentValidDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExternalOfferId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("InquiryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("InstallmentAmount")
                        .HasColumnType("int");

                    b.Property<double>("MoneyAmount")
                        .HasColumnType("float");

                    b.Property<double>("MonthlyInstallment")
                        .HasColumnType("float");

                    b.Property<double>("Percentage")
                        .HasColumnType("float");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "3097e52c-cea4-47ea-9118-3ae3d65570c3",
                            ConcurrencyStamp = "d1778681-9dec-4fd9-8214-83fad6698c75",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "f50ad0cd-1170-423c-81d1-dbb864e51779",
                            ConcurrencyStamp = "b8d97f32-4002-4f3d-b16d-72f78ca636a0",
                            Name = "Simple",
                            NormalizedName = "SIMPLE"
                        },
                        new
                        {
                            Id = "35dbb5dc-f6a7-4b07-9676-27155fe26e6e",
                            ConcurrencyStamp = "9ef9090c-b53c-4467-a647-0c9b48450957",
                            Name = "Employee",
                            NormalizedName = "EMPLOYEE"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "b9579a20-cca5-4c44-9795-1cc3fff1badc",
                            RoleId = "3097e52c-cea4-47ea-9118-3ae3d65570c3"
                        },
                        new
                        {
                            UserId = "fc9ce816-118e-474a-ab95-e6d82ca1df9c",
                            RoleId = "f50ad0cd-1170-423c-81d1-dbb864e51779"
                        },
                        new
                        {
                            UserId = "6284b2c9-a6d3-405f-83ac-3a2be2e43a13",
                            RoleId = "35dbb5dc-f6a7-4b07-9676-27155fe26e6e"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Loans_Comparer.Entites.User", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("BirthDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GovernmentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GovernmentIdType")
                        .HasColumnType("int");

                    b.Property<DateTime>("JobEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("JobStartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("JobType")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LevelIncome")
                        .HasColumnType("int");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TokenCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TokenExpires")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("User");

                    b.HasData(
                        new
                        {
                            Id = "b9579a20-cca5-4c44-9795-1cc3fff1badc",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ca1d2b40-71f3-4e40-9a05-eb9c32a02a41",
                            Email = "admin@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@GMAIL.COM",
                            NormalizedUserName = "ADMIN@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEP6GAZIm7BLDixjtHUzoinT/LLzEOtrx8NWXW6GpEuHdHrP5ib2flu4J8Qebdb8h+g==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "1b3b4de0-2d24-4b18-82d8-8ab11c49999e",
                            TwoFactorEnabled = false,
                            UserName = "admin@gmail.com",
                            BirthDate = "01.01.2023",
                            CreationDate = new DateTime(2023, 1, 19, 17, 56, 23, 750, DateTimeKind.Local).AddTicks(2350),
                            FirstName = "Admin",
                            GovernmentId = "",
                            GovernmentIdType = 0,
                            JobEndDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            JobStartDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            JobType = 0,
                            LastName = "AdminLastName",
                            LevelIncome = 0,
                            RefreshToken = "",
                            TokenCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TokenExpires = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = "fc9ce816-118e-474a-ab95-e6d82ca1df9c",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a62540a3-f9b8-4a21-9b58-c8a92e4c093f",
                            Email = "simple@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "SIMPLE@GMAIL.COM",
                            NormalizedUserName = "SIMPLE@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEGXBx6+veUFP3w7dXnQnLV2nLHxZTy7x7AET3lHKWTjeHNF+IRv9j/Gl/iMPsuOWbQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "ff0ca8a5-f670-4786-88b1-9d5af5ff0884",
                            TwoFactorEnabled = false,
                            UserName = "simple@gmail.com",
                            BirthDate = "01.01.2023",
                            CreationDate = new DateTime(2023, 1, 19, 17, 56, 23, 750, DateTimeKind.Local).AddTicks(2401),
                            FirstName = "Simple",
                            GovernmentId = "",
                            GovernmentIdType = 3,
                            JobEndDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            JobStartDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            JobType = 37,
                            LastName = "SimpleLastName",
                            LevelIncome = 0,
                            RefreshToken = "",
                            TokenCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TokenExpires = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = "6284b2c9-a6d3-405f-83ac-3a2be2e43a13",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7bd7641e-487d-49da-bdd9-caea77dbbbbc",
                            Email = "employee@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "EMPLOYEE@GMAIL.COM",
                            NormalizedUserName = "EMPLOYEE@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEDezMCMvYFBYFDn641X99hCqEAsG66lFy8vo0QSf32DVshP2mw0uvDcGPtsYr0j/CQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "c68ac17c-84ed-422e-8c81-a537b526ade6",
                            TwoFactorEnabled = false,
                            UserName = "employee@gmail.com",
                            BirthDate = "01.01.2023",
                            CreationDate = new DateTime(2023, 1, 19, 17, 56, 23, 750, DateTimeKind.Local).AddTicks(2501),
                            FirstName = "Employee",
                            GovernmentId = "",
                            GovernmentIdType = 0,
                            JobEndDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            JobStartDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            JobType = 44,
                            LastName = "EmployeeLastName",
                            LevelIncome = 0,
                            RefreshToken = "",
                            TokenCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TokenExpires = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
