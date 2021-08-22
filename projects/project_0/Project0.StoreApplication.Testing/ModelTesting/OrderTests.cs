using Xunit;
using Project0.StoreApplication.Domain.Models;
using System.Collections.Generic;

namespace Project0.StoreApplication.Testing.ModelTesting
{
    public class OrderTests
    {
        [Fact]
        public void Test_OrderCreation()
        {
            var store = new GroceryStore("Fred's Pizza");
            var cust = new Customer();
            var prods = new List<Product>() { new Product() };

            // TODO: create an order in a way that makes sense
            var sut = new Order(cust, store, prods);

            Assert.True(sut.Customer == cust);
            Assert.True(sut.Products == prods);
            Assert.True(sut.Store == store);
        }
    }
}