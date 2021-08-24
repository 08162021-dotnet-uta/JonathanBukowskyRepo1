using System.Collections.Generic;

using Project0.StoreApplication.Domain.Abstracts;

namespace Project0.StoreApplication.Domain.Models
{
    public class Customer
    {
        public Customer()
        {
        }

        public int CustomerID { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }

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
            return a.CustomerID != b.CustomerID;
        }

        public static bool operator ==(Customer a, Customer b)
        {
            // NOTE: if the code is written correctly, this *should* be sufficient comparison
            //      it would be a great idea to compare other fields and such, but I'm not sure
            //  currently whether that would be either A) desired or B) necessary
            return a.CustomerID == b.CustomerID;
        }
    }
}