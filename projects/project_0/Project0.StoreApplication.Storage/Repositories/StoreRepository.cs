
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Storage.Repositories
{
    public class StoreRepository
    {
        public StoreRepository()
        {
            Stores = new List<Store> {
                new Store() { Name = "Store001" },
                new Store() { Name = "Store002" },
                new Store() { Name = "Store003" }
            };
        }
        public List<Store> Stores { get; set; }

        public Store GetStore(int index)
        {
            if (index < 0 || index > Stores.Count)
            {
                return null;
            }
            return Stores[index];
        }
    }
}