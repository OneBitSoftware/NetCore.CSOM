using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.WebCreationInformation", ValueObject = true, ServerTypeId = "{8f9e9fbe-189e-492f-884f-98f9ef9cc4d6}")]
    public class WebCreationInformation : ClientValueObject
    {
        private string m_description;

        private int m_language;

        private string m_title;

        private string m_url;

        private bool m_useSamePermissionsAsParentSite;

        private string m_webTemplate;

        [Remote]
        public string Description
        {
            get
            {
                return this.m_description;
            }
            set
            {
                this.m_description = value;
            }
        }

        [Remote]
        public int Language
        {
            get
            {
                return this.m_language;
            }
            set
            {
                this.m_language = value;
            }
        }

        [Remote]
        public string Title
        {
            get
            {
                return this.m_title;
            }
            set
            {
                this.m_title = value;
            }
        }

        [Remote]
        public string Url
        {
            get
            {
                return this.m_url;
            }
            set
            {
                this.m_url = value;
            }
        }

        [Remote]
        public bool UseSamePermissionsAsParentSite
        {
            get
            {
                return this.m_useSamePermissionsAsParentSite;
            }
            set
            {
                this.m_useSamePermissionsAsParentSite = value;
            }
        }

        [Remote]
        public string WebTemplate
        {
            get
            {
                return this.m_webTemplate;
            }
            set
            {
                this.m_webTemplate = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string TypeId
        {
            get
            {
                return "{8f9e9fbe-189e-492f-884f-98f9ef9cc4d6}";
            }
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
            writer.WriteAttributeString("Name", "Description");
            DataConvert.WriteValueToXmlElement(writer, this.Description, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Language");
            DataConvert.WriteValueToXmlElement(writer, this.Language, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Title");
            DataConvert.WriteValueToXmlElement(writer, this.Title, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Url");
            DataConvert.WriteValueToXmlElement(writer, this.Url, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "UseSamePermissionsAsParentSite");
            DataConvert.WriteValueToXmlElement(writer, this.UseSamePermissionsAsParentSite, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "WebTemplate");
            DataConvert.WriteValueToXmlElement(writer, this.WebTemplate, serializationContext);
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
                if (!(peekedName == "Description"))
                {
                    if (!(peekedName == "Language"))
                    {
                        if (!(peekedName == "Title"))
                        {
                            if (!(peekedName == "Url"))
                            {
                                if (!(peekedName == "UseSamePermissionsAsParentSite"))
                                {
                                    if (peekedName == "WebTemplate")
                                    {
                                        flag = true;
                                        reader.ReadName();
                                        this.m_webTemplate = reader.ReadString();
                                    }
                                }
                                else
                                {
                                    flag = true;
                                    reader.ReadName();
                                    this.m_useSamePermissionsAsParentSite = reader.ReadBoolean();
                                }
                            }
                            else
                            {
                                flag = true;
                                reader.ReadName();
                                this.m_url = reader.ReadString();
                            }
                        }
                        else
                        {
                            flag = true;
                            reader.ReadName();
                            this.m_title = reader.ReadString();
                        }
                    }
                    else
                    {
                        flag = true;
                        reader.ReadName();
                        this.m_language = reader.ReadInt32();
                    }
                }
                else
                {
                    flag = true;
                    reader.ReadName();
                    this.m_description = reader.ReadString();
                }
            }
            return flag;
        }
    }
}
