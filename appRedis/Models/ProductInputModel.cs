namespace appRedis.Models;

public class ProductInputModel
{
    public required string Description { get; set; }
    public decimal Price { get; set; }
}