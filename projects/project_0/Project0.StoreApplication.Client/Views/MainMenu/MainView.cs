
using Project0.StoreApplication.Client.Views.Common;
using Project0.StoreApplication.Client.Views.StoreMenu;

namespace Project0.StoreApplication.Client.Views.MainMenu
{
    /// <summary>
    /// View to provide Main login menu
    /// </summary>
    public class MainView : StaticMenuView
    {
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
    }
}