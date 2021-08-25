
using System;

namespace Project0.StoreApplication.Client.Views
{
    /// <summary>
    /// Provides the main menu for Stores
    /// </summary>
    public class StoreView : StaticMenuView
    {
        public StoreView() : base()
        {
            RegisterAction(new MenuAction() { Description = "View transactions", DoAction = ShowOrders });
            RegisterAction(new MenuAction() { Description = "Logout", DoAction = (Context context) => null });
        }

        public View ShowOrders(Context context)
        {
            //var orders = OrderRepository.Factory().Orders.FindAll((Order o) => o.Store == context.SelectedStore);
            var orders = Storage.GetOrders(context.SelectedStore);
            foreach (var order in orders)
            {
                Console.WriteLine(order);
            }
            return this;
        }
    }
}