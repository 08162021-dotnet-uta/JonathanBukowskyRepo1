namespace Project0.StoreApplication.Domain.Models
{
    public class Order
    {
        public Order(Customer customer, Product product, Store store)
        {
            Customer = customer;
            Store = store;
            Product = product;
        }
        public Customer Customer { get; set; }
        public Product Product { get; set; }
        public Store Store { get; set; }
    }
}