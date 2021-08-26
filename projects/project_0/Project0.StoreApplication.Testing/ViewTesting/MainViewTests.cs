
using System.Collections.Generic;
using Project0.StoreApplication.Client.Views.Common;
using Project0.StoreApplication.Client.Views.MainMenu;
using Xunit;

namespace Project0.StoreApplication.Testing.ViewTesting
{
    public class MainViewTests : BaseViewTest
    {
        public MainViewTests() : base()
        {
            _Sut = GetView<MainView>();
        }

        [Fact]
        public void Test_MainView_Menu()
        {
            var actual = _Sut.GetMenuOptions();

            Assert.Equal(new List<string>() {
                "Login as customer",
                "Login as store",
                "Exit"
            }, actual);
        }

        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        [InlineData("3")]
        [InlineData("4")]
        [InlineData("0")]
        [InlineData("hi")]
        public void Test_MainView_HandleUserInput(string mockInput)
        {
            IView actualView;
            var actual = _Sut.HandleUserInput(mockInput, out actualView);

            switch (mockInput)
            {
                case "1":
                    Assert.Equal(Actions.OPEN_SUBMENU, actual);
                    Assert.IsType<CustomerSelectView>(actualView);
                    break;
                case "2":
                    Assert.Equal(Actions.OPEN_SUBMENU, actual);
                    Assert.IsType<StoreSelectView>(actualView);
                    break;
                case "3":
                    Assert.Equal(Actions.CLOSE_MENU, actual);
                    Assert.Null(actualView);
                    break;
                default:
                    Assert.Equal(Actions.REPEAT_PROMPT, actual);
                    break;
            }
        }
    }
}