using Xunit;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Testing.ModelTesting
{
    public class CustomerTests
    {
        [Fact]
        public void Test_PastPurchases()
        {
            // arrange = get instance of the entity to test
            // "sut" - subject under test
            var sut = new Customer();

            // act = execute sut for data
            // TODO: purchases will now come from Repo.getpurchases -- idk if this is good
            //var actual = sut.Purchases;
            object actual = null;

            // assert = condition by which test succeeds/fails
            Assert.NotNull(actual);
        }

        [Fact]
        public void Test_SetLocation()
        {
            var sut = new Customer();
            var store = new GroceryStore("Fred's Pizza");

            /*
            TODO: fix this too
            sut.SelectedStore = store;
            Assert.True(sut.SelectedStore == store);
            */
            Assert.True(false);
        }
    }
}