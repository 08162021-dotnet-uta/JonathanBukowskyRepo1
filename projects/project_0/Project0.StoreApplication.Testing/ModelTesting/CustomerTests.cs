using Xunit;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Testing.ModelTesting
{
    public class CustomerTests
    {
        [Fact]
        public void Test_CustomerCreation()
        {
            var sut = new Customer();
            Assert.NotNull(sut);
        }
        [Fact]
        public void Test_CustomerCreationWithName()
        {
            var testName = "Bob Dylan";
            var sut = new Customer() { Name = testName };
            var actual = sut?.Name;
            Assert.NotNull(sut);
            Assert.Equal(actual, testName);
        }
        [Fact]
        public void Test_CustomerToString()
        {
            // arrange = get instance of the entity to test
            // "sut" - subject under test
            var sut = new Customer();
            var testName = "Bob Dylan";
            sut.Name = testName;

            // act = execute sut for data
            // TODO: purchases will now come from Repo.getpurchases -- idk if this is good
            var actual = sut.ToString();

            // assert = condition by which test succeeds/fails
            Assert.True(actual.Contains(testName));
        }
    }
}