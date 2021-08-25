
using System.Collections.Generic;
using Project0.StoreApplication.Client.Views.StoreMenu;
using Project0.StoreApplication.Domain.Abstracts;

namespace Project0.StoreApplication.Client.Views.Common
{
    /// <summary>
    /// Provides a menu for users to select a store from a list
    /// </summary>
    public class StoreSelectView : BaseView, IView
    {

        public List<string> GetMenuOptions()
        {
            return Storage.GetStores().ConvertAll((Store s) => s.ToString());
        }

        public bool HandleUserInput(string input)
        {
            int selection;
            if (!int.TryParse(input, out selection))
            {
                return false;
            }
            var stores = Storage.GetStores();
            if (selection > stores.Count || selection < 1)
            {
                return false;
            }
            CurrentContext.SelectedStore = stores[selection - 1];

            // set next view and notify success
            NextView = new StoreView();
            return true;
        }
    }
}