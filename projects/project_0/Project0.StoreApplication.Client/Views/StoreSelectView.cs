
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Abstracts;

namespace Project0.StoreApplication.Client.Views
{
    /// <summary>
    /// Provides a menu for users to select a store from a list
    /// </summary>
    public class StoreSelectView : ItemSelectView<Store>
    {
        protected override List<Store> GetItems()
        {
            //return StoreRepository.Factory().Stores;
            return Storage.GetStores();
        }

        protected override View HandleSelectedItem(Context context, int choice)
        {
            context.SelectedStore = GetItems()[choice - 1];
            return null;
        }
    }
}