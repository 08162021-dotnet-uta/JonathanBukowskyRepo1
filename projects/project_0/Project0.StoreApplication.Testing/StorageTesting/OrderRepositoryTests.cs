using Xunit;
using Project0.StoreApplication.Storage.Repositories;

namespace Project0.StoreApplication.Testing.StorageTesting
{
    // TDD -- test driven development
    // red green refactor -- term for tdd, means 1 (red - create tests, all will fail), 2 (green - code until tests pass), 3 (refactor your code, tests should stay green)
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
            var order = sut.Orders[i];
            Assert.NotNull(order);
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
            try
            {
                var product = sut.Orders[i];
            }
            catch (System.ArgumentOutOfRangeException)
            {
                success = false;
            }
            Assert.False(success);
        }
    }
}