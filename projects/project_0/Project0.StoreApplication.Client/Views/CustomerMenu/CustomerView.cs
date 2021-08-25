
using System;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Client.Views.Common;

namespace Project0.StoreApplication.Client.Views.CustomerMenu
{
    /// <summary>
    /// View to provide Customer main menu 
    /// </summary>
    public class CustomerView : StaticMenuView
    {

        public CustomerView() : base()
        {
            RegisterAction(new MenuAction() { Description = "Select a store", DoAction = SelectStore });
            RegisterAction(new MenuAction() { Description = "View products", DoAction = PrintProducts });
            RegisterAction(new MenuAction() { Description = "Purchase a product", DoAction = PurchaseProducts });
            RegisterAction(new MenuAction() { Description = "View purchases", DoAction = ViewPurchases });
            RegisterAction(new MenuAction() { Description = "Checkout", DoAction = Checkout });
            RegisterAction(new MenuAction() { Description = "Logout", DoAction = (Context context) => null });
        }

        public View SelectStore(Context context)
        {
            RunView(new StoreSelectView(), context);
            return this;
        }

        public View PrintProducts(Context context)
        {
            Console.Write(PrintAllProducts());
            return this;
        }

        public View PurchaseProducts(Context context)
        {
            if (context.SelectedStore == null)
            {
                Console.WriteLine("Select a store first!");
            }
            else
            {
                RunView(new CustomerPurchaseView(), context);
            }
            return this;
        }

        public View ViewPurchases(Context context)
        {
            var orders = Storage.GetOrders(context.Customer);
            if (orders.Count == 0)
            {
                Console.WriteLine("No purchase history");
            }
            else
            {
                foreach (var order in orders)
                {
                    Console.WriteLine(order);
                }
            }
            return this;
        }

        /// <summary>
        /// Save current cart into a new order
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public View Checkout(Context context)
        {
            if (context.Customer == null)
            {
                Console.WriteLine("You must select a customer");
                return this;
            }
            else if (context.SelectedStore == null)
            {
                Console.WriteLine("You must select a store");
                return this;
            }
            else if (context.Cart.Count == 0)
            {
                Console.WriteLine("Your cart is empty");
                return this;
            }
            Order o = Storage.CreateOrder(context.Customer, context.SelectedStore, context.Cart);
            if (o != null)
            {
                // TODO: actually check on whether save succeeded -- make sure this still works
                context.Cart.Clear();
                Console.WriteLine("Order saved successfully: ");
                Console.WriteLine(o);
            }
            else
            {
                Console.WriteLine("Error saving order. Please try again. ");
            }
            return this;
        }
        protected string PrintAllProducts()
        {
            string output = "";
            int i = 1;
            foreach (var prod in Storage.GetProducts())
            {
                output += (i++) + " - " + prod + "\n";
            }
            return output;
        }
    }
}