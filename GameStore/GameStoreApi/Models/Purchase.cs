namespace GameStore.Models;

public class Purchase
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int GameId { get; set; }
    public DateTime PurchaseDate { get; set; }
    public User User { get; set; }
    public Game Game { get; set; }
}