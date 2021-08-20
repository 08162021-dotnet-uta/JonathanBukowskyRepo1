using System.Collections.Generic;

using Project0.StoreApplication.Domain.Abstracts;

namespace Project0.StoreApplication.Domain.Models
{
    public class Customer
    {
        public Customer()
        {
            // TODO: load this from somewhere
            Purchases = new();
        }
        public List<Order> Purchases { get; }
        public Store SelectedStore { get; set; }
    }
}