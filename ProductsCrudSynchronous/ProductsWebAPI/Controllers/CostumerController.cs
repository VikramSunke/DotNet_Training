using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsWebAPI.Data;
using ProductsWebAPI.Modals;

namespace ProductsWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostumerController : ControllerBase
    {

        ProductDbContext context;

        public CostumerController(ProductDbContext productContext)
        {
            context = productContext;
        }

        [HttpGet]
        public List<Costumer> Get()
        {
            return context.Costumers.ToList<Costumer>();
        }

        [HttpPost]

        public string Post(Costumer costumer)
        {
            context.Costumers.Add(costumer);
            context.SaveChanges();
            return "Costumer added succesfully";
        }

        [HttpPut]

        public string Update(Costumer costumerDetails)
        {
            context.Costumers.Update(costumerDetails);
            context.SaveChanges();
            return "Costumer details updated successfully";
        }

        [HttpDelete]
        public string Delete(int id)
        {
            var costumerRecord = context.Costumers.Find(id);

            context.Costumers.Remove(costumerRecord);
            context.SaveChanges();
            return "Costumer deleted successfully";
        }
    }
}
