using Xunit;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Testing.ModelTesting
{
    public class OrderTests
    {
        [Fact]
        public void Test_OrderCreation()
        {
            var store = new GroceryStore("Fred's Pizza");
            var cust = new Customer();
            var prod = new Product();

            // TODO: create an order in a way that makes sense
            var sut = new Order(cust, prod, store);

            Assert.True(sut.Customer == cust);
            Assert.True(sut.Product == prod);
            Assert.True(sut.Store == store);
        }
    }
}