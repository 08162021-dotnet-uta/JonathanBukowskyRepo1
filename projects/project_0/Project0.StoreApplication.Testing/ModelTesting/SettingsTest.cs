
using Project0.StoreApplication.Client;
using Project0.StoreApplication.Domain.Interfaces;
using Project0.StoreApplication.Domain.Settings;
using Project0.StoreApplication.Testing.StorageTesting;
using Xunit;

namespace Project0.StoreApplication.Testing.ModelTesting
{
    /// <summary>
    /// Test the Settings objects and the CurrentSettings singleton
    /// </summary>
    public class SettingsTest
    {
        [Fact]
        public void Test_ApplicationSettingsObject()
        {
            IApplicationSettings settings = new ApplicationSettings();
            var sut = settings;
            Assert.Equal("/home/jon/revature/my_code/data/project_0/data/customers.xml", sut.GetCustomersFile());
            Assert.Equal("/home/jon/revature/my_code/data/project_0/data/", sut.GetDataDir());
            Assert.Equal("/home/jon/revature/my_code/data/project_0/data/orders.xml", sut.GetOrdersFile());
            Assert.Equal("/home/jon/revature/my_code/data/project_0/data/products.xml", sut.GetProductsFile());
            Assert.Equal("/home/jon/revature/my_code/data/project_0/data/stores.xml", sut.GetStoresFile());
        }
        [Fact]
        public void Test_TestSettingsObject()
        {
            IApplicationSettings settings = new StorageTestingSettings();
            var sut = settings;
            Assert.Equal("/home/jon/revature/my_code/data/project_0/test_data/customers.xml", sut.GetCustomersFile());
            Assert.Equal("/home/jon/revature/my_code/data/project_0/test_data/", sut.GetDataDir());
            Assert.Equal("/home/jon/revature/my_code/data/project_0/test_data/orders.xml", sut.GetOrdersFile());
            Assert.Equal("/home/jon/revature/my_code/data/project_0/test_data/products.xml", sut.GetProductsFile());
            Assert.Equal("/home/jon/revature/my_code/data/project_0/test_data/stores.xml", sut.GetStoresFile());
        }

        [Fact]
        public void Test_CurrentSettings_DataFiles()
        {
            // we have to initialize this, which makes for a kind of silly test
            IApplicationSettings settings = new ApplicationSettings();
            CurrentSettings.Settings = settings;
            var sut = CurrentSettings.Settings;
            Assert.Equal("/home/jon/revature/my_code/data/project_0/data/customers.xml", sut.GetCustomersFile());
            Assert.Equal("/home/jon/revature/my_code/data/project_0/data/", sut.GetDataDir());
            Assert.Equal("/home/jon/revature/my_code/data/project_0/data/orders.xml", sut.GetOrdersFile());
            Assert.Equal("/home/jon/revature/my_code/data/project_0/data/products.xml", sut.GetProductsFile());
            Assert.Equal("/home/jon/revature/my_code/data/project_0/data/stores.xml", sut.GetStoresFile());
        }

    }
}