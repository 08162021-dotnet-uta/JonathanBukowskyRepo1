using System;

namespace Project0.StoreApplication.Domain.Models
{
    public class Store
    {

        public Store(string name)
        {
            Name = name;
        }
        public string Name { get; private set; }

        public override string ToString()
        {
            return Name ?? DateTime.Now.ToLongDateString();
        }
    }
}