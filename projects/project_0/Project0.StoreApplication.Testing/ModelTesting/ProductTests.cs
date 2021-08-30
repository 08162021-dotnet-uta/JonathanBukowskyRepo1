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
            var testPrice = 100.50m;
            sut.Name = testName;
            sut.Price = testPrice;
            var actual = sut.ToString();

            Assert.Contains(testName, actual);
            Assert.Contains("$100.50", actual);
        }

        [Fact]
        public void Test_Product_HashCode()
        {
            var sut = new Product() { ProductID = 1 };
            var product2 = new Product() { ProductID = 2 };

            Assert.Equal(1, sut.GetHashCode());
            Assert.NotEqual(product2.GetHashCode(), sut.GetHashCode());
        }

        [Fact]
        public void Test_Product_Equals()
        {
            var sut = new Product() { ProductID = 1 };
            var product2 = new Product() { ProductID = 2 };
            Product product3 = null;

            Assert.True(sut.Equals(sut));
            Assert.False(sut.Equals(product2));
            Assert.False(sut.Equals(product3));
            Assert.False(product2.Equals(sut));
        }

        [Fact]
        public void Test_Product_Comparison_Operators()
        {
            var sut = new Product() { ProductID = 1 };
            var product2 = new Product() { ProductID = 2 };
            Product product3 = null;
            var product4 = new Product() { ProductID = 1 };

            Assert.True(sut == product4);
            Assert.True(sut != product2);
            Assert.True(sut != product3);
            Assert.True(product4 == sut);
            Assert.True(product2 != sut);
            Assert.True(product3 != sut);
        }

    }
}