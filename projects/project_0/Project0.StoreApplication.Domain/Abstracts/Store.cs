using System;
using System.Xml.Serialization;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Domain.Abstracts
{
    [XmlInclude(typeof(GroceryStore))]
    public abstract class Store
    {
        public Store()
        {
            Name = "Generic store";
        }
        public Store(string name)
        {
            Name = name;
        }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name ?? DateTime.Now.ToLongDateString();
        }
    }
}