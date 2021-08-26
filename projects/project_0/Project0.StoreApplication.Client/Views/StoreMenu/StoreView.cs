
using System;
using System.Collections.Generic;
using Project0.StoreApplication.Client.Views.Common;

namespace Project0.StoreApplication.Client.Views.StoreMenu
{
    /// <summary>
    /// Provides the main menu for Stores
    /// </summary>
    public class StoreView : BaseView, IView
    {
        private static readonly List<string> _menu = new()
        {
            "View transactions",
            "Logout"
        };
        public List<string> GetMenuOptions()
        {
            return _menu;
        }

        public bool HandleUserInput(string input)
        {
            int selection;
            if (!int.TryParse(input, out selection))
            {
                return false;
            }
            NextView = this;
            switch (selection)
            {
                case 1:
                    ShowOrders();
                    break;
                case 2:
                    NextView = null;
                    break;
            }
            return true;
        }
        public void ShowOrders()
        {
            //var orders = OrderRepository.Factory().Orders.FindAll((Order o) => o.Store == context.SelectedStore);
            var orders = Storage.GetOrders(CurrentContext.SelectedStore);
            foreach (var order in orders)
            {
                Console.WriteLine(order);
            }
        }
    }
}