using System.Text.Json;
using appRedis.Domain.Entities;
using appRedis.Infra.Caching;
using appRedis.Infra.Data;
using appRedis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace appRedis.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(
    ICachingService cache,
    ProductDbContext context
)
    : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var productCache = await cache.Get(id.ToString());
        Product? product;

        if (!string.IsNullOrWhiteSpace(productCache))
        {
            product = JsonSerializer.Deserialize<Product>(productCache);

            Console.WriteLine("Loadded from cache.");

            return Ok(product);
        }

        product = await context.Products.SingleOrDefaultAsync(t => t.Id == id);

        if (product == null)
            return NotFound();

        await cache.Set(id.ToString(), JsonSerializer.Serialize(product));

        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Post(ProductInputModel model)
    {
        var product = new Product(0, model.Description, model.Price);

        await context.Products.AddAsync(product);
        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new {id = product.Id}, model);
    }
}