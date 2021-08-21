
using System;
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Repositories;
using Serilog;

using static Project0.StoreApplication.Client.Menus.CustomerMenus;

namespace Project0.StoreApplication.Client.Views
{
    internal enum Action
    {
        SELECT_STORE = 1,
        VIEW_PRODUCT,
        PURCHASE_PRODUCT,
        VIEW_PURCHASE_HISTORY,
        EXIT
    }
    public class CustomerView : View
    {
        internal const int NUM_ACTIONS = 5;
        public override View Run(Context context)
        {
            Log.Debug("Inside CustomerView");
            Action action = (Action)SelectFromMenu(MainMenu, NUM_ACTIONS);
            Log.Debug("Selected main menu action {0}", action);
            switch (action)
            {
                case Action.SELECT_STORE:
                    //"1 - Select store\n"
                    // this should be its own view
                    context.SelectedStore = SelectAStore();
                    Log.Debug("User selected store {0}", context.SelectedStore);
                    Console.WriteLine("Selected store " + context.SelectedStore);
                    return this;
                case Action.VIEW_PRODUCT:
                    //"2 - Select products\n"
                    Console.WriteLine(PrintAllProducts());
                    return this;
                case Action.PURCHASE_PRODUCT:
                    //"3 - Purchase product\n"
                    //SelectAProduct();
                    RunView(new ProductSelectView(), context);
                    return this;
                case Action.VIEW_PURCHASE_HISTORY:
                    //"4 - View purchase history\n"
                    ViewPurchaseHistory();
                    return this;
                case Action.EXIT:
                    //"5 - Quit program\n"
                    // break from while, can finalize stuff here or outside loop
                    // TODO: this would be a good place for a confirmation message
                    return null;
                default:
                    Console.WriteLine("Error: Invalid selection.\n\n");
                    return this;
            }
        }

        Store SelectAStore()
        {
            var stores = StoreRepository.Factory().Stores;
            if (stores.Count == 0)
            {
                Console.WriteLine("No stores available.");
                return null;
            }
            Console.WriteLine("Select a store: ");
            var option = SelectFromMenu(PrintAllStoreLocations, stores.Count);
            if (option > stores.Count || option < 1)
            {
                // TODO: do some real handling instead of silently failing
                Console.WriteLine("Invalid selection");
                return null;
            }
            var store = stores[option - 1];
            return store;
            //return (stores[int.Parse(Console.ReadLine())]);
        }

        protected string PrintAllStoreLocations()
        {
            var storeRepo = StoreRepository.Factory();
            int i = 1;
            string output = "";
            foreach (var store in storeRepo.Stores)
            {
                output += (i++) + " - " + store + "\n";
            }
            return output;
        }

        void SelectAProduct()
        {
            // TODO: Implement me
            var products = ProductRepository.Factory().Products;
            if (products.Count == 0)
            {
                Console.WriteLine("No products found");
                return;
            }
            int index = SelectFromMenu(PrintAllProducts, products.Count);
        }

        protected string PrintAllProducts()
        {
            string output = "";
            int i = 1;
            foreach (var prod in ProductRepository.Factory().Products)
            {
                output += (i++) + " - " + prod + "\n";
            }
            return output;
        }
        void ViewPurchaseHistory()
        {
            // TODO: Implement me
            Console.WriteLine("No purchase history");
        }

    }
}