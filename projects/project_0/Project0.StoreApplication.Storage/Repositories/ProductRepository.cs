
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Domain.Settings;

namespace Project0.StoreApplication.Storage.Repositories
{
    /// <summary>
    /// Singleton access to all Products saved in persistent storage
    /// </summary>
    public class ProductRepository : DataRepository<Product>
    {
        private static ProductRepository _repo = null;
        public static ProductRepository Factory()
        {
            return (_repo ??= new ProductRepository());
        }

        protected override string GetDataFile()
        {
            return CurrentSettings.Settings.GetProductsFile();
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
        public Product GetProduct(int productID)
        {
            var product = Products.Find((Product p) => p.ProductID == productID);
            return product;
        }

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