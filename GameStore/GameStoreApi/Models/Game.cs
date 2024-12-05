using System.ComponentModel.DataAnnotations;

namespace GameStore.Models;

public class Game
{
    [Key] public int Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public decimal Price { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Genre { get; set; }
    public ICollection<Purchase> Purchases { get; set; } = new HashSet<Purchase>();
}