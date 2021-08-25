using Xunit;
using Project0.StoreApplication.Domain.Models;
using System.Collections.Generic;

namespace Project0.StoreApplication.Testing.ModelTesting
{
    /// <summary>
    /// Tests for the Order class
    /// </summary>
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

            Assert.True(prods.Count == sut.Products.Count);
            for (int i = 0; i < sut.Products.Count; i++)
            {
                var actualProd = sut.Products[i];
                var expectedProd = prods[i];
                Assert.Equal(actualProd.Name, expectedProd.Name);
                Assert.Equal(actualProd.ToString(), expectedProd.ToString());
            }

            // TODO: look into Assert.Equal()
            Assert.True(sut.Customer == cust);
            Assert.True(sut.Store == store);
        }

        [Fact]
        public void Test_OrderToString()
        {
            var storeName = "Fred's Pizza";
            var custName = "Bob Dylan";
            var productNames = new List<string>() { "Bounty soap", "Kenmore fridge", "Burton snowboard" };
            List<Product> prodsActual = new();
            foreach (var name in productNames)
            {
                prodsActual.Add(new Product() { Name = name });
            }
            var store = new GroceryStore() { Name = storeName };
            var cust = new Customer() { Name = custName };

            var sut = new Order(cust, store, prodsActual);
            var actual = sut.ToString();
            foreach (var name in productNames)
            {
                Assert.True(actual.Contains(name));
            }
            Assert.True(actual.Contains(storeName));
            Assert.True(actual.Contains(custName));
        }
    }
}