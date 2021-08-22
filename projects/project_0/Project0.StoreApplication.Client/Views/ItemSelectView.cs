
using System.Collections.Generic;

namespace Project0.StoreApplication.Client.Views
{
    public abstract class ItemSelectView<T> : View
    {
        protected abstract List<T> GetItems();
        protected abstract View HandleSelectedItem(Context context, int choice);
        public override View Run(Context context)
        {
            var items = GetItems();
            int choice = SelectFromMenu(() => PrintMenu(items), items.Count);
            return HandleSelectedItem(context, choice);
        }

        public string PrintMenu(List<T> items)
        {
            int i = 1;
            string output = "";
            foreach (var item in items)
            {
                output += (i++) + " - " + item + "\n";
            }
            return output;
        }
    }
}