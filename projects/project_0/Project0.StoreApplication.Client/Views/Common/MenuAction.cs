
using System;

namespace Project0.StoreApplication.Client.Views.Common
{
    /// <summary>
    /// Encapsulates a handler for a menu item
    /// </summary>
    public class MenuAction
    {
        /// <summary>
        /// The text to display to user for this menu item
        /// </summary>
        /// <value></value>
        public string Description { get; set; }

        /// <summary>
        /// The action to perform when user selects this menu item
        /// </summary>
        /// <value></value>
        public Func<Context, View> DoAction { get; set; }
    }
}