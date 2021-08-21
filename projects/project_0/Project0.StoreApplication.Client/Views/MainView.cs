
using System;
using Serilog;

namespace Project0.StoreApplication.Client.Views
{
    internal enum LoginT
    {
        CUSTOMER = 1,
        STORE,
        QUIT
    }
    public class MainView : View
    {
        public override View Run(Context context)
        {
            Log.Debug("Inside MainView");
            //TODO: think of a better name than "login"?
            LoginT loginType = (LoginT)SelectFromMenu(LoginMenu);
            Log.Debug("Selected login type {}", (int)loginType);
            switch (loginType)
            {
                case LoginT.CUSTOMER:
                    RunView(new CustomerView(), context);
                    return this;
                case LoginT.STORE:
                    // TODO: implement
                    //View storeMenu = null;
                    Console.WriteLine("Store menu under construction");
                    return this;
                case LoginT.QUIT:
                    Console.WriteLine("Exiting program. Goodbye :)");
                    return null;
            }
            return null;
        }

        public static string LoginMenu()
        {
            const string output =
                "1 - Login as customer\n" +
                "2 - Login as store\n" +
                "3 - Exit program\n";
            return output;
        }
    }
}