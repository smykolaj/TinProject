using System.ComponentModel.DataAnnotations;

namespace GameStore.Models;

public class User
{
    [Key] public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Email { get; set; }
    public string Password { get; set; } = string.Empty;
    public string Salt { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
    public DateTime RefreshTokenExp { get; set; }
    public string Role { get; set; } = string.Empty;
    public string Gender { get; set; }
    public ICollection<Purchase> Purchases { get; set; }
}