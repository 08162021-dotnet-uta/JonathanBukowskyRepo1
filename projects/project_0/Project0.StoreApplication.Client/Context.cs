
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Domain.Abstracts;
using System.Collections.Generic;

namespace Project0.StoreApplication.Client
{
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