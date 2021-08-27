using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Domain.Abstracts
{
    /// <summary>
    /// Store class - objects to represent a single store in our application
    /// </summary>
    [XmlInclude(typeof(GroceryStore))]
    public class Store
    {
        // TODO: Reconsider which constructors are appropriate
        public Store()
        {
            Name = "Generic store";
            Orders = new();
        }
        public Store(string name)
        {
            Name = name;
        }
        public string Name { get; set; }

        public int StoreID { get; set; }

        /// <summary>
        /// The list of orders that are associated with this store
        /// </summary>
        /// <value></value>
        public List<Order> Orders { get; set; }

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
            return a?.StoreID != b?.StoreID;
        }
        public static bool operator ==(Store a, Store b)
        {
            return a?.StoreID == b?.StoreID;
        }

        public override string ToString()
        {
            return Name ?? DateTime.Now.ToLongDateString();
        }
    }
}