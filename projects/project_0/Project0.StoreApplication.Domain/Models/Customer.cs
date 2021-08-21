using System.Collections.Generic;

using Project0.StoreApplication.Domain.Abstracts;

namespace Project0.StoreApplication.Domain.Models
{
    public class Customer
    {
        public Customer()
        {
            // TODO: load this from somewhere
            // jk lol, populate this in customer repo
            Purchases = new();
        }

        public string Name { get; set; }
        public List<Order> Purchases { get; set; }
        public Store SelectedStore { get; set; }
    }
}