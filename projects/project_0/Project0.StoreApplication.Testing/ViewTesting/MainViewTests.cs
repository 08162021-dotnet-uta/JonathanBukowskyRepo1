
using System;
using System.Collections.Generic;
using Project0.StoreApplication.Client;
using Project0.StoreApplication.Client.Views.Common;
using Project0.StoreApplication.Client.Views.MainMenu;
using Project0.StoreApplication.Domain.Models;
using Xunit;

namespace Project0.StoreApplication.Testing.ViewTesting
{
    public class MainViewTests : IDisposable
    {
        private IView sut;
        private Context context;
        public MainViewTests()
        {
            context = new Context();
            sut = new MainView();
            // TODO: might want to interact with mockStorage somehow here
            var mockStorage = new FakeStorage(this);
            BaseView.SetStorage(new FakeStorage(this));
            sut.SetContext(context);
        }

        public void Notify(string msg)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {

        }

        [Fact]
        public void Test_MainView_Menu()
        {
            var actual = sut.GetMenuOptions();

            Assert.Equal(new List<string>() {
                "Login as customer",
                "Login as store",
                "Exit"
            }, actual);
        }

        [Theory]
        [InlineData("1")]
        public void Test_MainView_HandleUserInput(string input)
        {
            var actual = sut.HandleUserInput(input);
        }
    }
}