using System;
using System.Collections.Generic;

#nullable disable

namespace Project1.StoreApplication.Storage.DBModels
{
    public partial class Product : DBObject
    {
        public Product()
        {
            OrderProducts = new HashSet<OrderProduct>();
            StoreProducts = new HashSet<StoreProduct>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public decimal Price { get; set; }
        public bool? Active { get; set; }

        public virtual ProductCategory Category { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
        public virtual ICollection<StoreProduct> StoreProducts { get; set; }
    }
}
