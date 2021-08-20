
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Domain.Abstracts;

namespace Project0.StoreApplication.Storage.Repositories
{
    public class StoreRepository
    {
        public StoreRepository()
        {
            Stores = new List<Store> {
                new GroceryStore("Store001"),
                new GroceryStore("Store002"),
                new GroceryStore("Store003")
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