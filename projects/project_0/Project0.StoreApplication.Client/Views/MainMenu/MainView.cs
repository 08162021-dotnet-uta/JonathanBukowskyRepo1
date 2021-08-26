
using System.Collections.Generic;
using Project0.StoreApplication.Client.Views.Common;
using Project0.StoreApplication.Client.Views.StoreMenu;

namespace Project0.StoreApplication.Client.Views.MainMenu
{
    /// <summary>
    /// View to provide Main login menu
    /// </summary>
    public class MainView : BaseView, IView
    {
        private static readonly List<string> _menu = new()
        {
            "Login as customer",
            "Login as store",
            "Exit"
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
            var customers = Storage.GetCustomers();
            if (selection < 1 || selection > customers.Count)
            {
                return Actions.REPEAT_PROMPT;
            }
            nextView = this;
            switch (selection)
            {
                case 1:
                    //RunView(new CustomerSelectView(), CurrentContext);
                    nextView = new CustomerSelectView();
                    return Actions.OPEN_SUBMENU;
                case 2:
                    //RunView(new StoreSelectView(), CurrentContext);
                    nextView = new StoreSelectView();
                    return Actions.OPEN_SUBMENU;
                case 3:
                    return Actions.CLOSE_MENU;
                default:
                    throw new System.NotImplementedException("Not all selections implemented");
            }
        }
    }
}