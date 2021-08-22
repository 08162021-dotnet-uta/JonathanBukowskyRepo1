
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Storage.Repositories;

namespace Project0.StoreApplication.Client.Views
{
    public class StoreSelectView : ItemSelectView<Store>
    {
        protected override List<Store> GetItems()
        {
            return StoreRepository.Factory().Stores;
        }

        protected override View HandleSelectedItem(Context context, int choice)
        {
            context.SelectedStore = GetItems()[choice - 1];
            return null;
        }
    }
}