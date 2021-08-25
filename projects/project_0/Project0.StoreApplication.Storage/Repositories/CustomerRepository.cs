
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Domain.Settings;

/// <summary>
/// Repositories for persistent storage of specific object types
/// </summary>
namespace Project0.StoreApplication.Storage.Repositories
{
    /// <summary>
    /// Singleton object to interact with persistent Customer data.
    /// </summary>
    public class CustomerRepository : DataRepository<Customer>
    {

        protected override string GetDataFile()
        {
            return CurrentSettings.Settings.GetCustomersFile();
        }
        protected static CustomerRepository _repo = null;

        /// <summary>
        /// Get instance of Customer repository
        /// </summary>
        /// <returns></returns>
        public static CustomerRepository Factory()
        {
            return (_repo ??= new CustomerRepository());
        }

        internal CustomerRepository()
        {
            LoadCustomers();
        }

        /// <summary>
        /// List of customers in persistent storage
        /// </summary>
        /// <value></value>
        public List<Customer> Customers { get => Data; set => Data = value; }

        /// <summary>
        /// Retrieve a Customer object from storage using customerID
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public Customer GetCustomer(int customerID)
        {
            var customer = Customers.Find((Customer c) => c.CustomerID == customerID);
            // could do some checking, but returning null is currently correct if customer doesn't exist
            return customer;
        }

        /// <summary>
        /// Refresh customers list from storage
        /// </summary>
        public void LoadCustomers()
        {
            Load();
        }

        /// <summary>
        /// Persist current list of customers to storage
        /// </summary>
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