
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Adapters;

namespace Project0.StoreApplication.Storage
{
    public class DemoEF
    {
        private readonly DataAdapter _da = new();

        public List<Customer> GetCustomers()
        {
            var custs = _da.Customers.FromSqlRaw("SELECT [Name] FROM Customer.Customer").ToList();
            return null;
        }
    }
}