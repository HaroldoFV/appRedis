namespace appRedis.Domain.Entities;

public class Product
{
    public int Id { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }

    public Product(int id, string description, decimal price)
    {
        Id = id;
        Description = description;
        Price = price;
    }
}