using System;
using System.Collections.Generic;

#nullable disable

namespace Project1.StoreApplication.Storage.DBModels
{
    public partial class Customer : DBObject
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? DefaultStore { get; set; }
        public bool? Active { get; set; }

        public virtual Store DefaultStoreNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
