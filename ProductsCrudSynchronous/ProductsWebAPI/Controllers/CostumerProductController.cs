using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ProductsWebAPI.Data;
using ProductsWebAPI.Modals;

namespace ProductsWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostumerProductController : ControllerBase
    {
        ProductDbContext context;

        public CostumerProductController(ProductDbContext productContext)
        {
            context = productContext;
        }

        //List<CostProduct> costProducts = new List<CostProduct>();
        [HttpGet]
        public List<CostumerProduct> Get()
        {
            return context.CostumerProducts.ToList<CostumerProduct>();
        }

        [HttpPost]

        public string Post(CostumerProduct costumerProduct)
        {
            context.CostumerProducts.Add(costumerProduct);
            context.SaveChanges();
            //costProducts.Add(costumerProduct);
            return "Costumer added new Product Successfully";
        }

        [HttpPut]

        public string Update(CostumerProduct costumerProductDetails)
        {
            context.CostumerProducts.Update(costumerProductDetails);
            context.SaveChanges();
            return "Costumer modified product details";
        }

        [HttpDelete]
        public string Delete(int id)
        {
            var costumerProductRecord = context.CostumerProducts.Find(id);

            context.CostumerProducts.Remove(costumerProductRecord);
            context.SaveChanges();
            return "Costumer deleted product successfully";
        }



        [HttpGet("CustomerProducts/{customerId}")]
        public IActionResult GetCustomerProducts(int customerId)
        {
            var customerProductInfos = GetCustomerProductInfos();

            var productsForCustomer = customerProductInfos.FindAll(c => c.CustomerID == customerId);

            return Ok(productsForCustomer);
        }


        [HttpGet("CustomerProducts")]
        public IActionResult GetAllCustomerProducts()
        {
            var customerProductInfos = GetCustomerProductInfos();

            return Ok(customerProductInfos);
        }

        //private List<CustProdDetails> GetCustomerProductInfos()
        //{
        //    var customerProducts = context.CostumerProducts.ToList();
        //    var customerProductInfos = new List<CustProdDetails>();

        //    foreach (var costumerProduct in customerProducts)
        //    {
        //        var costumer = context.Costumers.Find(costumerProduct.CId);
        //        var product = context.Products.Find(costumerProduct.PId);

        //        if (costumer != null && product != null)
        //        {
        //            var customerProductInfo = new CustProdDetails
        //            {
        //                CustomerID = costumer.Id,
        //                CustomerName = costumer.CName,
        //                ProductId = product.PId,
        //                ProductName = product.PName,
        //            };

        //            customerProductInfos.Add(customerProductInfo);
        //        }
        //    }

        //    return customerProductInfos;
        //}

        private List<CustProdDetails> GetCustomerProductInfos()
        {
            var customerProductInfos = new List<CustProdDetails>();
            var customerProducts = context.CostumerProducts.ToList();
            var customers = context.Costumers.ToList();
            var products = context.Products.ToList();
            
            foreach (var customer in customers)
            {
                var customerProductsForCurrentCustomer = customerProducts.Where(cp => cp.CId == customer.Id);

                var customerProductInfo = new CustProdDetails
                {
                    CustomerID = customer.Id,
                    CustomerName = customer.CName
                };
                foreach (var costumerProduct in customerProductsForCurrentCustomer)
                {
                    var product = products.Find(p => p.PId == costumerProduct.PId);

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

