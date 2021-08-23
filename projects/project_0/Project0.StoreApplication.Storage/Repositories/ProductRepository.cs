
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Domain.Settings;

namespace Project0.StoreApplication.Storage.Repositories
{
    public class ProductRepository : DataRepository<Product>
    {
        private static ProductRepository _repo = null;
        public static ProductRepository Factory()
        {
            return (_repo ??= new ProductRepository());
        }

        protected override string GetDataFile()
        {
            return AppSettings.Settings.GetProductsFile();
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