using GameStore.Models;

namespace GameStore.DTOs;

public class GetUserFullDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Email { get; set; }
    public string Role { get; set; } 
    public string Gender { get; set; }
    public List<GetPurchaseFullDTO> Purchases { get; set; }
}