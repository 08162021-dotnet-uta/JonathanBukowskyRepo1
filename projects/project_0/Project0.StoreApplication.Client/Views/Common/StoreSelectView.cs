
using System.Collections.Generic;
using Project0.StoreApplication.Client.Views.StoreMenu;
using Project0.StoreApplication.Domain.Abstracts;
using Serilog;

namespace Project0.StoreApplication.Client.Views.Common
{
    /// <summary>
    /// Provides a menu for users to select a store from a list
    /// </summary>
    public class StoreSelectView : BaseView, IView
    {

        private IView _nextView;
        public StoreSelectView(IView nextView) : base()
        {
            _nextView = nextView;
        }

        public List<string> GetMenuOptions()
        {
            return Storage.GetStores().ConvertAll((Store s) => s.ToString());
        }

        public string GetPrompt()
        {
            return "\n\n\tPlease select a store: ";
        }

        public Actions HandleUserInput(string input, out IView nextView)
        {
            Log.Information($"inside storeview handleinput");
            nextView = null;
            if (!int.TryParse(input, out int selection))
            {
                Log.Information($"Invalid input {input}");
                return Actions.REPEAT_PROMPT;
            }
            var stores = Storage.GetStores();
            if (selection > stores.Count || selection < 1)
            {
                Log.Information($"Invalid selection {selection}");
                return Actions.REPEAT_PROMPT;
            }
            CurrentContext.SelectedStore = stores[selection - 1];

            // set next view and notify success
            nextView = _nextView;
            return Actions.CHANGE_MENU;
        }
    }
}