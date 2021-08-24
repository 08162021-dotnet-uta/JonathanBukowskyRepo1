using Xunit;
using Project0.StoreApplication.Storage.Repositories;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Testing.StorageTesting.RepositoryTesting
{
    // TDD -- test driven development
    // red green refactor -- term for tdd, means 1 (red - create tests, all will fail), 2 (green - code until tests pass), 3 (refactor your code, tests should stay green)
    // Put file IO tests into same collection to turn off parallel tests because of file IO
    [Collection("File IO Tests")]
    public class OrderRepositoryTests
    {
        [Fact]
        public void Test_OrderCollection()
        {
            RepositorySetup.InitializeSettings();
            var sut = OrderRepository.Factory();
            var actual = sut.Orders;
            Assert.NotNull(actual);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        public void Test_OneOrder(int i)
        {
            RepositorySetup.InitializeSettings();
            var sut = OrderRepository.Factory();
            var success = true;
            Order order = null;
            try
            {
                order = sut.Orders[i];
            }
            catch
            {
                success = false;
            }
            Assert.NotNull(order);
            Assert.True(success);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(-1)]
        [InlineData(15)]
        [InlineData(9)]
        public void Test_OneOrderInvalid(int i)
        {
            RepositorySetup.InitializeSettings();
            var sut = OrderRepository.Factory();
            var success = true;
            Order order = null;
            try
            {
                order = sut.Orders[i];
            }
            catch (System.ArgumentOutOfRangeException)
            {
                success = false;
            }
            Assert.False(success);
            Assert.Null(order);
        }
    }
}