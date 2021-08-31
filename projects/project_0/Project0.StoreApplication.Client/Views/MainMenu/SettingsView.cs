
using System.Collections.Generic;
using Project0.StoreApplication.Client.Views.Common;
using Project0.StoreApplication.Storage;

namespace Project0.StoreApplication.Client.Views.MainMenu
{
    public class SettingsView : BaseView, IView
    {
        private static readonly List<string> _menu = new List<string>()
        {
            "Save to DB",
            "Save to XML"
        };
        public List<string> GetMenuOptions()
        {
            return _menu;
        }

        public Actions HandleUserInput(string input, out IView nextView)
        {
            nextView = null;
            if (!int.TryParse(input, out int choice))
            {
                return Actions.REPEAT_PROMPT;
            }
            switch (choice)
            {
                case 1:
                    var dbStorage = new DBStorageImpl();
                    BaseView.SetStorage(dbStorage);
                    System.Console.WriteLine("Switched to database backend");
                    break;
                case 2:
                    var XMLStorage = new XmlFileStorage();
                    BaseView.SetStorage(XMLStorage);
                    System.Console.WriteLine("Switched to xml file backend");
                    break;
                default:
                    return Actions.REPEAT_PROMPT;
            }
            return Actions.CLOSE_MENU;
        }
    }
}