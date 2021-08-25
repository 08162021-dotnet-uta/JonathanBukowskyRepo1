using System.Collections.Generic;
using System.Xml.Serialization;
using Project0.StoreApplication.Domain.Abstracts;
namespace Project0.StoreApplication.Domain.Models
{
    /// <summary>
    /// An Order created in StoreApplication will be an already confirmed, non-modifiable order placed by a Customer at a Store
    /// </summary>
    public class Order
    {
        public Order() : base()
        {

        }
        public Order(Customer customer, Store store, List<Product> products) : base()
        {
            Customer = customer;
            Products = new(products);
            Store = store;
        }

        // TODO: update OrderID to be set appropriately
        public int OrderID { get; set; }

        /// <summary>
        /// Customer placing the order
        /// </summary>
        /// <value></value>
        [XmlIgnoreAttribute]
        public Customer Customer { get; set; }

        /// <summary>
        /// Products being ordered
        /// </summary>
        /// <value></value>
        public List<Product> Products { get; set; }

        /// <summary>
        /// Store through which order is being made
        /// </summary>
        /// <value></value>
        [XmlIgnoreAttribute]
        public Store Store { get; set; }

        public override int GetHashCode()
        {
            return OrderID;
        }
        public override bool Equals(object o)
        {
            if (o is Order)
            {
                return (this == (o as Order));
            }
            return false;
        }

        public static bool operator !=(Order a, Order b)
        {
            return a?.OrderID != b?.OrderID;
        }
        public static bool operator ==(Order a, Order b)
        {
            return a?.OrderID == b?.OrderID;
        }

        public override string ToString()
        {
            string output = "Order:\n\tCustomer: " + Customer + "\n\tStore: " + Store + "\n\tItems:\n";
            foreach (var product in Products)
            {
                output += "\t\t" + product + "\n";
            }
            return output;
        }
    }
}