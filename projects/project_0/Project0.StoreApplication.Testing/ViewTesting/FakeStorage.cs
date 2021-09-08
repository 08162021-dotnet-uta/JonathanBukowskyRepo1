
using System;
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Interfaces;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Testing.ViewTesting
{
    // TODO: Mock this up
    public class FakeStorage : IStorage
    {
        public bool ReturnNull { get; set; }
        public FakeStorage()
        {
            ReturnNull = false;
        }
        public Order CreateOrder(Customer customer, Store store, List<Product> products)
        {
            if (ReturnNull)
            {
                return null;
            }
            return new Order(customer, store, products);
        }

        public List<Customer> GetCustomers()
        {
            if (ReturnNull)
            {
                return null;
            }
            return new List<Customer>()
            {
                new Customer() { CustomerID = 1, Name = "Johnny" },
                new Customer() { CustomerID = 2, Name = "Shawna" }
            };
        }

        public List<Order> GetOrders()
        {
            if (ReturnNull)
            {
                return null;
            }
            var customers = GetCustomers();
            var stores = GetStores();
            var products = GetProducts();
            return new List<Order>()
            {
                new Order(customers[0], stores[1], new() { products[0], products[1] }),
                new Order(customers[1], stores[0], new() { products[1], products[2] })
            };
        }

        public List<Order> GetOrders(Store store)
        {
            if (ReturnNull)
            {
                return null;
            }
            return GetOrders().FindAll((Order o) => o.Store == store);
        }

        public List<Order> GetOrders(Customer customer)
        {
            if (ReturnNull)
            {
                return null;
            }
            return GetOrders().FindAll((Order o) => o.Customer == customer);
        }

        public List<Product> GetProducts()
        {
            if (ReturnNull)
            {
                return null;
            }
            return new List<Product>()
            {
                new Product() { ProductID = 1, Name = "Cheeseburger" },
                new Product() { ProductID = 2, Name = "Chicken Nuggets"},
                new Product() { ProductID = 2, Name = "Filet O' Fish"}
            };
        }

        public List<Store> GetStores()
        {
            if (ReturnNull)
            {
                return null;
            }
            return new List<Store>()
            {
                new GroceryStore() { StoreID = 1, Name = "Wendy's"},
                new GroceryStore() { StoreID = 2, Name = "Burger King"}
            };
        }
    }
}