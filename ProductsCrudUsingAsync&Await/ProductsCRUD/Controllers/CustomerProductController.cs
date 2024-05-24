using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsCRUD.Data;
using ProductsCRUD.Modals;
using System.Linq;

namespace ProductsCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerProductController : ControllerBase
    {
        ProductDbContext context;

        public CustomerProductController(ProductDbContext productContext)
        {
            context = productContext;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerProduct>>> Get()
        {
            return await context.CustomerProducts.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<CustomerProduct>> Post(CustomerProduct customerProduct)
        {
            context.CustomerProducts.Add(customerProduct);
            await context.SaveChangesAsync();
            //costProducts.Add(costumerProduct);
            return customerProduct;
        }
        [HttpPut]

        public async Task<ActionResult<CustomerProduct>> Update(CustomerProduct customerProductDetails)
        {
            context.CustomerProducts.Update(customerProductDetails);
            await context.SaveChangesAsync();
            return customerProductDetails;
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var costumerProductRecord = await context.CustomerProducts.FindAsync(id);

            context.CustomerProducts.Remove(costumerProductRecord);
            await context.SaveChangesAsync();
            return NoContent();
        }


        [HttpGet("CustomerProducts/{customerId}")]
        public async Task<IActionResult> GetCustomerProducts(int customerId)
        {
            var customerProductsList = await GetCustomerProductsInfos();
            return Ok(customerProductsList);
        }

        [HttpGet("CustomerProducts")]
        public async Task<IActionResult> GetAllCustomerProducts()
        {
            var customerProductsList = await GetCustomerProductsInfos();
            return Ok(customerProductsList);
        }

        private async Task<List<CustProdDetails>> GetCustomerProductsInfos()
        {
            var customerProductInfos = new List<CustProdDetails>();
            var customerProducts = await context.CustomerProducts.ToListAsync();
            var customers = await context.Customers.ToListAsync();
            var products = await context.Products.ToListAsync();

            foreach (var customer in customers)
            {
                var currentCustomerProducts = customerProducts.Where(cp => cp.CId == customer.Id);

                var customerProductInfo = new CustProdDetails
                {
                    CustomerID = customer.Id,
                    CustomerName = customer.CName
                };

                foreach (var customerProduct in currentCustomerProducts)
                {
                    var product = products.Find(p => p.Id == customerProduct.PId);

                    if (product != null)
                    {
                        customerProductInfo.Products.Add(product);
                    }
                }
                customerProductInfos.Add(customerProductInfo);
            }
            return customerProductInfos;
        }

    }
}
