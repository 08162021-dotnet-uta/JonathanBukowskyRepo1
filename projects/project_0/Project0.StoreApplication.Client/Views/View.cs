
using System;

namespace Project0.StoreApplication.Client.Views
{
    /* A View can return a new View object (or itself) to be run next.
        This will replace the current view with the returned view.
        A View can also use the RunView() method to open a "subview".
        A subview will run in the same manner as a View, until there are
        no more View objects left to be run. Execution will then return to the
        current View.
    */
    public abstract class View
    {
        // alternative to parameter: could provide some sort of GetContext();
        public abstract View Run(Context context);

        // Run() will iterate once. should probably be called "step" or similar
        // RunView() will continue until view returns null
        public static void RunView(View view, Context context)
        {
            do
            {
                view = view.Run(context);
            } while (view != null);
        }

        protected int SelectFromMenu(Func<string> GetMenu)
        {
            return SelectFromMenu(GetMenu, true);
        }
        protected int SelectFromMenu(Func<string> GetMenu, bool retry)
        {
            int choice;
            var menu = GetMenu();
            var menuLength = menu.Trim().Split().Length;
            bool parseSuccess = false;
            do
            {
                Console.WriteLine("\n\n" + menu);
                Console.Write(" Please enter a selection: ");
                parseSuccess = int.TryParse(Console.ReadLine(), out choice);
            } while (retry && (!parseSuccess || choice < 1 || choice > menuLength));
            return choice;
        }

    }
}