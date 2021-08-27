
using System.Collections.Generic;
using Project0.StoreApplication.Client.Views.Common;
using Project0.StoreApplication.Client.Views.CustomerMenu;
using Xunit;

namespace Project0.StoreApplication.Testing.ViewTesting
{
    [Collection("View Tests")]
    public class CustomerPurchaseViewTests : BaseViewTest
    {
        public CustomerPurchaseViewTests() : base()
        {
            _Sut = ViewFactory<CustomerPurchaseView>();
            var cust = _MockStorage.GetCustomers()[0];
            _Context.Customer = cust;
        }

        private static readonly List<string> _menu = new()
        {
            "Show cart",
            "Add product to cart",
            "Remove product from cart",
            "Save and exit"
        };

        [Fact]
        public void Test_CustomerPurchaseView_Menu()
        {
            Assert.Equal(_menu, _Sut.GetMenuOptions());
        }

        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        [InlineData("3")]
        [InlineData("4")]
        [InlineData("5")]
        [InlineData("0")]
        [InlineData("break please")]
        public void Test_CustomerPurchaseView_HandleInput(string mockInput)
        {
            IView nextView;
            var action = _Sut.HandleUserInput(mockInput, out nextView);

            switch (mockInput)
            {
                case "1":
                    Assert.Equal(Actions.RERUN_MENU, action);
                    break;
                case "2":
                    Assert.IsType<ProductSelectView>(nextView);
                    Assert.Equal(Actions.OPEN_SUBMENU, action);
                    break;
                case "3":
                    Assert.IsType<ProductSelectView>(nextView);
                    Assert.Equal(Actions.OPEN_SUBMENU, action);
                    break;
                case "4":
                    Assert.Equal(Actions.CLOSE_MENU, action);
                    break;
                default:
                    Assert.Equal(Actions.REPEAT_PROMPT, action);
                    break;
            }
        }
    }
}