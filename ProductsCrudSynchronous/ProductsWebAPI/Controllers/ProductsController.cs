using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsWebAPI.Data;
using ProductsWebAPI.Modals;

namespace ProductsWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        ProductDbContext context;

        public ProductsController(ProductDbContext productContext)
        {
            context = productContext;
        }

        [HttpGet]
        public List<Product> Get()
        {
            return context.Products.ToList<Product>();
        }

        [HttpPost]

        public string Post(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return "Product added succesfully";
        }

        [HttpPut]

        public string Update(Product productDetails)
        {
            context.Products.Update(productDetails);
            context.SaveChanges();
            return "Product details updated successfully";
        }

        [HttpDelete]
        public string Delete(int id)
        {
            var productRecord = context.Products.Find(id);

            context.Products.Remove(productRecord);
            context.SaveChanges();
            return "product deleted successfully";
        }
    }
}

