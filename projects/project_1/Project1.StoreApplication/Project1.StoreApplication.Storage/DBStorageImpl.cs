using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project1.StoreApplication.Models;
using Project1.StoreApplication.Storage.DBModels;
using Project1.StoreApplication.Storage.DBConverters;

namespace Project1.StoreApplication.Storage
{
    public class DBStorageImpl : IStorage
    {
        private readonly StoreApplicationDB2Context _db;

        /*
        public DBStorageImpl() : base()
        {
            _db = new StoreApplicationDB2Context();
        }
        */
        public DBStorageImpl(StoreApplicationDB2Context db) : base()
        {
            _db = db;
        }

        public async Task<Order> CreateOrder(Customer customer, Store store, List<(Product, int)> products)
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
            await _db.Database.ExecuteSqlRawAsync("INSERT INTO Store.[Order] (CustomerID, StoreID, OrderDate)" +
                " VALUES ({0}, {1}, DATEADD(minute, -1, CURRENT_TIMESTAMP))", customer.CustomerId, store.StoreId);
            await _db.SaveChangesAsync();
            // TODO: Check for success/failure
            // TODO: this is not safe for concurrent use
            var result = await _db.Orders.FromSqlRaw(
                    "SELECT TOP(1) * FROM Store.[Order] WHERE CustomerID={0} AND StoreID={1} ORDER BY OrderDate DESC",
                    customer.CustomerId,
                    store.StoreId
                ).FirstAsync();
            if (result == null)
            {
                throw new DbUpdateException("Error saving order to db");
            }
            foreach (var (product, quantity) in products)
            {
                _db.Database.ExecuteSqlRaw("INSERT INTO Store.OrderProduct (OrderID, ProductID, Quantity) VALUES ({0}, {1}, {2})",
                    result.OrderId,
                    product.ProductId,
                    quantity
                );
            }
            await AttachProductsToOrder(result);
            return result.ConvertToModel();
        }

        public async Task<List<Customer>> GetCustomers()
        {
            var custs = await _db.Customers.FromSqlRaw("SELECT * FROM Customer.Customer").ToListAsync();
            return custs.ConvertAll(c => c.ConvertToModel());
        }

        public async Task<Customer> GetCustomer(Customer customer)
        {
            var cust = await _db.Customers.FromSqlRaw("SELECT * FROM Customer.Customer WHERE CustomerID = {0}", customer.CustomerId).FirstOrDefaultAsync();
            if (cust == null)
            {
                throw new ArgumentException("Invalid customer");
            }
            return cust.ConvertToModel();
        }


        public async Task<Customer> GetLogin(string username, string password)
        {
            var login = await _db.CustomerLogins.FromSqlRaw("SELECT * FROM Customer.CustomerLogin WHERE Username = {0} AND Password = {1}",
                username, password).FirstOrDefaultAsync();
            if (login == null)
            {
                // TODO: No logins found, could return error
                return null;
            }
            var cust = await _db.Customers.FromSqlRaw("SELECT * FROM Customer.Customer WHERE CustomerID = {0}", login.CustomerId).FirstAsync();
            return cust.ConvertToModel();
        }


        private static readonly string _orderSubQuery =
            "SELECT p.* " +
            "FROM Store.OrderProduct AS op " +
            "INNER JOIN Store.Product AS p " +
                "ON p.ProductID = op.ProductID " +
            "WHERE op.OrderID = {0}";
        private async Task AttachProductsToOrder(DBOrder order)
        {
            order.OrderProducts = await _db.OrderProducts.FromSqlRaw(_orderSubQuery, order.OrderId).ToListAsync();
        }
        public async Task<List<Order>> GetOrders()
        {
            var ords = await _db.Orders.FromSqlRaw("SELECT * FROM Store.[Order]").ToListAsync();
            foreach (var order in ords)
            {
                await AttachProductsToOrder(order);
            }
            return ords.ConvertAll(o => o.ConvertToModel());
        }

        public async Task<List<Order>> GetOrders(Store store)
        {
            var ords = await _db.Orders.FromSqlRaw("SELECT * FROM Store.[Order] WHERE StoreID={0}", store.StoreId).ToListAsync();
            foreach (var order in ords)
            {
                await AttachProductsToOrder(order);
            }
            return ords.ConvertAll(o => o.ConvertToModel());
        }

        public async Task<List<Order>> GetOrders(Customer customer)
        {
            var ords = await _db.Orders.FromSqlRaw("SELECT * FROM Store.[Order] WHERE CustomerID={0}", customer.CustomerId).ToListAsync();
            foreach (var order in ords)
            {
                await AttachProductsToOrder(order);
            }
            return ords.ConvertAll(o => o.ConvertToModel());
        }

        public async Task<Product> GetProduct(Product product)
        {
            var prod = await _db.Products.FromSqlRaw("SELECT * FROM Store.Product WHERE ProductID = {0}", product.ProductId).FirstOrDefaultAsync();
            if (prod == null)
            {
                throw new ArgumentException("Invalid product");
            }
            return prod.ConvertToModel();
        }

        public async Task<List<Product>> GetProducts()
        {
            var prods = _db.Products.FromSqlRaw("SELECT * FROM Store.Product");
            var result = (from p in prods select p.ConvertToModel()).ToListAsync();
            return await result;
        }

