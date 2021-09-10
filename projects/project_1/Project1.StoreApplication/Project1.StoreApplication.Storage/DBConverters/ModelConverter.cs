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
        public static Customer ConvertToModel(this DBCustomer customer)
        {
            Customer cust = new();
            cust.FirstName = customer.FirstName;
            cust.LastName = customer.LastName;
            cust.Orders = (from o in customer.Orders
                          select o.ConvertToModel()).ToList();
            return cust;
        }

        public static Order ConvertToModel(this DBOrder order)
        {
            Order o = new();
            // TODO: give o values
            return o;
        }

        public static Store ConvertToModel(this DBStore store)
        {
            Store s = new();
            // TODO: give s values
            return s;
        }

        public static Product ConvertToModel(this DBProduct product)
        {
            Product p = new();
            // TODO: give p values
            return p;
        }

        public static DBCustomer ConvertToDBObj(this Customer customer)
        {
            DBCustomer c = new();
            // TODO: give c values
            return c;
        }

        public static DBOrder ConvertToDBObj(this Order order)
        {
            DBOrder o = new();
            // TODO: give o values
            return o;
        }

        public static DBStore ConvertToDBObj(this Store store)
        {
            DBStore s = new();
            // TODO: give s values
            return s;
        }

        public static DBProduct ConvertToDBObj(this Product product)
        {
            DBProduct p = new();
            // TODO: give p values
            return p;
        }
    }
}
