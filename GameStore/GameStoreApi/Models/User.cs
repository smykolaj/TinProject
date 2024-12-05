namespace GameStore.Models;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Gender { get; set; }
    public ICollection<Purchase> Purchases { get; set; }
}