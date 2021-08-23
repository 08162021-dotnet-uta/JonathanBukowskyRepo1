
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Domain.Settings;

namespace Project0.StoreApplication.Storage.Repositories
{
    public class CustomerRepository : DataRepository<Customer>
    {

        protected override string GetDataFile()
        {
            return AppSettings.Settings.GetCustomersFile();
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
                new Customer() { Name = "Joe" },
                new Customer() { Name = "Bob" },
                new Customer() { Name = "Ruby" }
            };
        }
    }
}