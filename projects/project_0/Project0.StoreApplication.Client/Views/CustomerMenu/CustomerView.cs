
using System;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Client.Views.Common;
using System.Collections.Generic;

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

        public bool HandleUserInput(string input)
        {
            int selection;
            if (!int.TryParse(input, out selection))
            {
                return false;
            }
            NextView = this;
            switch (selection)
            {
                case 1:
                    RunView(new StoreSelectView(), CurrentContext);
                    break;
                case 2:
                    Console.WriteLine("\n");
                    foreach (var prod in Storage.GetProducts())
                    {
                        Console.WriteLine(prod);
                    }
                    break;
                case 3:
                    PurchaseProducts();
                    break;
                case 4:
                    Checkout();
                    break;
                case 5:
                    ShowOrders();
                    break;
                case 6:
                    NextView = null;
                    break;

            }
            return true;
        }

        public void PurchaseProducts()
        {
            if (CurrentContext.SelectedStore == null)
            {
                Console.WriteLine("Select a store first!");
            }
            else
            {
                RunView(new CustomerPurchaseView(), CurrentContext);
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
        public void Checkout()
        {
            if (CurrentContext.Customer == null)
            {
                Console.WriteLine("You must select a customer");
                return;
            }
            else if (CurrentContext.SelectedStore == null)
            {
                Console.WriteLine("You must select a store");
                return;
            }
            else if (CurrentContext.Cart.Count == 0)
            {
                Console.WriteLine("Your cart is empty");
                return;
            }
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
        }

    }
}