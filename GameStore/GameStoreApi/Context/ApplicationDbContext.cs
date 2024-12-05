using GameStore.Models;
using GameStore.Services;

namespace GameStore;

using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Purchase> Purchases { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Purchase>()
            .HasOne(p => p.User)
            .WithMany(u => u.Purchases)
            .HasForeignKey(p => p.UserId);

        modelBuilder.Entity<Purchase>()
            .HasOne(p => p.Game)
            .WithMany(g => g.Purchases)
            .HasForeignKey(p => p.GameId);

        
        var users = new List<(string FirstName, string LastName, DateTime BirthDate, string Email, string Password, string Role, string Gender)>
        {
            ("Mykola", "Sukonnik", new DateTime(2005, 01, 13), "smykolka@gmail.com", "admin", "Admin", "Male"),
            ("Joe", "Doe", new DateTime(1990, 04, 15), "joe.doe@example.com", "password123", "User", "Male"),
            ("May", "Chase", new DateTime(1998, 11, 20), "may.chase@example.com", "mypassword", "User", "Female"),
            ("Allen", "Smith", new DateTime(1988, 08, 05), "allen.smith@example.com", "securepass", "User", "Non-Binary"),
            ("Piotr", "Kowalik", new DateTime(1992, 07, 12), "piotr.kowalik@example.com", "peter123", "User", "Male"),
            ("Anna", "Kravets", new DateTime(2001, 03, 18), "anna.kravets@example.com", "anna2024", "User", "Female"),
            ("Victor", "Belov", new DateTime(1985, 09, 30), "victor.belov@example.com", "vbelov2024", "User", "Male"),
            ("Emma", "Taylor", new DateTime(1995, 02, 21), "emma.taylor@example.com", "emmataylor", "User", "Female"),
            ("Liam", "Nguyen", new DateTime(1999, 06, 25), "liam.nguyen@example.com", "liamnguyen", "User", "Male"),
            ("Sofia", "Hernandez", new DateTime(2003, 05, 14), "sofia.hernandez@example.com", "sofia2023", "User", "Female")
        };

        modelBuilder.Entity<User>().HasData(users.Select((user, index) =>
        {
            var hashedPasswordAndSalt = JWTService.GetHashedPasswordAndSalt(user.Password);
            return new User
            {
                Id = index + 1,
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = user.BirthDate,
                Email = user.Email,
                Password = hashedPasswordAndSalt.Item1,
                Salt = hashedPasswordAndSalt.Item2,
                Role = user.Role,
                Gender = user.Gender
            };
        }).ToList());
        modelBuilder.Entity<Game>().HasData(new List<Game>
        {
            new () { Id = 1, Name = "STALKER", Author = "GSC Game World", Price = 19.99M, ReleaseDate = new DateTime(2007, 03, 20), Genre = "Action, Survival" },
            new () { Id = 2, Name = "Dark Souls", Author = "FromSoftware", Price = 39.99M, ReleaseDate = new DateTime(2011, 09, 22), Genre = "Action RPG" },
            new () { Id = 3, Name = "Hollow Knight", Author = "Team Cherry", Price = 14.99M, ReleaseDate = new DateTime(2017, 02, 24), Genre = "Metroidvania" },
            new () { Id = 4, Name = "Fortnite", Author = "Epic Games", Price = 0.00M, ReleaseDate = new DateTime(2017, 07, 25), Genre = "Battle Royale" },
            new () { Id = 5, Name = "Minecraft", Author = "Mojang Studios", Price = 29.99M, ReleaseDate = new DateTime(2011, 11, 18), Genre = "Sandbox, Survival" },
            new () { Id = 6, Name = "The Witcher 3", Author = "CD Projekt Red", Price = 49.99M, ReleaseDate = new DateTime(2015, 05, 19), Genre = "Action RPG" },
            new () { Id = 7, Name = "Cyberpunk 2077", Author = "CD Projekt Red", Price = 59.99M, ReleaseDate = new DateTime(2020, 12, 10), Genre = "Action RPG" },
            new () { Id = 8, Name = "Celeste", Author = "Maddy Makes Games", Price = 19.99M, ReleaseDate = new DateTime(2018, 01, 25), Genre = "Platformer" },
            new () { Id = 9, Name = "Elden Ring", Author = "FromSoftware", Price = 59.99M, ReleaseDate = new DateTime(2022, 02, 25), Genre = "Action RPG" },
            new () { Id = 10, Name = "Portal 2", Author = "Valve", Price = 9.99M, ReleaseDate = new DateTime(2011, 04, 19), Genre = "Puzzle" }
        });
        modelBuilder.Entity<Purchase>().HasData(new List<Purchase>
        {
            new () { Id = 1, UserId = 1, GameId = 2, PurchaseDate = new DateTime(2023, 12, 01) },
            new () { Id = 2, UserId = 2, GameId = 4, PurchaseDate = new DateTime(2023, 11, 15) },
            new () { Id = 3, UserId = 3, GameId = 1, PurchaseDate = new DateTime(2023, 10, 05) },
            new () { Id = 4, UserId = 4, GameId = 5, PurchaseDate = new DateTime(2023, 09, 20) },
            new () { Id = 5, UserId = 5, GameId = 3, PurchaseDate = new DateTime(2023, 08, 25) },
            new () { Id = 6, UserId = 6, GameId = 6, PurchaseDate = new DateTime(2023, 07, 14) },
            new () { Id = 7, UserId = 7, GameId = 7, PurchaseDate = new DateTime(2023, 06, 30) },
            new () { Id = 8, UserId = 8, GameId = 9, PurchaseDate = new DateTime(2023, 05, 10) },
            new () { Id = 9, UserId = 9, GameId = 8, PurchaseDate = new DateTime(2023, 04, 18) },
            new () { Id = 10, UserId = 10, GameId = 10, PurchaseDate = new DateTime(2023, 03, 29) }
        });
        base.OnModelCreating(modelBuilder);

    }
}