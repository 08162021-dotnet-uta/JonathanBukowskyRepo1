using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.StoreApplication.Models
{
    public class ModelCustomer : ModelObject
    {
        public ModelCustomer() : base()
        {
            Orders = new();
        }

        private int CustomerID { get; set; }

        //public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        /// <summary>
        /// Orders made by this ModelCustomer
        /// </summary>
        /// <value></value>
        public List<ModelOrder> Orders { get; set; }

        public override int GetHashCode()
        {
            return CustomerID;
        }

        public override bool Equals(object o)
        {
            if (o is ModelCustomer)
            {
                return (this == (o as ModelCustomer));
            }
            return false;
        }

        public static bool operator !=(ModelCustomer a, ModelCustomer b)
        {
            return a?.CustomerID != b?.CustomerID;
        }

        public static bool operator ==(ModelCustomer a, ModelCustomer b)
        {
            // NOTE: if the code is written correctly, this *should* be sufficient comparison
            //      it would be a great idea to compare other fields and such, but I'm not sure
            //  currently whether that would be either A) desired or B) necessary
            return a?.CustomerID == b?.CustomerID;
        }
    }
}
