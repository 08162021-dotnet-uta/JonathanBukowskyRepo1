
using Project0.StoreApplication.Client;
using Project0.StoreApplication.Domain.Interfaces;
using Project0.StoreApplication.Domain.Settings;
using Project0.StoreApplication.Testing.StorageTesting;
using Xunit;

namespace Project0.StoreApplication.Testing.ModelTesting
{
    public class SettingsTest
    {
        [Fact]
        public void Test_ApplicationSettingsObject()
        {
            IApplicationSettings settings = new ApplicationSettings();
            var sut = settings;
            Assert.Equal(sut.GetCustomersFile(), "/home/jon/revature/my_code/data/project_0/data/customers.xml");
            Assert.Equal(sut.GetDataDir(), "/home/jon/revature/my_code/data/project_0/data/");
            Assert.Equal(sut.GetOrdersFile(), "/home/jon/revature/my_code/data/project_0/data/orders.xml");
            Assert.Equal(sut.GetProductsFile(), "/home/jon/revature/my_code/data/project_0/data/products.xml");
            Assert.Equal(sut.GetStoresFile(), "/home/jon/revature/my_code/data/project_0/data/stores.xml");
        }
        [Fact]
        public void Test_TestSettingsObject()
        {
            IApplicationSettings settings = new StorageTestingSettings();
            var sut = settings;
            Assert.Equal(sut.GetCustomersFile(), "/home/jon/revature/my_code/data/project_0/test_data/customers.xml");
            Assert.Equal(sut.GetDataDir(), "/home/jon/revature/my_code/data/project_0/test_data/");
            Assert.Equal(sut.GetOrdersFile(), "/home/jon/revature/my_code/data/project_0/test_data/orders.xml");
            Assert.Equal(sut.GetProductsFile(), "/home/jon/revature/my_code/data/project_0/test_data/products.xml");
            Assert.Equal(sut.GetStoresFile(), "/home/jon/revature/my_code/data/project_0/test_data/stores.xml");
        }

        [Fact]
        public void Test_CurrentSettings_DataFiles()
        {
            // we have to initialize this, which makes for a kind of silly test
            IApplicationSettings settings = new ApplicationSettings();
            CurrentSettings.Settings = settings;
            var sut = CurrentSettings.Settings;
            Assert.Equal(sut.GetCustomersFile(), "/home/jon/revature/my_code/data/project_0/data/customers.xml");
            Assert.Equal(sut.GetDataDir(), "/home/jon/revature/my_code/data/project_0/data/");
            Assert.Equal(sut.GetOrdersFile(), "/home/jon/revature/my_code/data/project_0/data/orders.xml");
            Assert.Equal(sut.GetProductsFile(), "/home/jon/revature/my_code/data/project_0/data/products.xml");
            Assert.Equal(sut.GetStoresFile(), "/home/jon/revature/my_code/data/project_0/data/stores.xml");
        }

    }
}