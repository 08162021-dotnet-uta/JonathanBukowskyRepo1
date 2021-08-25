
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
        public Customer Customer { get; set; }
        public Store SelectedStore { get; set; }
        public List<Product> Cart { get; }
    }
}