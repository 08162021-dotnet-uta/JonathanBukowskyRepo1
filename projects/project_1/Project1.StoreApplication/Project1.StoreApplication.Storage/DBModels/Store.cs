using System;
using System.Collections.Generic;

#nullable disable

namespace Project1.StoreApplication.Storage.DBModels
{
    public partial class Store : DBObject
    {
        public Store()
        {
            Customers = new HashSet<Customer>();
            Orders = new HashSet<Order>();
            StoreProducts = new HashSet<StoreProduct>();
        }

        public int StoreId { get; set; }
        public string Name { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<StoreProduct> StoreProducts { get; set; }
    }
}
