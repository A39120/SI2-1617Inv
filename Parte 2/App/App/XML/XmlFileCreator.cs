using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Xml;

namespace App.XML
{
    class XmlFileCreator
    {
        private XmlSampleGenerator xsg;
        public void CreateXmlFileFromSchema(XmlSchema schema, XmlQualifiedName rootElem)
        {
            xsg = XmlSampleGenerator(schema, rootElem);
        }


    }
}
