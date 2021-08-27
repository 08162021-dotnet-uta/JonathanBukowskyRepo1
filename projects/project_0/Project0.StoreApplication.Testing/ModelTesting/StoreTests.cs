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
            Assert.Contains(expectedName, actual);
        }

        [Fact]
        public void Test_Store_HashCode()
        {
            var sut = new GroceryStore() { StoreID = 1 };
            var store2 = new GroceryStore() { StoreID = 2 };

            Assert.Equal(1, sut.GetHashCode());
            Assert.NotEqual(store2.GetHashCode(), sut.GetHashCode());
        }

        [Fact]
        public void Test_Store_Equals()
        {
            var sut = new GroceryStore() { StoreID = 1 };
            var store2 = new GroceryStore() { StoreID = 2 };
            GroceryStore store3 = null;

            Assert.True(sut.Equals(sut));
            Assert.False(sut.Equals(store2));
            Assert.False(sut.Equals(store3));
            Assert.False(store2.Equals(sut));
        }

        [Fact]
        public void Test_Store_Comparison_Operators()
        {
            var sut = new GroceryStore() { StoreID = 1 };
            var store2 = new GroceryStore() { StoreID = 2 };
            GroceryStore store3 = null;
            var store4 = new GroceryStore() { StoreID = 1 };

            Assert.True(sut == store4);
            Assert.True(sut != store2);
            Assert.True(sut != store3);
            Assert.True(store4 == sut);
            Assert.True(store2 != sut);
            Assert.True(store3 != sut);
        }

    }
}