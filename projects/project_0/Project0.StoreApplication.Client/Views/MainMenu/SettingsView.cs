
using System;
using System.Collections.Generic;
using Project0.StoreApplication.Client.Views.Common;
using Project0.StoreApplication.Storage;
using Serilog;

namespace Project0.StoreApplication.Client.Views.MainMenu
{
    public class SettingsView : BaseView, IView
    {
        private static readonly List<string> _menu = new List<string>()
        {
            "Save to DB",
            "Save to XML",
            "Log to console",
            "Log to file",
            "Save and exit"
        };
        public List<string> GetMenuOptions()
        {
            return _menu;
        }

        public Actions HandleUserInput(string input, out IView nextView)
        {
            Log.Information($"Inside SettingsView HandleInput");
            nextView = null;
            if (!int.TryParse(input, out int choice))
            {
                Log.Information($"Invalid input {input}");
                return Actions.REPEAT_PROMPT;
            }
            if (choice < 1 || choice > _menu.Count)
            {
                Log.Information($"Invalid choice {choice}");
                return Actions.REPEAT_PROMPT;
            }
            switch (choice)
            {
                case 1:
                    var dbStorage = new DBStorageImpl();
                    SetStorage(dbStorage);
                    Console.WriteLine("Switched to database backend");
                    break;
                case 2:
                    var XMLStorage = new XmlFileStorage();
                    SetStorage(XMLStorage);
                    Console.WriteLine("Switched to xml file backend");
                    break;
                case 3:
                    Program.MakeLogger(false);
                    break;
                case 4:
                    Program.MakeLogger(true);
                    break;
                case 5:
                    return Actions.CLOSE_MENU;
                default:
                    throw new NotImplementedException("Not all actions implemented");
            }
            return Actions.RERUN_MENU;
        }
    }
}