
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Storage.Adapters
{
    public abstract class Adapter
    {
        public abstract void Save(List<Product> products);
        public abstract void Save(List<Store> stores);
        public abstract void Save(List<Order> orders);
        public abstract void Save(List<Customer> customers);
        public abstract List<Store> LoadStores();
        public abstract List<Product> LoadProducts();
        public abstract List<Order> LoadOrders();
        public abstract List<Customer> LoadCustomers();
    }
}