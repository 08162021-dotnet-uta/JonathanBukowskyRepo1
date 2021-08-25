
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Domain.Interfaces
{
    // This interface would serve as the API for accessing program data -- I'm not sure if I want to use it
    /// <summary>
    /// Interface for saving/loading program data in persistent storage
    /// </summary>
    public interface IStorageDAO
    {
        /// <summary>
        /// Get list of all products
        /// </summary>
        /// <returns></returns>
        List<Product> GetProducts();
        //bool AddProduct(Product product);

        /// <summary>
        /// Get list of all stores
        /// </summary>
        /// <returns></returns>
        List<Store> GetStores();
        //bool AddStore(Store store);

        /// <summary>
        /// Get list of all customers
        /// </summary>
        /// <returns></returns>
        List<Customer> GetCustomers();
        //bool AddCustomer(Customer customer);

        /// <summary>
        /// Get list of all orders
        /// </summary>
        /// <returns></returns>
        List<Order> GetOrders();

        /// <summary>
        /// Get list of all orders associated with specific store
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        List<Order> GetOrders(Store store);

        /// <summary>
        /// Get list of all orders associated with specific customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        List<Order> GetOrders(Customer customer);
        // TODO: consider throwing errors instead of bool return value to provide better feedback on why failure occurred?
        //      perhaps return an int or something else like that?

        /// <summary>
        /// Create an order
        /// </summary>
        /// <param name="customer">Customer making order</param>
        /// <param name="store">Store ordered from</param>
        /// <param name="products">Products being ordered</param>
        /// <returns></returns>
        Order CreateOrder(Customer customer, Store store, List<Product> products);
    }
}