using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AttributeRouting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static readonly List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Product1", Category = "Category1" },
            new Product { Id = 2, Name = "Product2", Category = "Category2" },
            new Product { Id = 3, Name = "Product3", Category = "Category1" }
        };

        // GET: api/products
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_products);
        }

        // GET: api/products/{id}
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // GET: api/products/category/{category}
        [HttpGet("category/{category}")]
        public IActionResult GetProductsByCategory(string category)
        {
            var products = _products.Where(p => p.Category == category).ToList();
            if (!products.Any())
            {
                return NotFound();
            }
            return Ok(products);
        }

        // POST: api/products
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            product.Id = _products.Max(p => p.Id) + 1; // creating new id
            _products.Add(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        // POST: api/products/bulk
        [HttpPost("bulk")]
        public IActionResult CreateProductsBulk(List<Product> products)
        {
            var maxId = _products.Max(p => p.Id);
            foreach (var product in products)
            {
                product.Id = ++maxId;
                _products.Add(product);
            }
            return Created("api/products/bulk", products);
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
    }
}
