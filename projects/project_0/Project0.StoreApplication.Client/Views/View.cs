
using System;
using Project0.StoreApplication.Domain.Interfaces;

namespace Project0.StoreApplication.Client.Views
{
    // TODO: it seems like there's a better way to organize this
    //          I'm thinking I need a manager for the view to provide better control than
    //              this "return this vs null vs new View" paradigm
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
        // Run() method:
        //  -- override to implement a single cycle of the menu
        //  -- return null to return to last menu (exit menu)
        //  -- return this to cycle current menu again
        //  -- return new View to replace current menu
        //  -- use View.RunView() to open new menu "on the stack" (will return control to this menu after new menu exits)
        public abstract View Run(Context context);

        // DAO access -- injection into submenus
        protected static StorageDAO Storage;
        public static void SetStorage(StorageDAO storageDAO)
        {
            Storage = storageDAO;
        }

        // Run() will iterate once. should probably be called "step" or similar
        // RunView() will continue until view returns null
        public static void RunView(View view, Context context)
        {
            do
            {
                view = view.Run(context);
            } while (view != null);
        }

        protected int SelectFromMenu(Func<string> GetMenu, int numOptions)
        {
            return SelectFromMenu(GetMenu, numOptions, true);
        }
        protected int SelectFromMenu(Func<string> GetMenu, int numOptions, bool retry)
        {
            int choice;
            var menu = GetMenu();
            // TODO: this is hacky, menus could potentially have differing number of lines than number of selections
            //var menuLength = menu.Trim().Split("\n").Length;
            bool parseSuccess = false;
            do
            {
                Console.WriteLine("\n\n" + menu);
                Console.Write(" Please enter a selection: ");
                parseSuccess = int.TryParse(Console.ReadLine(), out choice);
            } while (retry && (!parseSuccess || choice < 1 || choice > numOptions));
            return choice;
        }

    }
}