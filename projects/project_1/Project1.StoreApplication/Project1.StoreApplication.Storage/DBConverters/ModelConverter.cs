﻿using System;
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
            cust.CustomerId = customer.CustomerId;
            cust.FirstName = customer.FirstName;
            cust.LastName = customer.LastName;
            cust.Orders = (from o in customer.Orders
                          select o.ConvertToModel()).ToList();
            return cust;
        }

        public static Order ConvertToModel(this DBOrder order)
        {
            Order o = new();
            o.OrderID = order.OrderId;
            o.Products = new();
            foreach (var op in order.OrderProducts)
            {
                o.Products.Add(op.Product.ConvertToModel());
            }
            o.Store = order.Store.ConvertToModel();
            o.Customer = order.Customer.ConvertToModel();
            return o;
        }

        public static Store ConvertToModel(this DBStore store)
        {
            Store s = new();
            s.StoreId = store.StoreId;
            s.Name = store.Name;
            s.Orders = (from o in store.Orders select o.ConvertToModel()).ToList();
            return s;
        }

        public static Product ConvertToModel(this DBProduct product)
        {
            Product p = new();
            p.ProductId = product.ProductId;
            p.Name = product.Name;
            p.Price = product.Price;
            return p;
        }

        // TODO: I might not need these functions, but if I use them, I need to make
        //  sure that I'm not duplicating objects or something dumb like that

        public static DBCustomer ConvertToDBObj(this Customer customer)
        {
            DBCustomer c = new();
            c.CustomerId = customer.CustomerId;
            c.FirstName = customer.FirstName;
            c.LastName = customer.LastName;
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
