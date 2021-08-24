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

        public int StoreID { get; set; }

        public override int GetHashCode()
        {
            return StoreID;
        }
        public override bool Equals(object o)
        {
            if (o is Store)
            {
                return (this == (o as Store));
            }
            return false;
        }
        public static bool operator !=(Store a, Store b)
        {
            return a.StoreID != b.StoreID;
        }
        public static bool operator ==(Store a, Store b)
        {
            return a.StoreID == b.StoreID;
        }

        public override string ToString()
        {
            return Name ?? DateTime.Now.ToLongDateString();
        }
    }
}