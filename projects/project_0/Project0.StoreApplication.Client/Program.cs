using Serilog;

using Project0.StoreApplication.Client.Views.Common;
using Project0.StoreApplication.Client.Views.MainMenu;
using Project0.StoreApplication.Storage;
using Project0.StoreApplication.Domain.Interfaces;
using Project0.StoreApplication.Domain.Settings;

/// <summary>
/// The entry point into the frontend of StoreApplication
/// </summary>
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
        // TODO: move this to settings
        private const string logFile = "/home/jon/revature/my_code/data/project_0_logs/log.txt";
        private bool _saveToLogFile = false;
        public Program()
        {
            // logging levels:
            // verbose
            // debug
            // info
            // warn
            // error
            // fatal
        }

        public void MakeLogger()
        {
            if (_saveToLogFile)
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
            // use default settings object -- could populate settings based on environment/saved user settings/etc.
            CurrentSettings.Settings = new ApplicationSettings();
            // create an interface to the persistent data
            IStorage dataStore = new XmlFileStorage();
            // set up frontend needs
            IView mainMenu = new MainView();
            Context context = new Context();
            // give frontend access to persistent storage
            // TODO: maybe this should be in the context?
            BaseView.SetStorage(dataStore);
            // start main menu
            BaseView.RunView(mainMenu, context);
        }

        static void Main(string[] args)
        {
            // TODO: get this from ENV?
            const bool testRun = false;
            Log.Information("Creating program instance");
            Program p = new Program();
            // TODO: get this from ENV?
            // if (ENV.save_to_file) p.SaveLogToFile = true;
            p.MakeLogger();
            Log.Information("Starting program");


            if (testRun)
            {
                Playground();
            }
            else
            {
                p.Run();
            }
        }

        // a little temporary function for me to test stuff in main without running app
        static void Playground()
        {
            /*
            DemoEF demo = new();
            demo.SetCustomer(new Domain.Models.Customer() { Name = "Test Customer ORM" });
            foreach (var c in demo.GetCustomers())
            {
                System.Console.WriteLine(c);
            }
            */
            // This is gonna get a little messy... trying to fix some saved data so that it fits the new code
            /*
            CurrentSettings.Settings = new ApplicationSettings();
            var oRepo = OrderRepository.Factory();
            var objs = oRepo.GetOrderXMLs();

            var cRepo = CustomerRepository.Factory();
            var sRepo = StoreRepository.Factory();
            var pRepo = ProductRepository.Factory();
            int i = 1;
            Console.WriteLine(cRepo.Customers.Count);
            Console.WriteLine(sRepo.Stores.Count);
            foreach (OrderXML o in objs)
            {
                var c = cRepo.GetCustomer(o.Customer);
                var s = sRepo.GetStore(o.Store);
                if (c == null || s == null)
                {
                    Console.WriteLine($"Order info: Customer {o.Customer}, Store {o.Store}, Prods: {o.Products}");
                    Console.WriteLine($"c: {c}, s: {s}");
                }
                List<Product> prods = new();
                o.Products.ForEach((int prodID) =>
                {
                    prods.Add(pRepo.GetProduct(prodID));
                });
                Order ord = new Order(c, s, prods);
                ord.OrderID = i++;
                c.Orders.Add(ord);
                s.Orders.Add(ord);
            }
            cRepo.SaveCustomers();
            sRepo.SaveStores();

            //var cr = CustomerRepository.Factory();
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
