
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Interfaces;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage;
using Project0.StoreApplication.Storage.Repositories;
using Xunit;

namespace Project0.StoreApplication.Testing.StorageTesting
{
    // Put file IO tests into same collection to turn off parallel tests because of file IO
    [Collection("File IO Tests")]
    public class XmlFileStorageTests
    {
        [Fact]
        public void Test_GetProducts()
        {
            RepositoryTesting.RepositorySetup.InitializeSettings();
            IStorageDAO sut = new XmlFileStorage();
            var actual = sut.GetProducts();
            Assert.NotNull(actual);
            Assert.Equal(actual.Count, 10);
        }
        [Fact]
        public void Test_GetStores()
        {
            RepositoryTesting.RepositorySetup.InitializeSettings();
            IStorageDAO sut = new XmlFileStorage();
            var actual = sut.GetStores();
            Assert.NotNull(actual);
            Assert.Equal(actual.Count, 3);
        }
        [Fact]
        public void Test_GetCustomers()
        {
            RepositoryTesting.RepositorySetup.InitializeSettings();
            IStorageDAO sut = new XmlFileStorage();
            var actual = sut.GetCustomers();
            Assert.NotNull(actual);
            Assert.Equal(actual.Count, 3);
        }
        [Fact]
        public void Test_GetOrders()
        {
            RepositoryTesting.RepositorySetup.InitializeSettings();
            IStorageDAO sut = new XmlFileStorage();
            var actual = sut.GetOrders();
            Assert.NotNull(actual);
            Assert.Equal(actual.Count, 9);
        }
        [Fact]
        public void Test_CreateOrder()
        {
            RepositoryTesting.RepositorySetup.InitializeSettings();
            var storeRepo = StoreRepository.Factory();
            var customerRepo = CustomerRepository.Factory();
            var productRepo = ProductRepository.Factory();
            IStorageDAO sut = new XmlFileStorage();
            Customer customer = customerRepo.Customers[0];
            Store store = storeRepo.Stores[1];
            List<Product> prods = new()
            {
                productRepo.Products[3],
                productRepo.Products[2],
                productRepo.Products[7],
            };
            var actual = sut.CreateOrder(customer, store, prods);
            var orders = sut.GetOrders();
            var index = orders.FindIndex((Order o) => o == actual);
            Assert.NotNull(actual);
            // TODO: this might be a bad assert.
            //Assert.True(index == orders.Count - 1);

            var orderRepo = OrderRepository.Factory();
            orderRepo.LoadOrders();
            // TODO: need to remove the order, but that isn't possible at the moment
            orderRepo.Orders.RemoveAll((Order order) => order == actual);
            orderRepo.SaveOrders();
        }

        [Fact]
        public void Test_ReloadOrders()
        {
            RepositoryTesting.RepositorySetup.InitializeSettings();
            IStorageDAO sut = new XmlFileStorage();
            var repo = OrderRepository.Factory();
            var expected = sut.GetOrders()[2];
            repo.LoadOrders();
            var acutal = sut.GetOrders();
            var found = acutal.Find((Order order) => order == expected);
            Assert.NotNull(found);
        }
        [Fact]
        public void Test_ReloadCustomers()
        {
            RepositoryTesting.RepositorySetup.InitializeSettings();
            IStorageDAO sut = new XmlFileStorage();
            var repo = CustomerRepository.Factory();
            var expected = sut.GetCustomers()[2];
            repo.LoadCustomers();
            var acutal = sut.GetCustomers();
            var found = acutal.Find((Customer customer) => customer == expected);
            Assert.NotNull(found);
        }
        [Fact]
        public void Test_ReloadProducts()
        {
            RepositoryTesting.RepositorySetup.InitializeSettings();
            IStorageDAO sut = new XmlFileStorage();
            var repo = ProductRepository.Factory();
            var expected = sut.GetProducts()[2];
            repo.LoadProducts();
            var acutal = sut.GetProducts();
            var found = acutal.Find((Product product) => product == expected);
            Assert.NotNull(found);
        }
        [Fact]
        public void Test_ReloadStores()
        {
            RepositoryTesting.RepositorySetup.InitializeSettings();
            IStorageDAO sut = new XmlFileStorage();
            var repo = StoreRepository.Factory();
            var expected = sut.GetStores()[2];
            repo.LoadStores();
            var acutal = sut.GetStores();
            var found = acutal.Find((Store store) => store == expected);
            Assert.NotNull(found);
        }
    }
}