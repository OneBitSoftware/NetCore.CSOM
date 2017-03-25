using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Microsoft.SharePoint.Client.NetCoreIdcrl
{
    internal static class IdcrlUtility
    {
        private const string DummyElementName = "DummyElement";

        private const string DummyElementTag = "<DummyElement>";

        public static string XmlValueEncode(string value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            using (XmlWriter xmlWriter = XmlWriter.Create(stringBuilder))
            {
                xmlWriter.WriteElementString("DummyElement", value);
            }
            string text = stringBuilder.ToString();
            int num = text.IndexOf("<DummyElement>", StringComparison.Ordinal) + "<DummyElement>".Length;
            int num2 = text.IndexOf('<', num);
            return text.Substring(num, num2 - num);
        }

        internal static XElement GetElementAtPath(XElement elem, params string[] paths)
        {
            for (int i = 0; i < paths.Length; i++)
            {
                string expandedName = paths[i];
                if (elem == null)
                {
                    return null;
                }
                elem = elem.Element(XName.Get(expandedName));
            }
            return elem;
        }

        internal static string GetWebResponseHeader(WebResponse response)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (response != null && response.SupportsHeaders && response.Headers != null)
            {
                string[] allKeys = response.Headers.AllKeys;
                for (int i = 0; i < allKeys.Length; i++)
                {
                    string text = allKeys[i];
                    if (stringBuilder.Length > 0)
                    {
                        stringBuilder.Append(", ");
                    }
                    stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0}={1}", new object[]
                    {
                        text,
                        response.Headers[text]
                    });
                }
            }
            return stringBuilder.ToString();
        }
    }
}
