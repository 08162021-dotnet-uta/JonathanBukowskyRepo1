using Xunit;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Testing.ModelTesting
{
    /// <summary>
    /// Tests for the Customer class
    /// </summary>
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
            Assert.Equal(testName, actual);
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
            Assert.Contains(testName, actual);
        }

        [Fact]
        public void Test_Customer_HashCode()
        {
            var sut = new Customer() { Name = "Bob Dylan", CustomerID = 1 };
            var cust2 = new Customer() { Name = "Jimmy Kimmel", CustomerID = 2 };

            Assert.Equal(1, sut.GetHashCode());
            Assert.NotEqual(cust2.GetHashCode(), sut.GetHashCode());
        }

        [Fact]
        public void Test_Customer_Equals()
        {
            var sut = new Customer() { Name = "Bob Dylan", CustomerID = 1 };
            var cust2 = new Customer() { Name = "Jimmy Kimmel", CustomerID = 2 };
            Customer cust3 = null;

            Assert.True(sut.Equals(sut));
            Assert.False(sut.Equals(cust2));
            Assert.False(cust2.Equals(sut));
            Assert.False(sut.Equals(cust3));
        }

        [Fact]
        public void Test_Customer_Comparison_Operators()
        {
            var sut = new Customer() { Name = "Bob Dylan", CustomerID = 1 };
            var cust2 = new Customer() { Name = "Jimmy Kimmel", CustomerID = 2 };
            Customer cust3 = null;
            var cust4 = new Customer() { Name = "Bob Dylan", CustomerID = 1 };

            Assert.True(sut == cust4);
            Assert.True(sut != cust2);
            Assert.True(sut != cust3);
            Assert.True(cust4 == sut);
            Assert.True(cust2 != sut);
            Assert.True(cust3 != sut);
        }
    }
}