using Xunit;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Testing
{
    /// <summary>
    /// Tests for the Product class
    /// </summary>
    public class ProductTests
    {
        [Fact]
        public void Test_ProductCreation()
        {
            // TODO: add more here to test members and stuff
            // arrange = get instance of the entity to test
            // "sut" - subject under test
            var sut = new Product();

            // act = execute sut for data
            var actual = sut;

            // assert = condition by which test succeeds/fails
            Assert.NotNull(actual);
        }

        [Fact]
        public void Test_ProductToString()
        {
            var sut = new Product();
            var testName = "Bounty soap";
            sut.Name = testName;
            var actual = sut.ToString();

            Assert.True(actual.Contains(testName));
        }
    }
}