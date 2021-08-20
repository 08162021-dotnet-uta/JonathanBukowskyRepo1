using System;

namespace Project0.StoreApplication.Domain.Abstracts
{
    public abstract class Store
    {
        public Store(string name)
        {
            Name = name;
        }
        public string Name { get; protected set; }

        public override string ToString()
        {
            return Name ?? DateTime.Now.ToLongDateString();
        }
    }
}