using System.Collections.Generic;
using Project0.StoreApplication.Domain.Abstracts;
namespace Project0.StoreApplication.Domain.Models
{
    public class Order
    {
        public Customer Customer { get; set; }
        public List<Product> Products { get; set; }
        public Store Store { get; set; }
    }
}