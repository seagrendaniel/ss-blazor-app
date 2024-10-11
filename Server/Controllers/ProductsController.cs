using Microsoft.AspNetCore.Mvc;
using ssCRUDapp.Shared;
using System.Collections.Generic;
using System.Linq;

namespace ssCRUDapp.Server.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProductsController : ControllerBase {
    private static List<Product> products = new List<Product>
    {
      new Product { Id = Guid.NewGuid(), Name = "Product 1", Quantity = 1, Price = 9.99m },
      new Product { Id = Guid.NewGuid(), Name = "Product 2", Quantity = 3, Price = 3.99m }
    };

    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetProducts()
    {
      return Ok(products);
    }

    [HttpPost]
    public ActionResult<Product> CreateProduct(Product product)
    {
      product.Id = Guid.NewGuid();
      products.Add(product);
      return CreatedAtAction(nameof(GetProducts), new {id = product.Id}, product);
    }
  }
}