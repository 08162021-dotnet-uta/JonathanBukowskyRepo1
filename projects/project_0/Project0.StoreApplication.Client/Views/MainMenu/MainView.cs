
using System.Collections.Generic;
using Project0.StoreApplication.Client.Views.Common;
using Project0.StoreApplication.Client.Views.StoreMenu;
using Serilog;

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
            Log.Debug("Inside MainView HandleInput");
            nextView = null;
            if (!int.TryParse(input, out int selection))
            {
                Log.Debug($"Invalid input {input}");
                return Actions.REPEAT_PROMPT;
            }
            if (selection < 1 || selection > _menu.Count)
            {
                Log.Debug($"Invalid selection {input}");
                return Actions.REPEAT_PROMPT;
            }
            nextView = this;
            Log.Debug($"Input: {input}");
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