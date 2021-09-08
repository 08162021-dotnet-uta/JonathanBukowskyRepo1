
using System.Collections.Generic;
using Project0.StoreApplication.Client.Views.Common;
using Project0.StoreApplication.Client.Views.CustomerMenu;
using Xunit;

namespace Project0.StoreApplication.Testing.ViewTesting
{
    [Collection("View Tests")]
    public class CustomerViewTests : BaseViewTest
    {
        public CustomerViewTests() : base()
        {
            _Sut = ViewFactory<CustomerView>();
        }

        private static readonly List<string> _menu = new()
        {
            "Select a store",
            "View products",
            "Edit cart",
            "Checkout",
            "View purchase history",
            "Logout"
        };

        [Fact]
        public void Test_CustomerViewMenu()
        {
            Assert.Equal(_menu, _Sut.GetMenuOptions());
        }

        [Theory(Skip = "Old setup")]
        [InlineData("1")]
        [InlineData("2")]
        [InlineData("3")]
        [InlineData("4")]
        [InlineData("5")]
        [InlineData("5")]
        [InlineData("6")]
        [InlineData("0")]
        [InlineData("7")]
        [InlineData("break")]
        public void Test_CustomerView_HandleInput(string mockInput)
        {
            IView nextView;
            var action = _Sut.HandleUserInput(mockInput, out nextView);

            switch (mockInput)
            {
                case "1":
                    Assert.IsType<StoreSelectView>(nextView);
                    Assert.Equal(Actions.OPEN_SUBMENU, action);
                    break;
                case "2":
                    Assert.Equal(Actions.RERUN_MENU, action);
                    break;
                case "3":
                    Assert.Equal(Actions.RERUN_MENU, action);
                    _Context.SelectedStore = _MockStorage.GetStores()[0];

                    // re-run with store selected
                    action = _Sut.HandleUserInput(mockInput, out nextView);
                    Assert.IsType<CustomerPurchaseView>(nextView);
                    Assert.Equal(Actions.OPEN_SUBMENU, action);
                    break;
                case "4":
                    Assert.Equal(Actions.RERUN_MENU, action);
                    break;
                case "5":
                    Assert.Equal(Actions.RERUN_MENU, action);
                    break;
                case "6":
                    Assert.Equal(Actions.CLOSE_MENU, action);
                    break;
                default:
                    Assert.Equal(Actions.REPEAT_PROMPT, action);
                    break;
            }
        }
    }
}