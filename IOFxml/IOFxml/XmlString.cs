using System.Xml;

namespace IOFxml
{
    public static class XmlString
    {
        public static string FocusXml(string node, string content)
        {
            string result = "";

            using (XmlReader r = CreateReader(content))
            {
                if (r.ReadToFollowing(node))
                {
                    result += "<?xml version =\"1.0\" encoding=\"UTF-8\"?>";
                    result += r.ReadOuterXml();
                }
            }

            return result;
        }

        public static string GetNodeContent(string node, string content)
        {
            string result = "";

            if (content.Contains(node))
            {
                using (XmlReader r = CreateReader(content))
                {
                    if (r.ReadToFollowing(node))
                    {
                        r.MoveToContent();
                        result = r.ReadElementContentAsString();
                    }
                }
            }

            return result;
        }

        public static string GetNodeAttribute(string attribute, string node, string content)
        {
            string result = "";

            if (content.Contains(node))
            {
                using (XmlReader r = CreateReader(content))
                {
                    if (r.ReadToFollowing(node))
                    {
                        if (r.MoveToAttribute(attribute))
                        {
                            result = r.Value.ToString();
                        }
                    }
                }
            }

            return result;
        }

        public static XmlReader CreateReader(string xmltext)
        {
            if (xmltext == null || xmltext == "")
                xmltext = "<Content></Content>";

            System.IO.StringReader sr = new System.IO.StringReader(xmltext);
            return XmlReader.Create(sr);
        }
    }
}
