
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Adapters;
using Xunit;

namespace Project0.StoreApplication.Testing.StorageTesting
{
    // Put file IO tests into same collection to turn off parallel tests because of file IO
    [Collection("File IO Tests")]
    public class XmlFileAdapterTests
    {
        private const string dataDir = "/home/jon/revature/my_code/data/project_0/test_data/";

        [Fact]
        public void Test_SaveData()
        {
            // should probably do it this way, but hardcoded is fine for now
            //var dataFile = ((IApplicationSettings)new StorageTestingSettings()).GetStoresFile();
            var dataFile = dataDir + "stores.xml";
            var testStores = new List<Store>() {
                new GroceryStore() { Name = "Meijer", StoreID = 1},
                new GroceryStore() { Name = "Kroger", StoreID = 2},
                new GroceryStore() { Name = "Target", StoreID = 3},
            };
            Adapter sut = new XmlFileAdapter();
            sut.SaveAll(testStores, dataFile);
            var actual = sut.LoadAll<Store>(dataFile);
            Assert.Equal(3, actual.Count);
            Assert.Equal("Meijer", actual[0].Name);
            Assert.Equal(1, actual[0].StoreID);
            Assert.Equal("Kroger", actual[1].Name);
            Assert.Equal(2, actual[1].StoreID);
            Assert.Equal("Target", actual[2].Name);
            Assert.Equal(3, actual[2].StoreID);
        }

        [Fact]
        public void Test_LoadAll()
        {
            var dataFile = dataDir + "test_load.xml";
            Adapter sut = new XmlFileAdapter();
            var actual = sut.LoadAll<Product>(dataFile);
            Assert.Equal(10, actual.Count);
            for (int i = 0; i < 10; i++)
            {
                var prod = actual[i];
                Assert.Contains($"PS{i + 1}", prod.Name);
                Assert.Equal(i, prod.ProductID);
            }
        }
    }
}