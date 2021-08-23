
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Storage.Adapters
{
    public class XmlFileAdapter : Adapter
    {
        public override List<T> LoadAll<T>(string path)
        {
            return ReadListFromFile(new XmlSerializer(typeof(List<T>)), path) as List<T>;
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

        public override void SaveAll<T>(List<T> data, string path)
        {
            WriteToFile(data, path);
        }
        private void WriteToFile(object objs, string path)
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