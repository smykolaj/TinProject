using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameStore.Migrations
{
    /// <inheritdoc />
    public partial class UserFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Users",
                newName: "Salt");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "Users",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExp",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Author", "Genre", "Name", "Price", "ReleaseDate" },
                values: new object[,]
                {
                    { 1, "GSC Game World", "Action, Survival", "STALKER", 19.99m, new DateTime(2007, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "FromSoftware", "Action RPG", "Dark Souls", 39.99m, new DateTime(2011, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Team Cherry", "Metroidvania", "Hollow Knight", 14.99m, new DateTime(2017, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Epic Games", "Battle Royale", "Fortnite", 0.00m, new DateTime(2017, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Mojang Studios", "Sandbox, Survival", "Minecraft", 29.99m, new DateTime(2011, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "CD Projekt Red", "Action RPG", "The Witcher 3", 49.99m, new DateTime(2015, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "CD Projekt Red", "Action RPG", "Cyberpunk 2077", 59.99m, new DateTime(2020, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Maddy Makes Games", "Platformer", "Celeste", 19.99m, new DateTime(2018, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "FromSoftware", "Action RPG", "Elden Ring", 59.99m, new DateTime(2022, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "Valve", "Puzzle", "Portal 2", 9.99m, new DateTime(2011, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "Email", "FirstName", "Gender", "LastName", "Password", "RefreshToken", "RefreshTokenExp", "Role", "Salt" },
                values: new object[,]
                {
                    { 1, new DateTime(2005, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "smykolka@gmail.com", "Mykola", "Male", "Sukonnik", "admin", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", "" },
                    { 2, new DateTime(1990, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "joe.doe@example.com", "Joe", "Male", "Doe", "password123", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "" },
                    { 3, new DateTime(1998, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "may.chase@example.com", "May", "Female", "Chase", "mypassword", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "" },
                    { 4, new DateTime(1988, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "allen.smith@example.com", "Allen", "Non-Binary", "Smith", "securepass", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "" },
                    { 5, new DateTime(1992, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "piotr.kowalik@example.com", "Piotr", "Male", "Kowalik", "peter123", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "" },
                    { 6, new DateTime(2001, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "anna.kravets@example.com", "Anna", "Female", "Kravets", "anna2024", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "" },
                    { 7, new DateTime(1985, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "victor.belov@example.com", "Victor", "Male", "Belov", "vbelov2024", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "" },
                    { 8, new DateTime(1995, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "emma.taylor@example.com", "Emma", "Female", "Taylor", "emmataylor", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "" },
                    { 9, new DateTime(1999, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "liam.nguyen@example.com", "Liam", "Male", "Nguyen", "liamnguyen", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "" },
                    { 10, new DateTime(2003, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "sofia.hernandez@example.com", "Sofia", "Female", "Hernandez", "sofia2023", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "" }
                });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "GameId", "PurchaseDate", "UserId" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 4, new DateTime(2023, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, 1, new DateTime(2023, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, 5, new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 5, 3, new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 6, 6, new DateTime(2023, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 7, 7, new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 8, 9, new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 9, 8, new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 10, 10, new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExp",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Salt",
                table: "Users",
                newName: "PasswordHash");
        }
    }
}
