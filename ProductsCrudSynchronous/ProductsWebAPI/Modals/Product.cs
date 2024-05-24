using System.ComponentModel.DataAnnotations;

namespace ProductsWebAPI.Modals
{
    public class Product
    {
        [Key]
        public int PId { get; set; }

        public string PName { get; set; }
        public decimal PPrice { get; set; }

        
        //public int PQuantity { get; set; }
    }
}
