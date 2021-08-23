using System;
using System.Collections.Generic;
using Serilog;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Storage.Repositories;

using static Project0.StoreApplication.Client.Menus.CustomerMenus;
using Project0.StoreApplication.Client.Views;
using Project0.StoreApplication.Storage;
using Project0.StoreApplication.Domain.Interfaces;

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

    /// <summary>
    /// Defines the Program Class, which is the entry point into our application
    /// </summary>
    class Program
    {
        private const string logFile = "/home/jon/revature/my_code/data/project_0_logs/log.txt";
        private bool SaveLogToFile { get; set; }
        public Program()
        {
            // logging levels:
            // verbose
            // debug
            // info
            // warn
            // error
            // fatal

            // send log output to console by default
            SaveLogToFile = false;
        }

        public void CreateLogger()
        {
            if (SaveLogToFile)
            {
                Log.Logger = new LoggerConfiguration().WriteTo.File(logFile).CreateLogger();
            }
            else
            {
                Log.Logger = new LoggerConfiguration()
                                            .WriteTo.Console()
                                            .CreateLogger();
            }
        }

        /// <summary>
        /// Start the storefront application
        /// </summary>
        public void Run()
        {
            View mainMenu = new MainView();
            Context context = new Context();
            IStorageDAO dataStore = new XmlFileStorage();
            View.SetStorage(dataStore);
            View.RunView(mainMenu, context);
        }

        static void Main(string[] args)
        {
            Log.Information("Creating program instance");
            Program p = new Program();
            // TODO: get this from ENV?
            // if (ENV.save_to_file) p.SaveLogToFile = true;
            p.CreateLogger();
            Log.Information("Starting program");
            p.Run();
            //Playground();
        }

        // a little temporary function for me to test stuff in main without running app
        static void Playground()
        {
            var cr = CustomerRepository.Factory();
            /*
            Product p1 = new Product();
            Object p2 = new Product();
            Console.WriteLine(p1.GetType().Name);
            Console.WriteLine(p2 is Product);
            */
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
