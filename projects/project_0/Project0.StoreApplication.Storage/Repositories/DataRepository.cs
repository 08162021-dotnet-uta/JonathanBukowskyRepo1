
using System.Collections.Generic;
using Project0.StoreApplication.Storage.Adapters;

namespace Project0.StoreApplication.Storage.Repositories
{
    // TODO: the DataRepository type does not need to be generic, consider making only the methods generic
    public abstract class DataRepository<T> : Repository
    {
        protected abstract string GetDataFile();
        // this is hacky, but could provide a default data file if we don't
        //      want to have to keep subclassing DataRepository for each new data type
        // protected static string dataFile = dataDir + (typeof(T).Name.ToLower()) + "s.xml";

        protected void Load()
        {
            // TODO: create file if doesn't exist
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