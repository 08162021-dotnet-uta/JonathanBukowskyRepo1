using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Project1.StoreApplication.Models;
using Project1.StoreApplication.Storage.DBModels;

namespace Project1.StoreApplication.Storage.DBConverters
{
    public static class ModelConverterExtensions
    {
        /*

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? DefaultStore { get; set; }
        public bool? Active { get; set; }

        public virtual Store DefaultStoreNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

         */
        /// <summary>
        /// Converts a DBObject Customer into a ModelCustomer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static ModelCustomer ConvertToModel(this Customer customer)
        {
            ModelCustomer cust = new();
            cust.FirstName = customer.FirstName;
            cust.LastName = customer.LastName;
            cust.Orders = (from o in customer.Orders
                          select o.ConvertToModel()).ToList();
            return cust;
        }

        public static ModelOrder ConvertToModel(this Order order)
        {
            ModelOrder o = new();
            // TODO: give o values
            return o;
        }

        public static ModelStore ConvertToModel(this Store store)
        {
            ModelStore s = new();
            // TODO: give s values
            return s;
        }

        public static ModelProduct ConvertToModel(this Product product)
        {
            ModelProduct p = new();
            // TODO: give p values
            return p;
        }

        public static Customer ConvertToDBObj(this ModelCustomer customer)
        {
            Customer c = new();
            // TODO: give c values
            return c;
        }

        public static Order ConvertToDBObj(this ModelOrder order)
        {
            Order o = new();
            // TODO: give o values
            return o;
        }

        public static Store ConvertToDBObj(this ModelStore store)
        {
            Store s = new();
            // TODO: give s values
            return s;
        }

        public static Product ConvertToDBObj(this ModelProduct product)
        {
            Product p = new();
            // TODO: give p values
            return p;
        }
    }
}
