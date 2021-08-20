using Xunit;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Testing
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
            var actual = sut.Purchases;

            // assert = condition by which test succeeds/fails
            Assert.NotNull(actual);
        }
    }
}