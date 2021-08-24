
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Interfaces;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage;
using Project0.StoreApplication.Storage.Repositories;
using Xunit;

namespace Project0.StoreApplication.Testing.StorageTesting
{
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
            System.Console.WriteLine(actual);
            Assert.NotNull(actual);
            // TODO: this might be a bad assert.
            Assert.True(index == orders.Count - 1);

            var orderRepo = OrderRepository.Factory();
            orderRepo.LoadOrders();
            // TODO: need to remove the order, but that isn't possible at the moment
            //orderRepo.Orders.RemoveAll((Order order) => order.);
            orderRepo.SaveOrders();
        }

        [Fact]
        public void Test_ReloadOrders()
        {
            RepositoryTesting.RepositorySetup.InitializeSettings();
        }
        [Fact]
        public void Test_ReloadCustomers()
        {
            RepositoryTesting.RepositorySetup.InitializeSettings();
        }
        [Fact]
        public void Test_ReloadProducts()
        {
            RepositoryTesting.RepositorySetup.InitializeSettings();
        }
        [Fact]
        public void Test_ReloadStores()
        {
            RepositoryTesting.RepositorySetup.InitializeSettings();
        }
    }
}