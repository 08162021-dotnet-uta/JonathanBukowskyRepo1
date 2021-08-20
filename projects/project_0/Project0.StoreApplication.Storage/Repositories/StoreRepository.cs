
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Storage.Adapters;

namespace Project0.StoreApplication.Storage.Repositories
{
    public class StoreRepository
    {
        public StoreRepository()
        {
            LoadStores();
            try
            {
                //LoadStores();
            }
            catch
            {
                // TODO: make this better
                //_createDefaultStores();
            }
            if (Stores == null || Stores.Count == 0)
            {
                // TODO: make this better
                //_createDefaultStores();
            }
        }
        public List<Store> Stores { get; set; }

        private void _createDefaultStores()
        {
            Stores = new List<Store> {
                    new GroceryStore("Store001"),
                    new GroceryStore("Store002"),
                    new GroceryStore("Store003")
                };
        }

        public void SaveStores()
        {
            Adapter adapter = new XmlFileAdapter();
            adapter.Save(Stores);
        }

        public void LoadStores()
        {
            Adapter adapter = new XmlFileAdapter();
            Stores = adapter.LoadStores();
        }

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