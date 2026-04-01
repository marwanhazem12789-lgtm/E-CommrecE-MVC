namespace E_CommrecE_MVC.Models
{
    public class OrderCustomer
    {
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public int selectedCustomerId { get; set; }
        public List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}
