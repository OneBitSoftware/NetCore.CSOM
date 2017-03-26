using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.CamlQuery", ValueObject = true, ServerTypeId = "{3d248d7b-fc86-40a3-aa97-02a75d69fb8a}")]
    public class CamlQuery : ClientValueObject
    {
        private bool m_datesInUtc;

        private string m_folderServerRelativeUrl;

        private ListItemCollectionPosition m_listItemCollectionPosition;

        private string m_viewXml;

        [Remote]
        public bool DatesInUtc
        {
            get
            {
                return this.m_datesInUtc;
            }
            set
            {
                this.m_datesInUtc = value;
            }
        }

        [Remote]
        public string FolderServerRelativeUrl
        {
            get
            {
                return this.m_folderServerRelativeUrl;
            }
            set
            {
                this.m_folderServerRelativeUrl = value;
            }
        }

        [Remote]
        public ListItemCollectionPosition ListItemCollectionPosition
        {
            get
            {
                return this.m_listItemCollectionPosition;
            }
            set
            {
                this.m_listItemCollectionPosition = value;
            }
        }

        [Remote]
        public string ViewXml
        {
            get
            {
                return this.m_viewXml;
            }
            set
            {
                this.m_viewXml = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string TypeId
        {
            get
            {
                return "{3d248d7b-fc86-40a3-aa97-02a75d69fb8a}";
            }
        }

        public CamlQuery()
        {
            this.m_datesInUtc = true;
        }

        public static CamlQuery CreateAllItemsQuery()
        {
            return new CamlQuery
            {
                ViewXml = "<View Scope=\"RecursiveAll\">\r\n    <Query>\r\n    </Query>\r\n</View>"
            };
        }

        public static CamlQuery CreateAllItemsQuery(int rowLimit, params string[] viewFields)
        {
            if (rowLimit <= 0)
            {
                throw new ArgumentOutOfRangeException("rowLimit");
            }
            if (viewFields == null)
            {
                throw new ArgumentNullException("viewFields");
            }
            CamlQuery camlQuery = new CamlQuery();
            StringBuilder stringBuilder = new StringBuilder();
            XmlWriter xmlWriter = XmlWriter.Create(stringBuilder, new XmlWriterSettings
            {
                OmitXmlDeclaration = true
            });
            xmlWriter.WriteStartElement("View");
            xmlWriter.WriteAttributeString("Scope", "RecursiveAll");
            if (viewFields.Length > 0)
            {
                xmlWriter.WriteStartElement("ViewFields");
                for (int i = 0; i < viewFields.Length; i++)
                {
                    string value = viewFields[i];
                    if (!string.IsNullOrEmpty(value))
                    {
                        xmlWriter.WriteStartElement("FieldRef");
                        xmlWriter.WriteAttributeString("Name", value);
                        xmlWriter.WriteEndElement();
                    }
                }
                xmlWriter.WriteEndElement();
            }
            xmlWriter.WriteElementString("RowLimit", rowLimit.ToString(CultureInfo.InvariantCulture));
            xmlWriter.WriteEndElement();
            //Edited for .NET Core
            xmlWriter.Dispose();//.Close();
            camlQuery.ViewXml = stringBuilder.ToString();
            return camlQuery;
        }

        public static CamlQuery CreateAllFoldersQuery()
        {
            return new CamlQuery
            {
                ViewXml = "<View Scope=\"RecursiveAll\">\r\n    <Query>\r\n        <Where>\r\n            <Eq>\r\n                <FieldRef Name=\"FSObjType\" />\r\n                <Value Type=\"Integer\">1</Value>\r\n            </Eq>\r\n        </Where>\r\n    </Query>\r\n</View>"
            };
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void WriteToXml(XmlWriter writer, SerializationContext serializationContext)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }
            if (serializationContext == null)
            {
                throw new ArgumentNullException("serializationContext");
            }
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "DatesInUtc");
            DataConvert.WriteValueToXmlElement(writer, this.DatesInUtc, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FolderServerRelativeUrl");
            DataConvert.WriteValueToXmlElement(writer, this.FolderServerRelativeUrl, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "ListItemCollectionPosition");
            DataConvert.WriteValueToXmlElement(writer, this.ListItemCollectionPosition, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "ViewXml");
            DataConvert.WriteValueToXmlElement(writer, this.ViewXml, serializationContext);
            writer.WriteEndElement();
            base.WriteToXml(writer, serializationContext);
        }

        protected override bool InitOnePropertyFromJson(string peekedName, JsonReader reader)
        {
            bool flag = base.InitOnePropertyFromJson(peekedName, reader);
            if (flag)
            {
                return flag;
            }
            if (peekedName != null)
            {
                if (!(peekedName == "DatesInUtc"))
                {
                    if (!(peekedName == "FolderServerRelativeUrl"))
                    {
                        if (!(peekedName == "ListItemCollectionPosition"))
                        {
                            if (peekedName == "ViewXml")
                            {
                                flag = true;
                                reader.ReadName();
                                this.m_viewXml = reader.ReadString();
                            }
                        }
                        else
                        {
                            flag = true;
                            reader.ReadName();
                            this.m_listItemCollectionPosition = reader.Read<ListItemCollectionPosition>();
                        }
                    }
                    else
                    {
                        flag = true;
                        reader.ReadName();
                        this.m_folderServerRelativeUrl = reader.ReadString();
                    }
                }
                else
                {
                    flag = true;
                    reader.ReadName();
                    this.m_datesInUtc = reader.ReadBoolean();
                }
            }
            return flag;
        }
    }
}
