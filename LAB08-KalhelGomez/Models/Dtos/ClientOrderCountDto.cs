namespace LAB08_KalhelGomez.Models.Dtos;

public class ClientOrderCountDto
{
    public int ClientId { get; set; }
    public string ClientName { get; set; } = string.Empty;
    public int OrderCount { get; set; }
}
