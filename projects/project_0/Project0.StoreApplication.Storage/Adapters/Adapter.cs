
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Storage.Adapters
{
    public abstract class Adapter
    {
        public abstract void SaveAll<T>(List<T> products, string path);
        public abstract List<T> LoadAll<T>(string path);
        /*
        public abstract List<Store> LoadStores();
        public abstract List<Product> LoadProducts();
        public abstract List<Order> LoadOrders();
        public abstract List<Customer> LoadCustomers();
        */
    }
}