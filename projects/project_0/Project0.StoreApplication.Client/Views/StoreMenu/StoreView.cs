
using System;
using System.Collections.Generic;
using Project0.StoreApplication.Client.Views.Common;
using Serilog;

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
            Log.Information($"Inside StoreView {input}");
            nextView = null;
            if (!int.TryParse(input, out int selection))
            {
                Log.Information($"Invalid input {input}");
                return Actions.REPEAT_PROMPT;
            }
            if (selection < 1 || selection > _menu.Count)
            {
                Log.Information($"Invalid selection {input}");
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