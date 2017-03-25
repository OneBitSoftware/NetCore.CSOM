using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Security;

namespace Microsoft.SharePoint.Client.NetCore
{
    internal static class SPClientUtility
    {
        private static XmlNamespaceManager s_nsmgr;

        internal static XmlNamespaceManager ODataNamespaceManager
        {
            get
            {
                if (SPClientUtility.s_nsmgr == null)
                {
                    XmlNameTable nameTable = new NameTable();
                    XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(nameTable);
                    xmlNamespaceManager.AddNamespace("m", "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata");
                    xmlNamespaceManager.AddNamespace("d", "http://schemas.microsoft.com/ado/2007/08/dataservices");
                    SPClientUtility.s_nsmgr = xmlNamespaceManager;
                }
                return SPClientUtility.s_nsmgr;
            }
        }

        internal static XmlDocument LoadXml(TextReader reader)
        {
            XmlDocument xmlDocument = new XmlDocument();
            //Edited for .NET Core
            //XmlSecureResolver xmlResolver = new XmlSecureResolver(new XmlUrlResolver(), new PermissionSet(PermissionState.None));
            //xmlDocument.XmlResolver = xmlResolver;
            XmlReader reader2 = XmlReader.Create(reader);
            xmlDocument.Load(reader2);
            return xmlDocument;
        }
    }
}
