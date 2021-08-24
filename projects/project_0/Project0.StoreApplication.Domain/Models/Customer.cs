using System.Collections.Generic;
using System.Xml.Serialization;
using Project0.StoreApplication.Domain.Abstracts;

namespace Project0.StoreApplication.Domain.Models
{
    // TODO: I want to update my object model to have Customer.Orders and Store.Orders (and maybe additional stuff like Store.Products, idk).
    //  (I hope) I've finally got my saving to a point where I can consistently save/load objects and correctly identify them.
    public class Customer
    {
        public Customer()
        {
            Orders = new();
        }

        public int CustomerID { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public List<Order> Orders { get; set; }

        public override int GetHashCode()
        {
            return CustomerID;
        }

        public override bool Equals(object o)
        {
            if (o is Customer)
            {
                return (this == (o as Customer));
            }
            return false;
        }

        public static bool operator !=(Customer a, Customer b)
        {
            return a?.CustomerID != b?.CustomerID;
        }

        public static bool operator ==(Customer a, Customer b)
        {
            // NOTE: if the code is written correctly, this *should* be sufficient comparison
            //      it would be a great idea to compare other fields and such, but I'm not sure
            //  currently whether that would be either A) desired or B) necessary
            return a?.CustomerID == b?.CustomerID;
        }
    }
}