
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Domain.Interfaces;
using Project0.StoreApplication.Storage.Repositories;

namespace Project0.StoreApplication.Storage
{
    public class XmlFileStorage : IStorageDAO
    {
        public bool CreateOrder(Customer customer, Store store, List<Product> products)
        {
            // TODO: Better error checking for caller? assume caller validated data?
            if (customer == null)
            {
                //Console.WriteLine("You must select a customer");
                return false;
            }
            else if (store == null)
            {
                //Console.WriteLine("You must select a store");
                return false;
            }
            else if (products == null || products.Count == 0)
            {
                //Console.WriteLine("Your cart is empty");
                return false;
            }
            Order o = new Order(customer, store, products);
            var repo = OrderRepository.Factory();
            repo.Orders.Add(o);
            repo.SaveOrders();
            // TODO: actually check on whether save succeeded
            //Console.WriteLine("Order saved successfully");
            return true;
        }

        public List<Customer> GetCustomers()
        {
            return CustomerRepository.Factory().Customers;
        }

        public List<Order> GetOrders()
        {
            return OrderRepository.Factory().Orders;
        }

        public List<Order> GetOrders(Store store)
        {
            return OrderRepository.Factory().Orders.FindAll((Order o) => o.Store == store);
        }

        public List<Order> GetOrders(Customer customer)
        {
            return OrderRepository.Factory().Orders.FindAll((Order o) => o.Customer == customer);
        }

        public List<Product> GetProducts()
        {
            var pr = ProductRepository.Factory();
            return pr.Products;
        }

        public List<Store> GetStores()
        {
            return StoreRepository.Factory().Stores;
        }
    }
}