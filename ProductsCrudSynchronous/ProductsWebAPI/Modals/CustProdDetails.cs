using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ProductsWebAPI.Modals
{
    public class CustProdDetails
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public List<Product> Products { get; set; } // List of products for the customer

        public CustProdDetails()
        {
            Products = new List<Product>(); // Initialize the Products list in the constructor
        }

    }
}
