
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
        SELECT_PRODUCT,
        PURCHASE_PRODUCT,
    }
    public class CustomerView : View
    {
        public override View run(Context context)
        {
            Log.Debug("Inside CustomerView");
            do
            {
                Action action = (Action)SelectFromMenu(MainMenu);
                Log.Debug("Selected main menu action {0}", action);
                switch (action)
                {
                    case Action.SELECT_STORE:
                        //"1 - Select store\n"
                        context.SelectedStore = SelectAStore();
                        Log.Debug("User selected store {0}", context.SelectedStore);
                        Console.WriteLine("Selected store " + context.SelectedStore);
                        break;
                    case Action.SELECT_PRODUCT:
                        //"2 - Select products\n"
                        SelectAProduct();
                        break;
                    case Action.PURCHASE_PRODUCT:
                        //"3 - Purchase product\n"
                        Product p = PurchaseAProduct();
                        if (p != null)
                        {
                            // TODO: persist?
                        }
                        break;
                    case 4:
                        //"4 - View purchase history\n"
                        ViewPurchaseHistory();
                        break;
                    case 5:
                        //"5 - Quit program\n"
                        // break from while, can finalize stuff here or outside loop
                        // TODO: this would be a good place for a confirmation message
                        Console.WriteLine("Exiting program. Goodbye :)");
                        break;
                    default:
                        Console.WriteLine("Error: Invalid selection.\n\n");
                        break;
                }
            } while (action != 5);
            return null;
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
            var option = SelectFromMenu(PrintAllStoreLocations);
            if (option > stores.Count || option < 1)
            {
                // TODO: do some real handling instead of silently failing
                return null;
            }
            var store = stores[option - 1];
            return store;
            //return (stores[int.Parse(Console.ReadLine())]);
        }

        string PrintAllStoreLocations()
        {
            var storeRepo = StoreRepository.Factory();
            int i = 1;
            string output = "";
            foreach (var store in storeRepo.Stores)
            {
                output += (i + " - " + store + "\n");
                i++;
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
            int index = SelectFromMenu(PrintAllProducts);
        }

        string PrintAllProducts()
        {
            string output = "";
            int i = 1;
            foreach (var prod in ProductRepository.Factory().Products)
            {
                output += i + " - " + prod + "\n";
            }
            return output;
        }
    }
}