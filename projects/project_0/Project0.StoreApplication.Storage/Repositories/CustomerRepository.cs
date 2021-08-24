
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Domain.Settings;

namespace Project0.StoreApplication.Storage.Repositories
{
    public class CustomerRepository : DataRepository<Customer>
    {

        protected override string GetDataFile()
        {
            return CurrentSettings.Settings.GetCustomersFile();
        }
        protected static CustomerRepository _repo = null;
        public static CustomerRepository Factory()
        {
            return (_repo ??= new CustomerRepository());
        }

        internal CustomerRepository()
        {
            LoadCustomers();
        }

        public List<Customer> Customers { get => Data; set => Data = value; }
        public Customer GetCustomer(int customerID)
        {
            var customer = Customers.Find((Customer c) => c.CustomerID == customerID);
            // could do some checking, but returning null is currently correct if customer doesn't exist
            return customer;
        }
        public void LoadCustomers()
        {
            Load();
        }

        public void SaveCustomers()
        {
            Save();
        }

        private static List<Customer> _createDefaultCustomers()
        {
            return new()
            {
                new Customer() { Name = "Joe", CustomerID = 1 },
                new Customer() { Name = "Bob", CustomerID = 2 },
                new Customer() { Name = "Ruby", CustomerID = 3 }
            };
        }
    }
}