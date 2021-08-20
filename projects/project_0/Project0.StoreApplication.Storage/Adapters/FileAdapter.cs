
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Project0.StoreApplication.Domain.Abstracts;

namespace Project0.StoreApplication.Storage.Adapters
{
    public class FileAdapter
    {
        public List<Store> ReadFromFile()
        {
            // file path
            var path = "/home/jon/revature/my_code/data/project_0/stores.xml";
            // open file
            var file = new StreamReader(path);
            // deserialize object(s)
            var xml = new XmlSerializer(typeof(List<Store>));
            var stores = xml.Deserialize(file) as List<Store>;
            // close file
            file.Close();
            // return data
            return stores;
        }
        public void WriteToFile(List<Store> stores)
        {
            // file path
            string path = "/home/jon/revature/my_code/data/project_0/stores.xml";
            // open file
            var file = new StreamWriter(path);
            // serialize object(s)
            var xml = new XmlSerializer(typeof(List<Store>));
            // write to file
            xml.Serialize(file, stores);
            // close file
            file.Close();
        }
    }
}