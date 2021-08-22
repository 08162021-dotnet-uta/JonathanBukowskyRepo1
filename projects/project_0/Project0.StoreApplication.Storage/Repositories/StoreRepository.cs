
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Abstracts;

namespace Project0.StoreApplication.Storage.Repositories
{
    public class StoreRepository : DataRepository<Store>
    {
        //public List<Store> Data { get; set; }
        protected static StoreRepository _repo = null;
        protected static string dataFile = dataDir + "stores.xml";
        public static StoreRepository Factory()
        {
            if (_repo == null) { _repo = new StoreRepository(); }
            return _repo;
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
        public Store GetStore(int index)
        {
            return Data[index];
        }

        protected override string GetDataFile()
        {
            return dataFile;
        }
    }
}