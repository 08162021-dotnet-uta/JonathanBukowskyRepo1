
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Domain.Interfaces;
using Project0.StoreApplication.Storage.Repositories;

namespace Project0.StoreApplication.Storage
{
    public class XmlFileStorage : IStorageDAO
    {
        public Order CreateOrder(Customer customer, Store store, List<Product> products)
        {
            // TODO: Better error output for caller? assume caller validated data?
            if (customer == null)
            {
                //Console.WriteLine("You must select a customer");
                return null;
            }
            else if (store == null)
            {
                //Console.WriteLine("You must select a store");
                return null;
            }
            else if (products == null || products.Count == 0)
            {
                //Console.WriteLine("Your cart is empty");
                return null;
            }
            // TODO: Need to check to make sure customer, store, products are all valid and "in the database" (saved to disk already)
            Order o = new Order(customer, store, products);
            var repo = OrderRepository.Factory();
            repo.Orders.Add(o);
            repo.SaveOrders();
            // TODO: actually check on whether save succeeded
            //Console.WriteLine("Order saved successfully");
            return o;
        }

        public List<Customer> GetCustomers()
        {
            return CustomerRepository.Factory().Customers;
        }

        public List<Order> GetOrders()
        {
            return OrderRepository.Factory().Orders;
        }

        public List<Order> GetOrders(Store store)
        {
            // NOTE: in this operation (and in the other filtered GetOrders()), I am taking advantage of the current design that there will only ever be one
            //      object per saved customer, and so any reference to that customer will have the same value. (The repos basically assign "de-facto" unique ids
            //      based on the location of the object in the repo data List<>, i.e. the index is the "id". This currently relies on the idea that the ordering
            //      of the List<> and/or Xml arrays will not change during runtime. I have not verified this assumption)
            //      this is a fragile design, as a bug or design change could introduce "duplicate" customers, or instances of
            //      what *should* be the same customer, but are stored in different locations (with differing reference values).
            //      It would be better to either:
            //          -- formalize this design constraint in code. This could essentially require making a factory for Customer/Store, or something like that
            //          -- change this comparison to use a by-value equality (memberwise value comparison). This would be problematic when customers/stores
            //                  have the same name, unless I add a unique identifier like IDs
            return OrderRepository.Factory().Orders.FindAll((Order o) => o.Store == store);
        }

        public List<Order> GetOrders(Customer customer)
        {
            return OrderRepository.Factory().Orders.FindAll((Order o) => o.Customer == customer);
        }

        public List<Product> GetProducts()
        {
            var pr = ProductRepository.Factory();
            return pr.Products;
        }

        public List<Store> GetStores()
        {
            return StoreRepository.Factory().Stores;
        }
    }
}