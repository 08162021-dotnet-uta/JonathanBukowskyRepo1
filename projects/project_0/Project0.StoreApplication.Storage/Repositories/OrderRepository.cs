
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
            return CurrentSettings.Settings.GetOrdersFile();
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
            Customer = order.Customer.CustomerID;
            Store = order.Store.StoreID;
            Products = new();
            foreach (var prod in order.Products)
            {
                Products.Add(prod.ProductID);
            }
        }
        public Order GetOrder()
        {
            var customerRepo = CustomerRepository.Factory();
            var storeRepo = StoreRepository.Factory();
            var productRepo = ProductRepository.Factory();

            var customer = customerRepo.GetCustomer(Customer);
            var store = storeRepo.GetStore(Store);
            List<Product> prods = new();
            foreach (var prodID in Products)
            {
                var product = productRepo.GetProduct(prodID);
                prods.Add(product);
            }
            return new Order(customer, store, prods);
        }
    }
}