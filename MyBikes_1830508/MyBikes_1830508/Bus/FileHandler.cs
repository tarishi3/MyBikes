using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;
namespace MyBikes_1830508.Bus
{
    public class FileHandler
    {
        private static String xmlFilePath = @"../../Data/bikes.xml";
        public static void WriteToXmlFile(List<Bicycle> listOfAccounts)
        {
            XmlWriter writer = XmlWriter.Create(xmlFilePath);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Bicycle>));
            serializer.Serialize(writer, listOfAccounts);
            writer.Close();
        }

        public static List<Bicycle> ReadFromXmlFile()
        {
            List<Bicycle> temporaryListOfAccount = new List<Bicycle>();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Bicycle>));
            StreamReader reader = new StreamReader(xmlFilePath);
            temporaryListOfAccount = (List<Bicycle>)xmlSerializer.Deserialize(reader);
            reader.Close();
            return temporaryListOfAccount;
        }
    }
}
