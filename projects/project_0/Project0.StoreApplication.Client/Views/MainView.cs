
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
        public override View run(Context context)
        {
            Log.Debug("Inside MainView");
            //TODO: think of a better name than "login"?
            LoginT loginType = (LoginT)SelectFromMenu(LoginMenu);
            Log.Debug("Selected login type {}", (int)loginType);
            switch (loginType)
            {
                case LoginT.CUSTOMER:
                    return new CustomerView();
                case LoginT.STORE:
                    View storeMenu = null;
                    // TODO: implement
                    Console.WriteLine("Store menu under construction");
                    return this;
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