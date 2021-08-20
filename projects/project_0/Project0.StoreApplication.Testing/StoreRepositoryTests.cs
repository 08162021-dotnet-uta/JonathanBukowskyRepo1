using Xunit;
using Project0.StoreApplication.Storage.Repositories;

namespace Project0.StoreApplication.Testing
{
    // TDD -- test driven development
    // red green refactor -- term for tdd, means 1 (red - create tests, all will fail), 2 (green - code until tests pass), 3 (refactor your code, tests should stay green)
    public class StoreRepositoryTests
    {
        // need annotations ("attributes" in c#) for testing to work successfully
        [Fact]
        public void Test_StoreCollection()
        {
            // arrange = get instance of the entity to test
            // "sut" - subject under test
            var sut = new StoreRepository();

            // act = execute sut for data
            var actual = sut.Stores;

            // assert = condition by which test succeeds/fails
            Assert.NotNull(actual);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void Test_OneStore(int i)
        {
            var sut = new StoreRepository();
            var store = sut.GetStore(i);
            Assert.NotNull(store);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(-1)]
        [InlineData(4)]
        public void Test_OneStoreInvalid(int i)
        {
            var sut = new StoreRepository();
            var store = sut.GetStore(i);
            Assert.Null(store);
        }
    }
}