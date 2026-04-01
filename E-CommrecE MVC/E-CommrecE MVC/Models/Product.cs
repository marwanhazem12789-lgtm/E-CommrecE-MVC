using System.ComponentModel.DataAnnotations;

namespace E_CommrecE_MVC.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
