namespace Project0.StoreApplication.Domain.Models
{
    /// <summary>
    /// A product sold at a Store that can be ordered by a Customer
    /// </summary>
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }

        public override int GetHashCode()
        {
            // Implementing GetHashCode to avoid compiler warnings.
            // I'm not sure I'm ever going to use this,
            // and I'm not sure this is appropriate functionality
            return ProductID;
        }
        public override bool Equals(object o)
        {
            if (o is Product)
            {
                return (this == (o as Product));
            }
            return false;
        }
        public static bool operator ==(Product a, Product b)
        {
            return a?.ProductID == b?.ProductID;
        }
        public static bool operator !=(Product a, Product b)
        {
            return a?.ProductID != b?.ProductID;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}