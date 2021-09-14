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

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            // TODO: validation for customer
            var cust = await _db.AddCustomer(customer);
            if (cust == null)
            {
                throw new Exception("Error creating customer");
            }
            return cust;
        }

        public async Task<List<Product>> GetProducts()
        {
            var prods = await _db.GetProducts();
            return prods;
        }

        public async Task<List<Product>> GetProductsByStore(Store s)
        {
            var prods = await _db.GetProducts(s);
            return prods;
        }
    }
}
