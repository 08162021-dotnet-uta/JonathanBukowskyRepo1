using Xunit;
using Project0.StoreApplication.Storage.Repositories;

namespace Project0.StoreApplication.Testing.StorageTesting
{
    // TDD -- test driven development
    // red green refactor -- term for tdd, means 1 (red - create tests, all will fail), 2 (green - code until tests pass), 3 (refactor your code, tests should stay green)
    public class ProductRepositoryTests
    {
        [Fact]
        public void Test_ProductCollection()
        {
            RepositorySetup.InitializeSettings();
            var sut = ProductRepository.Factory();
            var actual = sut.Products;
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
        [InlineData(9)]
        public void Test_OneProduct(int i)
        {
            RepositorySetup.InitializeSettings();
            var sut = ProductRepository.Factory();
            var product = sut.Products[i];
            Assert.NotNull(product);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(-1)]
        [InlineData(15)]
        [InlineData(14)]
        public void Test_OneProductInvalid(int i)
        {
            RepositorySetup.InitializeSettings();
            var sut = ProductRepository.Factory();
            var success = true;
            try
            {
                var product = sut.Products[i];
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                success = false;
            }
            Assert.False(success);
        }
    }
}