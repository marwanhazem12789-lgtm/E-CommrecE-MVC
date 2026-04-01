using System.ComponentModel.DataAnnotations;

namespace E_CommrecE_MVC.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public DateOnly  OrderDate { get; set; }    
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } 
        public List<Product> products { get; set; } = new List<Product>();

    }
}
