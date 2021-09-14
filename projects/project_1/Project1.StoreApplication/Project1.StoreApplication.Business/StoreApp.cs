using Project1.StoreApplication.Models;
using Project1.StoreApplication.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.StoreApplication.Business
{
    public class StoreApp
    {
        private IStorage _db;
        private ICarts _carts;
        public StoreApp(IStorage db, ICarts carts)
        {
            _db = db;
            _carts = carts;
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            // TODO: validation for customer
            var cust = await _db.AddCustomer(customer);
            if (cust == null)
            {
                throw new Exception("Error creating customer");
            }
            return cust;
        }

        public async Task<Product> AddProduct(Product product)
        {
            var prod = await _db.AddProduct(product);
            return prod;
        }

        public async Task<Store> AddStore(Store store)
        {
            var s = await _db.AddStore(store);
            return s;
        }

        public async Task<List<Product>> GetProducts()
        {
            var prods = await _db.GetProducts();
            return prods;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            var custs = await _db.GetCustomers();
            return custs;
        }

        public async Task<List<Product>> GetProductsByStore(Store s)
        {
            var prods = await _db.GetProducts(s);
            return prods;
        }

        public async Task<Customer> LoginCustomer(string username, string password)
        {
            var cust = await _db.GetLogin(username, password);
            return cust;
        }

        public async Task<Store> SelectStore(int storeId)
        {
            var s = await _db.GetStore(storeId);
            return s;
        }

        public async Task<List<Store>> GetStores()
        {
            var stores = await _db.GetStores();
            return stores;
        }

        public async Task<List<(Product, int)>> AddProductToCart(Product product, Customer customer, int quantity = 1)
        {
            var cart = _carts.GetCart(customer);
            var curQuantity = cart.GetQuantity(product);
            if (curQuantity > 0)
            {
                cart.SetQuantity(product, curQuantity + quantity);
            }
            else
            {
                cart.AddProduct(product, quantity);
            }
            return cart.GetCart();
        }

        public async Task<List<(Product, int)>> RemoveProductFromCart(Product product, Customer customer, int quantity = 1)
        {
            var cart = _carts.GetCart(customer);
            var curQuantity = cart.GetQuantity(product);
            if (curQuantity < quantity)
            {
                throw new ArgumentOutOfRangeException("Quantity must be less than or equal to number currently in cart");
            }
            else if (curQuantity == quantity)
            {
                cart.RemoveProduct(product);
            }
            else
            {
                cart.SetQuantity(product, curQuantity - quantity);
            }
            return cart.GetCart();
        }

        public async Task<Order> Checkout(Customer customer, Store store)
        {
            var cart = _carts.GetCart(customer);
            var prods = cart.GetCart();
            var order = await _db.CreateOrder(customer, store, prods);
            return order;
        }

        public async Task<List<Order>> GetOrderHistory(Customer customer)
        {
            return await _db.GetOrders(customer);
        }

        public async Task<List<Order>> GetOrderHistory(Store store)
        {
            return await _db.GetOrders(store);
        }

    }
}
