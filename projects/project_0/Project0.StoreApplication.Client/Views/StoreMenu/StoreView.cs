
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

        public Actions HandleUserInput(string input, out IView nextView)
        {
            int selection;
            nextView = null;
            if (!int.TryParse(input, out selection))
            {
                return Actions.REPEAT_PROMPT;
            }
            switch (selection)
            {
                case 1:
                    ShowOrders();
                    return Actions.RERUN_MENU;
                case 2:
                    return Actions.CLOSE_MENU;
                default:
                    throw new NotImplementedException("Selections not fully implemented");
            }
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