
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
            "Settings",
            "Exit"
        };
        public List<string> GetMenuOptions()
        {
            return _menu;
        }

        public Actions HandleUserInput(string input, out IView nextView)
        {
            nextView = null;
            if (!int.TryParse(input, out int selection))
            {
                return Actions.REPEAT_PROMPT;
            }
            if (selection < 1 || selection > _menu.Count)
            {
                return Actions.REPEAT_PROMPT;
            }
            nextView = this;
            switch (selection)
            {
                case 1:
                    nextView = new CustomerSelectView();
                    return Actions.OPEN_SUBMENU;
                case 2:
                    nextView = new StoreSelectView(new StoreView());
                    return Actions.OPEN_SUBMENU;
                case 3:
                    nextView = new SettingsView();
                    return Actions.OPEN_SUBMENU;
                case 4:
                    return Actions.CLOSE_MENU;
                default:
                    throw new System.NotImplementedException("Not all selections implemented");
            }
        }
    }
}