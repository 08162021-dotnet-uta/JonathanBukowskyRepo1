
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Interfaces;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Adapters;

namespace Project0.StoreApplication.Storage
{
    public class DBStorageImpl : IStorage
    {
        private readonly DBAdapter _db = new();

        public Order CreateOrder(Customer customer, Store store, List<Product> products)
        {
            // TODO: validation
            if (customer == null)
            {
                return null;
            }
            if (store == null)
            {
                return null;
            }
            if (products == null)
            {
                return null;
            }
            _db.Database.ExecuteSqlRaw("INSERT INTO Store.Order (CustomerID, StoreID, OrderDate) VALUES ({0}, {1}, NOW())", customer.CustomerID, store.StoreID);
            _db.SaveChanges();
            // TODO: Check for success/failure
            // TODO: this is not safe for concurrent use
            var ords = _db.Orders.FromSqlRaw(
                    "SELECT * FROM Store.Order WHERE CustomerID={} AND StoreID={} ORDER BY OrderDate DESC",
                    customer.CustomerID,
                    store.StoreID
                ).ToList();
            return ords[0];
        }

        public List<Customer> GetCustomers()
        {
            var custs = _db.Customers.FromSqlRaw("SELECT * FROM Customer.Customer").ToList();
            return custs;
        }


        private static readonly string _orderSubQuery =
            "SELECT p.* " +
            "FROM Store.OrderProduct AS op " +
            "INNER JOIN Store.Product AS p " +
                "ON p.ProductID = op.ProductID " +
            "WHERE op.OrderID = {0}";
        private void AttachProductsToOrder(Order order)
        {
            order.Products = _db.Products.FromSqlRaw(_orderSubQuery, order.OrderID).ToList();
        }
        public List<Order> GetOrders()
        {
            var ords = _db.Orders.FromSqlRaw("SELECT * FROM Store.Order").ToList();
            foreach (var order in ords)
            {
                AttachProductsToOrder(order);
            }
            return ords;
        }

        public List<Order> GetOrders(Store store)
        {
            var ords = _db.Orders.FromSqlRaw("SELECT * FROM Store.Order WHERE StoreID={}", store.StoreID).ToList();
            foreach (var order in ords)
            {
                AttachProductsToOrder(order);
            }
            return ords;
        }

        public List<Order> GetOrders(Customer customer)
        {
            var ords = _db.Orders.FromSqlRaw("SELECT * FROM Store.Order WHERE CustomerID={}", customer.CustomerID).ToList();
            foreach (var order in ords)
            {
                AttachProductsToOrder(order);
            }
            return ords;
        }

        public List<Product> GetProducts()
        {
            var prods = _db.Products.FromSqlRaw("SELECT * FROM Store.Products").ToList();
            return prods;
        }

        public List<Store> GetStores()
        {
            var stores = _db.Stores.FromSqlRaw("SELECT * FROM Store.Store").ToList();
            return stores;
        }

        /*
        public void SetCustomer(Customer customer)
        {
            //_customerAdapter.Customer.Add(customer);
            _customerAdapter.Database.ExecuteSqlRaw("INSERT INTO Customer.Customer ([Name]) VALUES ({0})", customer.Name);
            _customerAdapter.SaveChanges();
        }
        */
    }
}