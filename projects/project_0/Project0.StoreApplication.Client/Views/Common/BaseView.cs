
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
                // NOTE: this really shouldn't be necessary to do every iteration,
                // since every IView inherits from BaseView right now, but I don't
                // think we can technically rely on IViews to get context otherwise
                view.SetContext(context);

                var menu = view.GetMenuOptions();
                PrintMenu(menu);

                var prompt = view.GetPrompt();
                string userInput;
                Actions nextAction;
                do
                {
                    Console.Write(prompt);
                    userInput = Console.ReadLine();
                    nextAction = view.HandleUserInput(userInput, out nextView);
                } while (nextAction == Actions.REPEAT_PROMPT);

                switch (nextAction)
                {
                    case Actions.OPEN_SUBMENU:
                        RunView(nextView, context);
                        nextView = view;
                        break;
                    case Actions.CLOSE_MENU:
                        nextView = null;
                        break;
                    case Actions.CHANGE_MENU:
                        //nextView = view.NextView;
                        break;
                    case Actions.RERUN_MENU:
                        nextView = view;
                        break;
                    default:
                        throw new NotImplementedException("Not all actions implemented");
                }
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