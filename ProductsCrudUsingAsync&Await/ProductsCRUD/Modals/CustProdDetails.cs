namespace ProductsCRUD.Modals
{
    public class CustProdDetails
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public List<Product> Products { get; set; } 
        public CustProdDetails()
        {
            Products = new List<Product>(); 
        }
    }
}
