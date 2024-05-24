using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsCRUD.Data;
using ProductsCRUD.Modals;

namespace ProductsCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ProductDbContext context;

        public CustomerController(ProductDbContext productContext)
        {
            context = productContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> Get()
        {
            return await context.Customers.ToListAsync();
        }

        [HttpPost]

        public async Task<ActionResult<Customer>> Post(Customer customer)
        {
            context.Customers.Add(customer);
            await context.SaveChangesAsync();
            return customer;
        }
        [HttpPut]

        public async Task<ActionResult<Customer>> Update(Customer customerDetails)
        {
            context.Entry(customerDetails).State = EntityState.Modified;
            //context.Customers.Update(customerDetails);
            await context.SaveChangesAsync();
            return customerDetails;
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var customerRecord = await context.Customers.FindAsync(id);

            context.Customers.Remove(customerRecord);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
