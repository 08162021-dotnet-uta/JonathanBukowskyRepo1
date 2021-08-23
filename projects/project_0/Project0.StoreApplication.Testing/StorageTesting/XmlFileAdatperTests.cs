
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Adapters;
using Xunit;

namespace Project0.StoreApplication.Testing.StorageTesting
{
    public class XmlFileAdapterTests
    {
        private const string dataDir = "/home/jon/revature/my_code/data/project_0/test_data/";

        [Fact]
        public void Test_SaveData()
        {
            var dataFile = dataDir + "test_stores.xml";
            var testStores = new List<Store>() {
                new GroceryStore() { Name = "Meijer"},
                new GroceryStore() { Name = "Kroger"}
            };
            Adapter sut = new XmlFileAdapter();
            sut.SaveAll(testStores, dataFile);
            var actual = sut.LoadAll<Store>(dataFile);
            Assert.Equal(actual.Count, 2);
            Assert.True(actual[0].Name == "Meijer");
            Assert.True(actual[1].Name == "Kroger");
        }

        public void Test_LoadAll()
        {
            var dataFile = dataDir + "test_load.xml";
            Adapter sut = new XmlFileAdapter();
            var actual = sut.LoadAll<Product>(dataFile);
            Assert.Equal(actual.Count, 10);
            for (int i = 0; i < 10; i++)
            {
                var prod = actual[i];
                Assert.True(prod.Name.Contains("PS" + i));
            }
        }
    }
}