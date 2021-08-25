
using System.Collections.Generic;

/// <summary>
/// Contains interfaces for interacting with persistent storage
/// </summary>
namespace Project0.StoreApplication.Storage.Adapters
{
    /// <summary>
    /// Base class to provide interface for saving/loading data from persistent storage
    /// </summary>
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