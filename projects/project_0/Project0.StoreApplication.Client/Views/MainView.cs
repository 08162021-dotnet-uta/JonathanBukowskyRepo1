
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
        public override void run()
        {
            Log.Debug("Inside MainView");
            LoginT loginType = (LoginT)SelectFromMenu(LoginMenu);
            Log.Debug("Selected login type {}", (int)loginType);
            switch (loginType)
            {
                case LoginT.CUSTOMER:
                    View custMenu = new CustomerView();
                    custMenu.run();
                    break;
                case LoginT.STORE:
                    View storeMenu = null;
                    // TODO: implement
                    break;
            }
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