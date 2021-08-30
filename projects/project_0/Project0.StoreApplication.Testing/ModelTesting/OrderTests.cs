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
            var productsActual = sut.GetProducts();

            Assert.Equal(prods.Count, productsActual.Count);
            for (int i = 0; i < productsActual.Count; i++)
            {
                var actualProd = sut.GetProducts()[i];
                var expectedProd = prods[i];
                Assert.Equal(expectedProd.Name, actualProd.Name);
                Assert.Equal(expectedProd.ToString(), actualProd.ToString());
            }

            Assert.Equal(cust, sut.Customer);
            Assert.Equal(store, sut.Store);
        }

        [Fact]
        public void Test_OrderToString()
        {
            var storeName = "Fred's Pizza";
            var custName = "Bob Dylan";
            var productNames = new List<string>() { "Bounty soap", "Kenmore fridge", "Burton snowboard" };
            List<Product> prods = new();
            foreach (var name in productNames)
            {
                prods.Add(new Product() { Name = name });
            }
            var store = new GroceryStore() { Name = storeName };
            var cust = new Customer() { Name = custName };

            var sut = new Order(cust, store, prods);
            var actual = sut.ToString();
            foreach (var name in productNames)
            {
                Assert.Contains(name, actual);
            }
            Assert.Contains(storeName, actual);
            Assert.Contains(custName, actual);
        }

        [Fact]
        public void Test_Order_AddProduct()
        {
            var storeName = "Fred's Pizza";
            var custName = "Bob Dylan";
            var productNames = new List<string>() { "Bounty soap", "Kenmore fridge", "Burton snowboard" };
            List<Product> prods = new();
            foreach (var name in productNames)
            {
                prods.Add(new Product() { Name = name });
            }
            var store = new GroceryStore() { Name = storeName };
            var cust = new Customer() { Name = custName };

            var sut = new Order(cust, store, prods);

            var newProd = new Product() { Name = "Test add product", Price = 10.00m };

            prods.Add(newProd);
            var expected = prods;

            sut.AddProduct(newProd);
            var actual = sut.GetProducts();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_Order_RemoveProduct()
        {
            var storeName = "Fred's Pizza";
            var custName = "Bob Dylan";
            var productNames = new List<string>() { "Bounty soap", "Kenmore fridge", "Burton snowboard" };
            List<Product> prods = new();
            foreach (var name in productNames)
            {
                prods.Add(new Product() { Name = name });
            }
            var store = new GroceryStore() { Name = storeName };
            var cust = new Customer() { Name = custName };

            var removeProd = new Product() { Name = "Test add product", Price = 10.00m };
            prods.Add(removeProd);
            var sut = new Order(cust, store, prods);


            prods.Remove(removeProd);
            var expected = prods;

            sut.RemoveProduct(removeProd);
            var actual = sut.GetProducts();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_Order_GetTotal()
        {
            var storeName = "Fred's Pizza";
            var custName = "Bob Dylan";
            var prices = new List<decimal>() { 10m, 23m, 16m };
            List<Product> prods = new();
            foreach (var price in prices)
            {
                prods.Add(new Product() { Price = price });
            }
            var store = new GroceryStore() { Name = storeName };
            var cust = new Customer() { Name = custName };
            var sut = new Order(cust, store, prods);

            Assert.Equal(49m, sut.GetTotal());
        }


        [Fact]
        public void Test_Order_HashCode()
        {
            var sut = new Order() { OrderID = 1 };
            var order2 = new Order() { OrderID = 2 };

            Assert.Equal(1, sut.GetHashCode());
            Assert.NotEqual(order2.GetHashCode(), sut.GetHashCode());
        }

        [Fact]
        public void Test_Order_Equals()
        {
            var sut = new Order() { OrderID = 1 };
            var order2 = new Order() { OrderID = 2 };
            Order order3 = null;

            Assert.True(sut.Equals(sut));
            Assert.False(sut.Equals(order2));
            Assert.False(sut.Equals(order3));
            Assert.False(order2.Equals(sut));
        }

        [Fact]
        public void Test_Order_Comparison_Operators()
        {
            var sut = new Order() { OrderID = 1 };
            var order2 = new Order() { OrderID = 2 };
            Order order3 = null;
            var order4 = new Order() { OrderID = 1 };

            Assert.True(sut == order4);
            Assert.True(sut != order2);
            Assert.True(sut != order3);
            Assert.True(order4 == sut);
            Assert.True(order2 != sut);
            Assert.True(order3 != sut);
        }

    }
}