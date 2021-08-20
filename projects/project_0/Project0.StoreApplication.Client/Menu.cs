
namespace Project0.StoreApplication.Client
{
    class StaticMenu
    {
        public static string LoginMenu()
        {
            const string output =
                "1 - Login as customer\n" +
                "2 - Login as store\n" +
                "3 - Exit program\n";
            return output;
        }

        public static string MainMenu()
        {
            // TODO: I don't know whether this is appropriate
            const string storeOutput = "1 - View transaction history";
            const string customerOutput =
                "1 - Select store\n" +
                "2 - View products\n" + // remove from list if store is selected?
                "3 - Purchase product\n" +
                "4 - View purchase history\n" +
                "5 - Quit program\n";
            // TODO: update logic here to actually work
            bool customer = true;
            if (customer)
                return customerOutput;
            else
                return storeOutput;
        }

    }
}