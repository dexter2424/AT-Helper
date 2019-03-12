using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace autotester
{
    class xmlLoad
    {
        string A1;

        public string ParametersClass(string fileName, string elementName)
        {

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(fileName);
            //string text = xmldoc.InnerText; //A teljes xml-ben lévő belső értékek kiolvasása

            A1 = xmldoc.DocumentElement[elementName].InnerText;
            
            return A1;

        }
    }
}
