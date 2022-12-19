namespace Code.Models;

public class ProductDTO
{
    public string Name { get; set; } = default!;
    public int Quantity { get; set; }
    public int ManufacturerId { get; set; }
}