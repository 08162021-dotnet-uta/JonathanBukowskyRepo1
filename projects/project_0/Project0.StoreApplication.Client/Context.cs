
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Domain.Abstracts;
using System.Collections.Generic;

namespace Project0.StoreApplication.Client
{
    /// <summary>
    /// Encapsulates data relative to user's menu navigation/operations into a single object
    /// </summary>
    public class Context
    {
        public Context()
        {
            Cart = new();
        }
        /// <summary>
        /// The currently selected customer (used for login)
        /// </summary>
        /// <value></value>
        public Customer Customer { get; set; }

        // TODO: this should probably not be reused for multiple purposes. Perhaps I should create the context after "login"?
        /// <summary>
        /// The currently selected store (used for login + customer purchases)
        /// </summary>
        /// <value></value>
        public Store SelectedStore { get; set; }

        /// <summary>
        /// The current cart (used in customer menus)
        /// </summary>
        /// <value></value>
        public List<Product> Cart { get; }
    }
}