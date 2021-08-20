
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Storage.Adapters
{
    internal class FileLocation
    {
        private const string dir = "/home/jon/revature/my_code/data/project_0/";
        public const string Stores = dir + "stores.xml";
        public const string Customers = dir + "customers.xml";
        public const string Orders = dir + "orders.xml";
        public const string Products = dir + "products.xml";

        public static string GetPath(System.Type type)
        {
            string path;
            if (type == typeof(Product))
            {
                path = Products;
            }
            else if (type == typeof(Customer))
            {
                path = Customers;
            }
            else if (type == typeof(Store))
            {
                path = Stores;
            }
            else if (type == typeof(Order))
            {
                path = Orders;
            }
            else
            {
                // TODO: handle this better
                throw new System.Exception("Invalid object type in GetPath");
            }
            return path;
        }

    }

    public class XmlFileAdapter : Adapter
    {
        private XmlSerializer _storeSerial;
        private XmlSerializer _productSerial;
        private XmlSerializer _customerSerial;
        private XmlSerializer _orderSerial;
        public XmlFileAdapter()
        {
            _storeSerial = new XmlSerializer(typeof(List<Store>));
            _productSerial = new XmlSerializer(typeof(List<Product>));
            //_customerSerial = new XmlSerializer(typeof(List<Customer>));
            //_orderSerial = new XmlSerializer(typeof(List<Order>));
        }
        public override List<Product> LoadProducts()
        {
            return ReadListFromFile(_productSerial, FileLocation.Products) as List<Product>;
        }
        public override List<Store> LoadStores()
        {
            return ReadListFromFile(_storeSerial, FileLocation.Stores) as List<Store>;
        }
        public override List<Customer> LoadCustomers()
        {
            return null;
        }
        public override List<Order> LoadOrders()
        {
            return null;
        }
        private object ReadListFromFile(XmlSerializer xml, string path)
        {
            // file path
            // open file
            //var path = FileLocation.GetPath(objType);
            var file = new StreamReader(path);
            // deserialize object(s)
            //var xml = new XmlSerializer(objType);
            var objs = xml.Deserialize(file);
            // close file
            file.Close();
            // return data
            return objs;
        }

        public override void Save(List<Store> stores)
        {
            WriteToFile(stores, FileLocation.Stores);
        }
        public override void Save(List<Product> products)
        {
            WriteToFile(products, FileLocation.Products);
        }
        public override void Save(List<Order> orders)
        {
            WriteToFile(orders, FileLocation.Orders);
        }
        public override void Save(List<Customer> customers)
        {
            WriteToFile(customers, FileLocation.Customers);
        }
        public void WriteToFile(object objs, string path)
        {
            // file path
            //string path = "/home/jon/revature/my_code/data/project_0/stores.xml";
            // open file
            var file = new StreamWriter(path);
            // serialize object(s)
            var xml = new XmlSerializer(objs.GetType());
            // write to file
            xml.Serialize(file, objs);
            // close file
            file.Close();
        }
    }
}