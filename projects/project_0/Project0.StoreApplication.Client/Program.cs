using System;
using System.Collections.Generic;
using Serilog;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Storage.Repositories;

using static Project0.StoreApplication.Client.StaticMenu;

namespace Project0.StoreApplication.Client
{
    /* TODO: use action enum?
                "1 - Select store\n" +
                "2 - View products\n" + // remove from list if store is selected?
                "3 - Purchase product\n" +
                "4 - View purchase history\n" +
                "5 - Quit program\n";
    internal enum Action
    {
        SelectStore = 1,
        ViewProducts,
        PurchaseProduct,
        ViewPurchaseHistory,
        Quit
    }
                */
    class Program
    {
        public Program()
        {
            // logging levels:
            // verbose
            // debug
            // info
            // warn
            // error
            // fatal
            Log.Logger = new LoggerConfiguration()
                                            .WriteTo.Console()
                                            .CreateLogger();
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            p.run();
            //Playground();
        }

        // a little temporary function for me to test stuff in main without running app
        static void Playground()
        {
            Product p1 = new Product();
            Object p2 = new Product();
            Console.WriteLine(p1.GetType().Name);
            Console.WriteLine(p2 is Product);
        }

        void run()
        {
            Log.Information("Starting program");
            int loginType = SelectFromMenu(LoginMenu);
            if (loginType == 3)
            {
                return;
            }
            Log.Debug("Selected login type {}", loginType);
            int action;
            Store selectedStore = null;
            do
            {
                action = SelectFromMenu(MainMenu);
                Log.Debug("Selected main menu action {0}", action);
                switch (action)
                {
                    case 1:
                        //"1 - Select store\n"
                        selectedStore = SelectAStore();
                        Log.Debug("User selected store {0}", selectedStore);
                        Console.WriteLine("Selected store " + selectedStore);
                        break;
                    case 2:
                        //"2 - View products\n"
                        ViewProducts();
                        break;
                    case 3:
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
            //PrintAllStoreLocations();
            //Store s = SelectAStore();
            Log.Information("End of program");
        }

        void ViewProducts()
        {
            // TODO: Implement me
            Console.WriteLine("no products");
        }

        void ViewPurchaseHistory()
        {
            // TODO: Implement me
            Console.WriteLine("No purchase history");
        }

        Product PurchaseAProduct()
        {
            Product p = null;
            // TODO: Implement me
            Console.WriteLine("no products available");
            return p;
        }

        string PrintAllStoreLocations()
        {
            var storeRepo = GenericStoreRepo.Factory();
            int i = 1;
            string output = "";
            foreach (var store in storeRepo.Stores)
            {
                output += (i + " - " + store + "\n");
                i++;
            }
            return output;
        }

        int SelectFromMenu(Func<string> GetMenu)
        {
            Console.WriteLine("\n\n" + GetMenu());
            Console.Write(" Please enter a selection: ");
            return int.Parse(Console.ReadLine());
        }

        Store SelectAStore()
        {
            var stores = GenericStoreRepo.Factory().Stores;
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

        /**************** Static vs const vs readonly *********
            Static - a keyword that indicates that there should be a singular entity, with memory reserved at compile time (I need to research reference statics for when object initialization would happen).
                    static is applicable to user-defined type, and will modify members of that type to belong to the type itself and not the object instances
            Const - a keyword that indicates that a variable should be initialized with a value and never changed -- this variable is "static" and no memory is ever reserved, as it's compiled directly into the assembly.
                    const is applicable to member variables and local variables
            readonly - a keyword that indicates that an entity should be immutable. It is still up to the owner of that entity to properly initialize it, and still may be accessed as normal during initialization code.
                    readonly is applicable to members and structs
        */
    }
}
