
using System;
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Interfaces;

namespace Project0.StoreApplication.Client.Views.Common
{
    public abstract class BaseView
    {
        protected static Context CurrentContext { get; private set; }
        public void SetContext(Context context)
        {
            CurrentContext = context;
        }
        public static IStorageDAO Storage { get; private set; }

        public static void SetStorage(IStorageDAO storage)
        {
            Storage = storage;
        }
        private IView _nextView;
        public IView NextView { get => _nextView; protected set => _nextView = value; }

        // default implementation of GetPrompt
        public virtual string GetPrompt()
        {
            return "\n\n\tPlease enter a selection: ";
        }
        public static void RunView(IView view, Context context)
        {
            IView nextView;
            do
            {
                // TODO: this really shouldn't be necessary to do every iteration,
                // but I don't think we can rely on IViews to get context otherwise
                view.SetContext(context);

                var menu = view.GetMenuOptions();
                PrintMenu(menu);

                var prompt = view.GetPrompt();
                string userInput;
                do
                {
                    Console.Write(prompt);
                    userInput = Console.ReadLine();
                } while (!view.HandleUserInput(userInput));

                // TODO: it would probably be better for views to not select the next one...
                nextView = view.NextView;
            } while ((view = nextView) != null);
        }

        private static void PrintMenu(List<string> menuOptions)
        {
            int i = 1;
            foreach (var item in menuOptions)
            {
                // TODO: *could* replace "\n" with "\n\t" here to make output consistent?
                Console.WriteLine($"{i++} - {item}");
            }
        }

    }
}