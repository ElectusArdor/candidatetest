using System.Xml;
using System.ComponentModel;

namespace candidatetest
{
    internal static class XmlSerializer
    {
        public static void Serilize(BindingList<OutputData> dataOut, string path)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode rootNode = doc.CreateElement("root");
            doc.AppendChild(rootNode);

            foreach (var el in dataOut)
            {
                var itemNode = doc.CreateElement("item");
                var attribute = doc.CreateAttribute("Binding");
                attribute.Value = "Introduced";
                itemNode.Attributes.Append(attribute);

                var pathNode = doc.CreateElement("node-path");
                pathNode.InnerText = el.Tag;
                itemNode.AppendChild(pathNode);

                var addresNode = doc.CreateElement("address");
                addresNode.InnerText = el.Adress.ToString();
                itemNode.AppendChild(addresNode);

                rootNode.AppendChild(itemNode);
            }
            doc.Save(path);
        }
    }
}
