using Xunit;
using Project0.StoreApplication.Storage.Repositories;

namespace Project0.StoreApplication.Testing.StorageTesting
{
    // TDD -- test driven development
    // red green refactor -- term for tdd, means 1 (red - create tests, all will fail), 2 (green - code until tests pass), 3 (refactor your code, tests should stay green)
    public class CustomerRepositoryTests
    {
        // need annotations ("attributes" in c#) for testing to work successfully
        [Fact]
        public void Test_CustomerCollectionNull()
        {
            var sut = CustomerRepository.Factory();
            var actual = sut.Customers;

            // assert = condition by which test succeeds/fails
            Assert.NotNull(actual);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void Test_OneCustomer(int i)
        {
            var sut = StoreRepository.Factory();
            var store = sut.GetStore(i);
            Assert.NotNull(store);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(-1)]
        [InlineData(4)]
        public void Test_OneStoreInvalid(int i)
        {
            var sut = StoreRepository.Factory();
            var success = true;
            try
            {
                var store = sut.GetStore(i);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                success = false;
            }
            Assert.False(success);
        }
    }
}