
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Interfaces;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Testing.ViewTesting
{
    // TODO: Mock this up
    public class FakeStorage : IStorageDAO
    {
        private MainViewTests _Caller { get; set; }
        public FakeStorage(MainViewTests caller)
        {
            // TODO: I'm probably going to want to change this into
            //      a callback design to decouple it from MainViewTests
            // Save caller
            _Caller = caller;
        }
        public Order CreateOrder(Customer customer, Store store, List<Product> products)
        {
            _Caller.Notify("CreateOrder");
            return null;
        }

        public List<Customer> GetCustomers()
        {
            throw new System.NotImplementedException();
        }

        public List<Order> GetOrders()
        {
            throw new System.NotImplementedException();
        }

        public List<Order> GetOrders(Store store)
        {
            throw new System.NotImplementedException();
        }

        public List<Order> GetOrders(Customer customer)
        {
            throw new System.NotImplementedException();
        }

        public List<Product> GetProducts()
        {
            throw new System.NotImplementedException();
        }

        public List<Store> GetStores()
        {
            throw new System.NotImplementedException();
        }
    }
}