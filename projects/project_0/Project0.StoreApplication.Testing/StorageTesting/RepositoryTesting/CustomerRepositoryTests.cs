using Xunit;
using Project0.StoreApplication.Storage.Repositories;

namespace Project0.StoreApplication.Testing.StorageTesting.RepositoryTesting
{
    // TDD -- test driven development
    // red green refactor -- term for tdd, means 1 (red - create tests, all will fail), 2 (green - code until tests pass), 3 (refactor your code, tests should stay green)
    public class CustomerRepositoryTests
    {
        // need annotations ("attributes" in c#) for testing to work successfully
        [Fact]
        public void Test_CustomerCollectionNull()
        {
            RepositorySetup.InitializeSettings();
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
            RepositorySetup.InitializeSettings();
            var sut = CustomerRepository.Factory();
            var store = sut.Customers[i];
            Assert.NotNull(store);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(-1)]
        [InlineData(4)]
        [InlineData(3)]
        public void Test_OneCustomerInvalid(int i)
        {
            RepositorySetup.InitializeSettings();
            var sut = CustomerRepository.Factory();
            var success = true;
            try
            {
                var store = sut.Customers[i];
            }
            catch (System.ArgumentOutOfRangeException)
            {
                success = false;
            }
            Assert.False(success);
        }
    }
}