
using System;

namespace Project0.StoreApplication.Client.Views
{
    public abstract class View
    {
        public abstract View run(Context context);
        protected int SelectFromMenu(Func<string> GetMenu)
        {
            int choice;
            do
            {
                Console.WriteLine("\n\n" + GetMenu());
                Console.Write(" Please enter a selection: ");
            } while (!int.TryParse(Console.ReadLine(), out choice));
            return choice;
        }

    }
}