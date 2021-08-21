
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Storage.Repositories
{
    public class ProductRepository : DataRepository<Product>
    {
        private static ProductRepository _repo = null;
        public static ProductRepository Factory()
        {
            if (_repo == null) { _repo = new ProductRepository(); }
            return _repo;
        }

        protected static string dataFile = dataDir + "products.xml";
        protected override string GetDataFile()
        {
            return dataFile;
        }
        internal ProductRepository()
        {
            LoadProducts();
        }

        public void SaveProducts()
        {
            Save();
        }

        public void LoadProducts()
        {
            // TODO: handle errors
            Load();
        }

        public List<Product> Products { get => Data; set => Data = value; }

        private List<Product> _createDefaultProducts()
        {
            var prods = new List<Product>();
            for (int i = 0; i < 10; i++)
            {
                prods.Add(new Product() { ProductID = i, Name = "PS" + (i + 1) });
            }
            return prods;
        }
    }
}