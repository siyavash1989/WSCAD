using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using WSCAD.Models.Shapes;

namespace WSCAD.helpers.converter
{
    internal class XmlConverter : IDataConverter
    {
        public List<BaseShape> ConvertToShape(string data)
        {
            if (data == null)
                return new List<BaseShape>();

            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "shape";
            xRoot.Namespace = "http://www.cpandl.com";
            xRoot.IsNullable = true;

            XmlSerializer serializer = new XmlSerializer(typeof(List<BaseShape>));
            MemoryStream memStream = new MemoryStream(Encoding.UTF8.GetBytes(data));
            return (List<BaseShape>)serializer.Deserialize(memStream);
        }
    }
}
