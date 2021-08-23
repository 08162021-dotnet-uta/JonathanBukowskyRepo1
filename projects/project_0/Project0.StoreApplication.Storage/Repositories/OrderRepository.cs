
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Domain.Settings;

namespace Project0.StoreApplication.Storage.Repositories
{
    public class OrderRepository : DataRepository<OrderXML>
    {
        public List<Order> Orders { get; set; }

        private List<Order> _GetOrders()
        {
            return Data.ConvertAll((OrderXML oXML) => oXML.GetOrder());
        }
        private void _SetOrders(List<Order> orders)
        {
            Data = orders.ConvertAll((Order o) => new OrderXML(o));
        }


        protected static OrderRepository _repo = null;
        public static OrderRepository Factory() { return (_repo ??= new OrderRepository()); }
        internal OrderRepository()
        {
            // Load()
            LoadOrders();
        }

        public void SaveOrders()
        {
            _SetOrders(Orders);
            Save();
        }

        public void LoadOrders()
        {
            Load();
            Orders = _GetOrders();
        }

        protected override string GetDataFile()
        {
            return AppSettings.Settings.GetOrdersFile();
        }
    }


    // I had to make this public because of the inheritance? TODO: Look into this, re-evaluate structure
    public class OrderXML
    {
        public int Customer { get; set; }
        public int Store { get; set; }
        public List<int> Products { get; set; }
        public OrderXML() : base() { }
        public OrderXML(Order order)
        {
            var customers = CustomerRepository.Factory().Customers;
            var stores = StoreRepository.Factory().Stores;
            var products = ProductRepository.Factory().Products;
            Customer = customers.IndexOf(order.Customer);
            Store = stores.IndexOf(order.Store);
            Products = new();
            foreach (var prod in order.Products)
            {
                Products.Add(products.IndexOf(prod));
            }
        }
        public Order GetOrder()
        {
            var customers = CustomerRepository.Factory().Customers;
            var stores = StoreRepository.Factory().Stores;
            var products = ProductRepository.Factory().Products;
            List<Product> prods = new();
            foreach (var prodIdx in Products)
            {
                prods.Add(products[prodIdx]);
            }
            return new Order(customers[Customer], stores[Store], prods);
        }
    }
}