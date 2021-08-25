
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
        /*
        public MainView() : base()
        {
            RegisterAction(new MenuAction() { Description = "Login as customer", DoAction = LoginCustomer });
            RegisterAction(new MenuAction() { Description = "Login as store", DoAction = LoginStore });
            RegisterAction(new MenuAction() { Description = "Exit", DoAction = (Context context) => null });
        }
        public View LoginCustomer(Context context)
        {
            RunView(new CustomerSelectView(), context);
            return this;
        }
        public View LoginStore(Context context)
        {
            RunView(new StoreSelectView(), context);
            RunView(new StoreView(), context);
            return this;
        }
        */

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

        public bool HandleUserInput(string input)
        {
            int selection;
            if (!int.TryParse(input, out selection))
            {
                return false;
            }
            var customers = Storage.GetCustomers();
            if (selection < 1 || selection > customers.Count)
            {
                return false;
            }
            NextView = this;
            switch (selection)
            {
                case 1:
                    RunView(new CustomerSelectView(), CurrentContext);
                    break;
                case 2:
                    RunView(new StoreSelectView(), CurrentContext);
                    break;
                case 3:
                    NextView = null;
                    break;
            }
            return true;
        }
    }
}