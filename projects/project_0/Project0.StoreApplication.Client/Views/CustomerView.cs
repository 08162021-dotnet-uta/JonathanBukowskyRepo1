
using System;
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Repositories;
using Serilog;

using static Project0.StoreApplication.Client.Menus.CustomerMenus;

namespace Project0.StoreApplication.Client.Views
{
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
            //var orders = OrderRepository.Factory().Orders.FindAll((Order o) => o.Customer == context.Customer);
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
            //Order o = new Order(context.Customer, context.SelectedStore, context.Cart);
            if (Storage.CreateOrder(context.Customer, context.SelectedStore, context.Cart))
            {
                // TODO: actually check on whether save succeeded -- make sure this still works
                context.Cart.Clear();
                Console.WriteLine("Order saved successfully");
            }
            else
            {
                Console.WriteLine("Error saving order. Please try again. ");
            }
            //var repo = OrderRepository.Factory();
            //repo.Orders.Add(o);
            //repo.SaveOrders();
            return this;
        }
        protected string PrintAllProducts()
        {
            string output = "";
            int i = 1;
            //foreach (var prod in ProductRepository.Factory().Products)
            foreach (var prod in Storage.GetProducts())
            {
                output += (i++) + " - " + prod + "\n";
            }
            return output;
        }
    }
}