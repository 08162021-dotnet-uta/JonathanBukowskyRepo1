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

        public DBStorageImpl() : base()
        {
            _db = new StoreApplicationDB2Context();
        }
        // TODO: use dependency injection
        /*
        public DBStorageImpl(DbContext db) : base()
        {
            _db = db;
        }
        */

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
            _db.Database.ExecuteSqlRaw("INSERT INTO Store.[Order] (CustomerID, StoreID, OrderDate)" +
                " VALUES ({0}, {1}, DATEADD(minute, -1, CURRENT_TIMESTAMP))", customer.CustomerId, store.StoreId);
            _db.SaveChanges();
            // TODO: Check for success/failure
            // TODO: this is not safe for concurrent use
            var ords = _db.Orders.FromSqlRaw(
                    "SELECT TOP(1) * FROM Store.[Order] WHERE CustomerID={0} AND StoreID={1} ORDER BY OrderDate DESC",
                    customer.CustomerId,
                    store.StoreId
                ).ToList();
            var result = ords[0];
            foreach (var product in products)
            {
                _db.Database.ExecuteSqlRaw("INSERT INTO Store.OrderProduct (OrderID, ProductID) VALUES ({0}, {1})", result.OrderId, product.ProductId);
                AttachProductsToOrder(result);
            }
            return result.ConvertToModel();
        }

        public List<Customer> GetCustomers()
        {
            var custs = _db.Customers.FromSqlRaw("SELECT * FROM Customer.Customer").ToList();
            return custs.ConvertAll(c => c.ConvertToModel());
        }

        public List<Customer> GetModelCustomers()
        {
            var custs = _db.Customers.FromSqlRaw("SELECT * FROM Customer.Customer").ToList();
            return custs.ConvertAll(c => c.ConvertToModel());
        }


        private static readonly string _orderSubQuery =
            "SELECT p.* " +
            "FROM Store.OrderProduct AS op " +
            "INNER JOIN Store.Product AS p " +
                "ON p.ProductID = op.ProductID " +
            "WHERE op.OrderID = {0}";
        private void AttachProductsToOrder(DBOrder order)
        {
            order.OrderProducts = _db.OrderProducts.FromSqlRaw(_orderSubQuery, order.OrderId).ToList();
        }
        public List<Order> GetOrders()
        {
            var ords = _db.Orders.FromSqlRaw("SELECT * FROM Store.[Order]").ToList();
            foreach (var order in ords)
            {
                AttachProductsToOrder(order);
            }
            return ords.ConvertAll(o => o.ConvertToModel());
        }

        public List<Order> GetOrders(Store store)
        {
            var ords = _db.Orders.FromSqlRaw("SELECT * FROM Store.[Order] WHERE StoreID={0}", store.StoreId).ToList();
            foreach (var order in ords)
            {
                AttachProductsToOrder(order);
            }
            return ords.ConvertAll(o => o.ConvertToModel());
        }

        public List<Order> GetOrders(Customer customer)
        {
            var ords = _db.Orders.FromSqlRaw("SELECT * FROM Store.[Order] WHERE CustomerID={0}", customer.CustomerId).ToList();
            foreach (var order in ords)
            {
                AttachProductsToOrder(order);
            }
            return ords.ConvertAll(o => o.ConvertToModel());
        }

        public async Task<List<Product>> GetProducts()
        {
            var prods = _db.Products.FromSqlRaw("SELECT * FROM Store.Product");
            var result = (from p in prods select p.ConvertToModel()).ToListAsync();
            return await result;
        }

        public List<Store> GetStores()
        {
            var stores = _db.Stores.FromSqlRaw("SELECT * FROM Store.Store").ToList();
            return stores.ConvertAll(s => s.ConvertToModel());
        }

        /*
        public void SetCustomer(Customer customer)
        {
            //_customerAdapter.Customer.Add(customer);
            _customerAdapter.Database.ExecuteSqlRaw("INSERT INTO Customer.Customer ([Name]) VALUES ({0})", customer.Name);
            _customerAdapter.SaveChanges();
        }
        */

        public void LoadFromScratch()
        {
            //TODO: Save repo data into db?
        }

        public bool AddCustomer(Customer customer)
        {
            //try
            //{
                _db.Database.ExecuteSqlRaw("INSERT INTO Customer.Customer (FirstName, LastName) VALUES ({0}, {1})", customer.FirstName, customer.LastName);
                return true;
            //}
            /*
            catch ()
            {
                //TODO: better error handling
                return false;
            }
            */
        }

        public bool AddProduct(Product product)
        {
            // Required: name, price
            // Optional: description, category
            _db.Database.ExecuteSqlRaw("INSERT INTO Store.Product (Name, Price, Description, CategoryID) VALUES ({0}, {1}, {2}, {3})",
                product.Name,
                product.Price,
                product.Description,
                product.CategoryID);
            // TODO: better error handling/return type
            return true;
        }

        public bool AddStore(Store store)
        {
            _db.Database.ExecuteSqlRaw("INSERT INTO Store.Store (Name) VALUES ({0})", store.Name);
            // TODO: better error handling/return type
            return true;
        }
    }

}
