
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Settings;

namespace Project0.StoreApplication.Storage.Repositories
{
    /// <summary>
    /// Singleton access to Store objects in persistent storage
    /// </summary>
    public class StoreRepository : DataRepository<Store>
    {
        //public List<Store> Data { get; set; }
        protected static StoreRepository _repo = null;
        public static StoreRepository Factory()
        {
            return (_repo ??= new StoreRepository());
        }
        internal StoreRepository()
        {
            // TODO: error checking
            Load();
        }

        public void SaveStores()
        {
            Save();
        }
        public void LoadStores()
        {
            Load();
        }
        public List<Store> Stores { get => Data; set => Data = value; }
        public Store GetStore(int storeID)
        {
            var store = Stores.Find((Store s) => s.StoreID == storeID);
            return store;
        }

        protected override string GetDataFile()
        {
            return CurrentSettings.Settings.GetStoresFile();
        }
    }
}