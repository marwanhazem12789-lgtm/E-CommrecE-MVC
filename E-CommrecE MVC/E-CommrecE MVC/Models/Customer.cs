using System.ComponentModel.DataAnnotations;

namespace E_CommrecE_MVC.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
       
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
