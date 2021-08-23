
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Storage
{
    // This interface would serve as the API for accessing program data -- I'm not sure if I want to use it
    public interface StorageDAO
    {
        List<Product> GetProducts();
        //bool AddProduct(Product product);
        List<Store> GetStores();
        //bool AddStore(Store store);
        List<Customer> GetCustomers();
        //bool AddCustomer(Customer customer);
        List<Order> GetOrders();
        List<Order> GetOrders(Store store);
        List<Order> GetOrders(Customer customer);
        // TODO: consider throwing errors instead of bool return value to provide better feedback on why failure occurred?
        //      perhaps return an int or something else like that?
        bool CreateOrder(Customer customer, Store store, List<Product> products);
    }
}