        public async Task<List<Product>> GetProducts(Store store)
        {
            var prodQuery = _db.Products.FromSqlRaw("SELECT p.* FROM Store.Product p INNER JOIN Store.StoreProduct sp ON sp.ProductID = p.ProductID "
                + "WHERE sp.StoreID = {0}", store.StoreId);
            var prods = await (from p in prodQuery select p.ConvertToModel()).ToListAsync();
            return prods;
        }

        public async Task<List<Store>> GetStores()
        {
            var stores = await _db.Stores.FromSqlRaw("SELECT * FROM Store.Store").ToListAsync();
            return stores.ConvertAll(s => s.ConvertToModel());
        }

        public async Task<Store> GetStore(int storeId)
        {
            var store = await _db.Stores.FromSqlRaw("SELECT * FROM Store.Store WHERE StoreID={0}", storeId).FirstOrDefaultAsync();
            return store.ConvertToModel();
        }

        /*
        public void SetCustomer(Customer customer)
        {
            //_customerAdapter.Customer.Add(customer);
            _customerAdapter.Database.ExecuteSqlRaw("INSERT INTO Customer.Customer ([Name]) VALUES ({0})", customer.Name);
            _customerAdapter.SaveChanges();
        }
        */

        public async Task<Customer> AddCustomer(Customer customer)
        {
            //try
            //{
            await _db.Database.ExecuteSqlRawAsync("INSERT INTO Customer.Customer (FirstName, LastName) VALUES ({0}, {1})", customer.FirstName, customer.LastName);
            await _db.SaveChangesAsync();
            var query = _db.Customers.FromSqlRaw("SELECT TOP(1) * FROM Customer.Customer WHERE FirstName={0} AND LastName={1} ORDER BY CustomerID DESC",
                        customer.FirstName, customer.LastName);
            try
            {
                var newCust = await query.FirstAsync();
                return newCust.ConvertToModel();
            }
            catch (InvalidOperationException)
            {
                // Error: newly created customer does not exist for some reason
                return null;
            }
            //}
        }

        public async Task<Product> AddProduct(Product product)
        {
            // Required: name, price
            // Optional: description, category
            await _db.Database.ExecuteSqlRawAsync("INSERT INTO Store.Product (Name, Price, Description, CategoryID) VALUES ({0}, {1}, {2}, {3})",
                product.Name,
                product.Price,
                product.Description,
                product.CategoryID);
            await _db.SaveChangesAsync();
            // TODO: make this more better
            var prod = await _db.Products.FromSqlRaw("SELECT * FROM Store.Product WHERE Name = {0} AND Price = {1} and Description = {2}",
                product.Name,
                product.Price,
                product.Description
                ).FirstOrDefaultAsync();
            // TODO: better error handling/return type
            return prod.ConvertToModel();
        }

        public async Task<Store> AddStore(Store store)
        {
            await _db.Database.ExecuteSqlRawAsync("INSERT INTO Store.Store (Name) VALUES ({0})", store.Name);
            await _db.SaveChangesAsync();
            // TODO: make this more better
            var s = await _db.Stores.FromSqlRaw("SELECT * FROM Store.Store WHERE Name = {0}", store.Name).FirstOrDefaultAsync();
            // TODO: better error handling/return type
            return s.ConvertToModel();
        }

        public async Task<List<Product>> GetStoreProducts(int storeId)
        {
            var storeProductsQuery = _db.Products.FromSqlRaw("SELECT p.* FROM Store.Product p INNER JOIN Store.StoreProduct sp ON p.ProductID = sp.ProductID "
                + "WHERE sp.StoreID = {0}", storeId);
            var storeProducts = await (from p in storeProductsQuery select p.ConvertToModel()).ToListAsync();
            return storeProducts;
        }

        private async Task<(DBStore, DBProduct)> ValidateStoreAndProduct(Store store, Product product)
        {
            var dbStore = await _db.Stores.FromSqlRaw("SELECT * FROM Store.Store WHERE StoreID = {0}", store.StoreId).FirstOrDefaultAsync();
            if (dbStore == null)
            {
                throw new ArgumentException("Invalid store");
            }
            var dbProduct = await _db.Products.FromSqlRaw("SELECT * FROM Store.Product WHERE ProductID = {0}", product.ProductId).FirstOrDefaultAsync();
            if (dbProduct == null)
            {
                throw new ArgumentException("Invalid product");
            }
            return (dbStore, dbProduct);
        }

        public async Task<List<Product>> AddStoreProduct(Store store, Product product)
        {
            var (dbStore, dbProduct) = await ValidateStoreAndProduct(store, product);
            await _db.Database.ExecuteSqlRawAsync("INSERT INTO Store.StoreProduct (StoreID, ProductID, Quantity) VALUES ({0}, {1}, 1)", dbStore.StoreId, dbProduct.ProductId);
            return await GetStoreProducts(dbStore.StoreId);
        }

        public async Task<List<Product>> RemoveStoreProduct(Store store, Product product)
        {
            var (dbStore, dbProduct) = await ValidateStoreAndProduct(store, product);
            await _db.Database.ExecuteSqlRawAsync("DELETE FROM Store.StoreProduct WHERE ProductID = {0} AND StoreID = {1}", dbProduct.ProductId, dbStore.StoreId);
            return await GetStoreProducts(dbStore.StoreId);
        }
    }

}
