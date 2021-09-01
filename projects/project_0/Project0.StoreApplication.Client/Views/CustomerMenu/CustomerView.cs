
using System;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Client.Views.Common;
using System.Collections.Generic;
using Serilog;

namespace Project0.StoreApplication.Client.Views.CustomerMenu
{
    /// <summary>
    /// View to provide Customer main menu 
    /// </summary>
    public class CustomerView : BaseView, IView
    {

        private static readonly List<string> _menu = new()
        {
            "Select a store",
            "View products",
            "Edit cart",
            "Checkout",
            "View purchase history",
            "Logout"
        };
        public List<string> GetMenuOptions()
        {
            return _menu;
        }

        public Actions HandleUserInput(string input, out IView nextView)
        {
            Log.Debug($"inside customerView handleinput");
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
            switch (selection)
            {
                case 1:
                    //RunView(new StoreSelectView(), CurrentContext);
                    nextView = new StoreSelectView(this);
                    return Actions.CHANGE_MENU;
                case 2:
                    Console.WriteLine("\n");
                    foreach (var prod in Storage.GetProducts())
                    {
                        Console.WriteLine(prod);
                    }
                    return Actions.RERUN_MENU;
                case 3:
                    return PurchaseProducts(out nextView);
                case 4:
                    return Checkout(out nextView);
                case 5:
                    ShowOrders();
                    return Actions.RERUN_MENU;
                case 6:
                    return Actions.CLOSE_MENU;
                default:
                    throw new NotImplementedException("Not all actions implemented");
            }
        }

        public Actions PurchaseProducts(out IView nextView)
        {
            nextView = null;
            if (CurrentContext.SelectedStore == null)
            {
                Console.WriteLine("Select a store first!");
                return Actions.RERUN_MENU;
            }
            else
            {
                //RunView(new CustomerPurchaseView(), CurrentContext);
                nextView = new CustomerPurchaseView();
                return Actions.OPEN_SUBMENU;
            }
        }
        public void ShowOrders()
        {
            var orders = Storage.GetOrders(CurrentContext.Customer);
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
        }
        /// <summary>
        /// Save current cart into a new order
        /// </summary>
        /// <returns></returns>
        public Actions Checkout(out IView nextView)
        {
            nextView = null;
            if (CurrentContext.Customer == null)
            {
                Console.WriteLine("You must select a customer");
                return Actions.RERUN_MENU;
            }
            else if (CurrentContext.SelectedStore == null)
            {
                Console.WriteLine("You must select a store");
                return Actions.RERUN_MENU;
            }
            else if (CurrentContext.Cart.Count == 0)
            {
                Console.WriteLine("Your cart is empty");
                return Actions.RERUN_MENU;
            }
            Log.Debug($"Creating order {CurrentContext.Customer} {CurrentContext.SelectedStore} numprods: {CurrentContext.Cart.Count}");
            Order o = Storage.CreateOrder(CurrentContext.Customer, CurrentContext.SelectedStore, CurrentContext.Cart);
            if (o != null)
            {
                // TODO: actually check on whether save succeeded -- make sure this still works
                CurrentContext.Cart.Clear();
                Console.WriteLine("Order saved successfully: ");
                Console.WriteLine(o);
            }
            else
            {
                Console.WriteLine("Error saving order. Please try again. ");
            }
            return Actions.RERUN_MENU;
        }

    }
}