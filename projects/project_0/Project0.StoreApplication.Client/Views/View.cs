
using System;

namespace Project0.StoreApplication.Client.Views
{
    public abstract class View
    {
        public abstract void run();
        protected int SelectFromMenu(Func<string> GetMenu)
        {
            Console.WriteLine("\n\n" + GetMenu());
            Console.Write(" Please enter a selection: ");
            return int.Parse(Console.ReadLine());
        }

    }
}