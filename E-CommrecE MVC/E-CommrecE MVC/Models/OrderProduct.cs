using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace E_CommrecE_MVC.Models
{
    public class OrderProduct
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
         public decimal Price { get; set; }
        public string Name { get; set; }


    }
}
