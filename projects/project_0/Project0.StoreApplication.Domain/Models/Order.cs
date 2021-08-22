using System.Collections.Generic;
using Project0.StoreApplication.Domain.Abstracts;
namespace Project0.StoreApplication.Domain.Models
{
    public class Order
    {
        public Order(Customer customer, Store store, List<Product> products)
        {
            Customer = customer;
            Products = products;
            Store = store;
        }
        public Customer Customer { get; }
        public List<Product> Products { get; }
        public Store Store { get; }
    }
}