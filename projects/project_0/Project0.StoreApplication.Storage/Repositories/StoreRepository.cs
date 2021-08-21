
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Storage.Adapters;

namespace Project0.StoreApplication.Storage.Repositories
{
    public class StoreRepository : Repository
    {
        private static StoreRepository _repo = null;
        public static StoreRepository Factory()
        {
            if (_repo == null) { _repo = new StoreRepository(); }
            return _repo;
        }
        //protected 
        internal StoreRepository()
        {
            // TODO: put this back in the try
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
            adapter.SaveAll(Stores, FileLocation.Stores);
        }

        public void LoadStores()
        {
            Adapter adapter = new XmlFileAdapter();
            Stores = adapter.LoadAll<Store>(FileLocation.Stores);
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