namespace LAB08_KalhelGomez.Models.Dtos;

public class OrderProductSummaryDto
{
    public int OrderId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
}
