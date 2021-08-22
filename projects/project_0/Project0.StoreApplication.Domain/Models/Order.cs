using System.Collections.Generic;
using Project0.StoreApplication.Domain.Abstracts;
namespace Project0.StoreApplication.Domain.Models
{
    public class Order
    {
        public Order(Customer customer, Store store, List<Product> products)
        {
            Customer = customer;
            Products = new(products);
            Store = store;
        }
        public Customer Customer { get; }
        public List<Product> Products { get; }
        public Store Store { get; }

        public override string ToString()
        {
            string output = "Order:\n\tCustomer: " + Customer + "\n\tStore: " + Store + "\n\tItems:\n";
            foreach (var product in Products)
            {
                output += "\t\t" + product + "\n";
            }
            return output;
        }
    }
}