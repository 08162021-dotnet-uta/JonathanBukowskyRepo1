
using System;
using Serilog;

namespace Project0.StoreApplication.Client.Views
{
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