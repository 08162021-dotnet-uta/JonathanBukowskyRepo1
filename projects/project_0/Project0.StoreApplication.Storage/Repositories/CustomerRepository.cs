
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Storage.Repositories
{
    public class CustomerRepository : DataRepository<Customer>
    {

        protected static string dataFile = dataDir + "customers.xml";
        protected override string GetDataFile()
        {
            return dataFile;
        }
        protected static CustomerRepository _repo = null;
        //public static CustomerRepository Factory() { return (_repo = _repo ?? new CustomerRepository()); }
        public static CustomerRepository Factory()
        {
            if (_repo == null) { _repo = new CustomerRepository(); }
            return _repo;
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