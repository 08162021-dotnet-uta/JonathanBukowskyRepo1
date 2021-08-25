
using System.Collections.Generic;

/// <summary>
/// Core/Common View constructs
/// </summary>
namespace Project0.StoreApplication.Client.Views.Common
{
    /// <summary>
    /// A base class to provide View functionality for selecting from a collection
    /// </summary>
    /// <typeparam name="T">The type of object in the collection</typeparam>
    public abstract class ItemSelectView<T> : View
    {
        /// <summary>
        /// Get the collection of items to select from
        /// </summary>
        /// <returns>List of selection candidates</returns>
        protected abstract List<T> GetItems();

        // TODO: I could probably just return the selected object instead of the index here. Would be more robust
        /// <summary>
        /// Handler to process user's item selection
        /// </summary>
        /// <param name="context">Current View context</param>
        /// <param name="choice">User's selected item (1 indexed)</param>
        /// <returns>Next View to display</returns>
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