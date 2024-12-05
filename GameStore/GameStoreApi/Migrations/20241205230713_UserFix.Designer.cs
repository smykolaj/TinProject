﻿// <auto-generated />
using System;
using GameStore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GameStore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241205230713_UserFix")]
    partial class UserFix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("GameStore.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "GSC Game World",
                            Genre = "Action, Survival",
                            Name = "STALKER",
                            Price = 19.99m,
                            ReleaseDate = new DateTime(2007, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Author = "FromSoftware",
                            Genre = "Action RPG",
                            Name = "Dark Souls",
                            Price = 39.99m,
                            ReleaseDate = new DateTime(2011, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Author = "Team Cherry",
                            Genre = "Metroidvania",
                            Name = "Hollow Knight",
                            Price = 14.99m,
                            ReleaseDate = new DateTime(2017, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            Author = "Epic Games",
                            Genre = "Battle Royale",
                            Name = "Fortnite",
                            Price = 0.00m,
                            ReleaseDate = new DateTime(2017, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            Author = "Mojang Studios",
                            Genre = "Sandbox, Survival",
                            Name = "Minecraft",
                            Price = 29.99m,
                            ReleaseDate = new DateTime(2011, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 6,
                            Author = "CD Projekt Red",
                            Genre = "Action RPG",
                            Name = "The Witcher 3",
                            Price = 49.99m,
                            ReleaseDate = new DateTime(2015, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 7,
                            Author = "CD Projekt Red",
                            Genre = "Action RPG",
                            Name = "Cyberpunk 2077",
                            Price = 59.99m,
                            ReleaseDate = new DateTime(2020, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 8,
                            Author = "Maddy Makes Games",
                            Genre = "Platformer",
                            Name = "Celeste",
                            Price = 19.99m,
                            ReleaseDate = new DateTime(2018, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 9,
                            Author = "FromSoftware",
                            Genre = "Action RPG",
                            Name = "Elden Ring",
                            Price = 59.99m,
                            ReleaseDate = new DateTime(2022, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 10,
                            Author = "Valve",
                            Genre = "Puzzle",
                            Name = "Portal 2",
                            Price = 9.99m,
                            ReleaseDate = new DateTime(2011, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("GameStore.Models.Purchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("UserId");

                    b.ToTable("Purchases");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GameId = 2,
                            PurchaseDate = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            GameId = 4,
                            PurchaseDate = new DateTime(2023, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            GameId = 1,
                            PurchaseDate = new DateTime(2023, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            GameId = 5,
                            PurchaseDate = new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 4
                        },
                        new
                        {
                            Id = 5,
                            GameId = 3,
                            PurchaseDate = new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 5
                        },
                        new
                        {
                            Id = 6,
                            GameId = 6,
                            PurchaseDate = new DateTime(2023, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 6
                        },
                        new
                        {
                            Id = 7,
                            GameId = 7,
                            PurchaseDate = new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 7
                        },
                        new
                        {
                            Id = 8,
                            GameId = 9,
                            PurchaseDate = new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 8
                        },
                        new
                        {
                            Id = 9,
                            GameId = 8,
                            PurchaseDate = new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 9
                        },
                        new
                        {
                            Id = 10,
                            GameId = 10,
                            PurchaseDate = new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 10
                        });
                });

            modelBuilder.Entity("GameStore.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("RefreshTokenExp")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(2005, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "smykolka@gmail.com",
                            FirstName = "Mykola",
                            Gender = "Male",
                            LastName = "Sukonnik",
                            Password = "admin",
                            RefreshToken = "",
                            RefreshTokenExp = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Role = "Admin",
                            Salt = ""
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(1990, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "joe.doe@example.com",
                            FirstName = "Joe",
                            Gender = "Male",
                            LastName = "Doe",
                            Password = "password123",
                            RefreshToken = "",
                            RefreshTokenExp = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Role = "User",
                            Salt = ""
                        },
                        new
                        {
                            Id = 3,
                            BirthDate = new DateTime(1998, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "may.chase@example.com",
                            FirstName = "May",
                            Gender = "Female",
                            LastName = "Chase",
                            Password = "mypassword",
                            RefreshToken = "",
                            RefreshTokenExp = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Role = "User",
                            Salt = ""
                        },
                        new
                        {
                            Id = 4,
                            BirthDate = new DateTime(1988, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "allen.smith@example.com",
                            FirstName = "Allen",
                            Gender = "Non-Binary",
                            LastName = "Smith",
                            Password = "securepass",
                            RefreshToken = "",
                            RefreshTokenExp = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Role = "User",
                            Salt = ""
                        },
                        new
                        {
                            Id = 5,
                            BirthDate = new DateTime(1992, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "piotr.kowalik@example.com",
                            FirstName = "Piotr",
                            Gender = "Male",
                            LastName = "Kowalik",
                            Password = "peter123",
                            RefreshToken = "",
                            RefreshTokenExp = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Role = "User",
                            Salt = ""
                        },
                        new
                        {
                            Id = 6,
                            BirthDate = new DateTime(2001, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "anna.kravets@example.com",
                            FirstName = "Anna",
                            Gender = "Female",
                            LastName = "Kravets",
                            Password = "anna2024",
                            RefreshToken = "",
                            RefreshTokenExp = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Role = "User",
                            Salt = ""
                        },
                        new
                        {
                            Id = 7,
                            BirthDate = new DateTime(1985, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "victor.belov@example.com",
                            FirstName = "Victor",
                            Gender = "Male",
                            LastName = "Belov",
                            Password = "vbelov2024",
                            RefreshToken = "",
                            RefreshTokenExp = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Role = "User",
                            Salt = ""
                        },
                        new
                        {
                            Id = 8,
                            BirthDate = new DateTime(1995, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "emma.taylor@example.com",
                            FirstName = "Emma",
                            Gender = "Female",
                            LastName = "Taylor",
                            Password = "emmataylor",
                            RefreshToken = "",
                            RefreshTokenExp = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Role = "User",
                            Salt = ""
                        },
                        new
                        {
                            Id = 9,
                            BirthDate = new DateTime(1999, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "liam.nguyen@example.com",
                            FirstName = "Liam",
                            Gender = "Male",
                            LastName = "Nguyen",
                            Password = "liamnguyen",
                            RefreshToken = "",
                            RefreshTokenExp = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Role = "User",
                            Salt = ""
                        },
                        new
                        {
                            Id = 10,
                            BirthDate = new DateTime(2003, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "sofia.hernandez@example.com",
                            FirstName = "Sofia",
                            Gender = "Female",
                            LastName = "Hernandez",
                            Password = "sofia2023",
                            RefreshToken = "",
                            RefreshTokenExp = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Role = "User",
                            Salt = ""
                        });
                });

            modelBuilder.Entity("GameStore.Models.Purchase", b =>
                {
                    b.HasOne("GameStore.Models.Game", "Game")
                        .WithMany("Purchases")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameStore.Models.User", "User")
                        .WithMany("Purchases")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GameStore.Models.Game", b =>
                {
                    b.Navigation("Purchases");
                });

            modelBuilder.Entity("GameStore.Models.User", b =>
                {
                    b.Navigation("Purchases");
                });
#pragma warning restore 612, 618
        }
    }
}