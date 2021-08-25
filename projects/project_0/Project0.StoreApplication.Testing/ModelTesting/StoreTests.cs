using Xunit;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Testing.ModelTesting
{
    /// <summary>
    /// Tests for the Store class
    /// </summary>
    public class StoreTests
    {
        [Fact]
        public void Test_StoreCreationWithName()
        {
            var expectedName = "fred's pizza";
            var sut = new GroceryStore() { Name = expectedName };
            Assert.Equal(sut.Name, expectedName);
        }
        [Fact]
        public void Test_StoreCreation()
        {
            var store = new GroceryStore();
            Assert.NotNull(store);
        }
        [Fact]
        public void Test_StoreToString()
        {
            var expectedName = "fred's pizza";
            var sut = new GroceryStore() { Name = expectedName };
            var actual = sut.ToString();
            Assert.True(actual.Contains(expectedName));
        }
    }
}