using System.Collections.Generic;

using Project0.StoreApplication.Domain.Abstracts;

namespace Project0.StoreApplication.Domain.Models
{
    public class Customer
    {
        public Customer()
        {
        }

        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}