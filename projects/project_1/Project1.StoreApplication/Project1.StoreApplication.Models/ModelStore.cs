using System;
using System.Collections.Generic;
//using System.Xml.Serialization;

namespace Project1.StoreApplication.Models
{
    /// <summary>
    /// Store class - objects to represent a single store in our application
    /// </summary>
    public class ModelStore
    {
        // TODO: Reconsider which constructors are appropriate
        public ModelStore()
        {
            Name = "Generic store";
            Orders = new();
        }
        public ModelStore(string name)
        {
            Name = name;
            Orders = new();
        }
        public string Name { get; set; }

        public int StoreID { get; set; }

        /// <summary>
        /// The list of orders that are associated with this store
        /// </summary>
        /// <value></value>
        public List<ModelOrder> Orders { get; set; }

        public override int GetHashCode()
        {
            return StoreID;
        }
        public override bool Equals(object o)
        {
            if (o is ModelStore)
            {
                return (this == (o as ModelStore));
            }
            return false;
        }
        public static bool operator !=(ModelStore a, ModelStore b)
        {
            return a?.StoreID != b?.StoreID;
        }
        public static bool operator ==(ModelStore a, ModelStore b)
        {
            return a?.StoreID == b?.StoreID;
        }

        public override string ToString()
        {
            return Name ?? DateTime.Now.ToLongDateString();
        }
    }
}