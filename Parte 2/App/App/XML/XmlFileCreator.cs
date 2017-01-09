using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Xml;
using System.Data;
using System.Data.Entity;
using System.Data.EntityClient;
using System.Xml.Serialization;
using System.IO;

namespace App.XML
{
    class XmlFileCreator
    {

        public void exportXml<T>(T obj, String identifier)
        {
            XmlSerializer xmlWriter = new XmlSerializer(typeof(T));
            String path = Environment.CurrentDirectory + "\\XMLFile" + identifier + ".xml";
            FileStream file = File.Create(path);

            xmlWriter.Serialize(file, obj);
            file.Close(); 
        }
    }
}
