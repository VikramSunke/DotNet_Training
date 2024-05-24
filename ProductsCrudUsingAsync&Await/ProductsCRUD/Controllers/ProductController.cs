using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsCRUD.Data;
using ProductsCRUD.Modals;

namespace ProductsCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ProductDbContext context;

        public ProductController(ProductDbContext productContext)
        {
            context = productContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            return await context.Products.ToListAsync();
        }

        [HttpPost]

        public  async Task<ActionResult<Product>> Post(Product product)
        {
            context.Products.Add(product);
            await context.SaveChangesAsync();
            return product;
        }

        [HttpPut]

        public async Task<ActionResult<Product>> Update(Product productDetails)
        {
            context.Products.Update(productDetails);
            await context.SaveChangesAsync();
            return productDetails;
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var productRecord =await context.Products.FindAsync(id);

            context.Products.Remove(productRecord);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}


