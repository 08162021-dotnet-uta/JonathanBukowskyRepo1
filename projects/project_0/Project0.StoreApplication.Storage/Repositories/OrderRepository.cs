
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Storage.Repositories
{
    public class OrderRepository : DataRepository<Order>
    {
        public List<Order> Orders { get => Data; set => Data = value; }

        protected static OrderRepository _repo = null;
        public static OrderRepository Factory() { return (_repo = _repo ?? new OrderRepository()); }
        internal OrderRepository()
        {
            // Load()
            Orders = new();
        }

        public void SaveOrders()
        {
            Save();
        }

        public void LoadOrders()
        {
            Load();
        }

        protected static string dataFile = dataDir + "orders.xml";
        protected override string GetDataFile()
        {
            return dataFile;
        }
    }
}