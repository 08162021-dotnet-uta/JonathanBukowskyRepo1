
namespace Project0.StoreApplication.Client.Menus
{
    /// <summary>
    /// (Deprecated) Menu creation functions
    /// </summary>
    static class CustomerMenus
    {

        /// <summary>
        /// (Deprecated) Create main menu
        /// </summary>
        /// <returns>string containing main menu</returns>
        public static string MainMenu()
        {
            // TODO: I don't know whether this is appropriate
            const string storeOutput = "1 - View transaction history";
            const string customerOutput =
                "1 - Select store\n" +
                "2 - View products\n" + // remove from list if no store is selected?
                "3 - Purchase products\n" +
                "4 - View purchase history\n" +
                "5 - Checkout\n" +
                "6 - Exit menu\n";
            // TODO: update logic here to actually work
            bool customer = true;
            if (customer)
                return customerOutput;
            else
                return storeOutput;
        }

    }
}