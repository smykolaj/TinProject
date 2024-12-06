namespace GameStore.DTOs;

public class GetPurchaseFullDTO
{ 
    public int Id { get; set; }
    public int UserId { get; set; }
    public int GameId { get; set; }
    public DateTime PurchaseDate { get; set; }
}