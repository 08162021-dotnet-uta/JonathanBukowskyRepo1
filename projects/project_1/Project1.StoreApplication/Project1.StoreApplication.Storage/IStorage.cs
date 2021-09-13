using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project1.StoreApplication.Models;

namespace Project1.StoreApplication.Storage
{
    /// <summary>
    /// Interface for saving/loading program data in persistent storage
    /// </summary>
    public interface IStorage
    {
        // TODO: change these to use model objects instead of db objects

        /// <summary>
        /// Get list of all products
        /// </summary>
        /// <returns></returns>
        Task<List<Product>> GetProducts();
        Task<bool> AddProduct(Product product);

        /// <summary>
        /// Get list of all stores
        /// </summary>
        /// <returns></returns>
        Task<List<Store>> GetStores();
        Task<bool> AddStore(Store store);

        /// <summary>
        /// Get list of all customers
        /// </summary>
        /// <returns></returns>
        Task<List<Customer>> GetCustomers();
        Task<bool> AddCustomer(Customer customer);

        /// <summary>
        /// Get list of all orders
        /// </summary>
        /// <returns></returns>
        Task<List<Order>> GetOrders();

        /// <summary>
        /// Get list of all orders associated with specific store
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        Task<List<Order>> GetOrders(Store store);

        /// <summary>
        /// Get list of all orders associated with specific customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        Task<List<Order>> GetOrders(Customer customer);
        // TODO: consider throwing errors instead of bool return value to provide better feedback on why failure occurred?
        //      perhaps return an int or something else like that?

        /// <summary>
        /// Create an order
        /// </summary>
        /// <param name="customer">Customer making order</param>
        /// <param name="store">Store ordered from</param>
        /// <param name="products">Products being ordered</param>
        /// <returns></returns>
        Task<Order> CreateOrder(Customer customer, Store store, List<Product> products);
    }
}
