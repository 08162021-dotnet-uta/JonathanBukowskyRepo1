using Xunit;
using Project0.StoreApplication.Storage.Repositories;
using Project0.StoreApplication.Domain.Abstracts;

namespace Project0.StoreApplication.Testing.StorageTesting.RepositoryTesting
{
    // TDD -- test driven development
    // red green refactor -- term for tdd, means 1 (red - create tests, all will fail), 2 (green - code until tests pass), 3 (refactor your code, tests should stay green)
    // NOTE: By default, xUnit tests run in parallel. This is not appropriate for reading/writing to file. Perhaps I should add tests for that, but as of now,
    //          the system is not intended to work in a parallelized environment, so I won't. Putting file IO tests into same collection to avoid parallelization
    /// <summary>
    /// Tests for Store Repository singleton
    /// </summary>
    [Collection("File IO Tests")]
    public class StoreRepositoryTests
    {
        // need annotations ("attributes" in c#) for testing to work successfully
        [Fact]
        public void Test_StoreCollection()
        {
            RepositorySetup.InitializeSettings();
            // arrange = get instance of the entity to test
            // "sut" - subject under test
            var sut = StoreRepository.Factory();

            // act = execute sut for data
            var actual = sut.Stores;

            // assert = condition by which test succeeds/fails
            Assert.NotNull(actual);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Test_OneStore(int i)
        {
            RepositorySetup.InitializeSettings();
            var sut = StoreRepository.Factory();
            var success = true;
            Store store = null;
            try
            {
                store = sut.GetStore(i);
            }
            catch
            {
                success = false;
            }
            Assert.NotNull(store);
            Assert.True(success);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(-1)]
        [InlineData(4)]
        [InlineData(0)]
        public void Test_OneStoreInvalid(int i)
        {
            RepositorySetup.InitializeSettings();
            var sut = StoreRepository.Factory();
            Store store = null;
            store = sut.GetStore(i);
            Assert.Null(store);
        }
    }
}