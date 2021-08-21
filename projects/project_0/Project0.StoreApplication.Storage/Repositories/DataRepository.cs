
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Adapters;

namespace Project0.StoreApplication.Storage.Repositories
{
    public abstract class DataRepository<T> : Repository
    {
        protected abstract string GetDataFile();
        // this is hacky, but could provide a default data file if we want
        // protected static string dataFile = dataDir + (typeof(T).Name.ToLower()) + "s.xml";
        /*
        {
            if (_repo == null) { _repo = new DataRepository<T>(); }
            return _repo;
        }
        */

        protected void Load()
        {
            Adapter adapter = new XmlFileAdapter();
            Data = adapter.LoadAll<T>(GetDataFile());
        }

        protected List<T> Data { get; set; }

        protected void Save()
        {
            Adapter adapter = new XmlFileAdapter();
            adapter.SaveAll(Data, GetDataFile());
        }
    }
}