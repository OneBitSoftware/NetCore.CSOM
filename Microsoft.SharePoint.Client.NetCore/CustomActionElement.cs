using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.ComponentModel;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.CustomActionElement", ValueObject = true, ServerTypeId = "{7295eb25-e721-42b6-aac9-cbb6c39afc54}")]
    public class CustomActionElement : ClientValueObject
    {
        private string m_commandUIExtension;

        private string m_enabledScript;

        private string m_imageUrl;

        private string m_location;

        private string m_registrationId;

        private UserCustomActionRegistrationType m_registrationType;

        private bool m_requireSiteAdministrator;

        private BasePermissions m_rights;

        private string m_title;

        private string m_urlAction;

        [Remote]
        public string CommandUIExtension
        {
            get
            {
                return this.m_commandUIExtension;
            }
        }

        [Remote]
        public string EnabledScript
        {
            get
            {
                return this.m_enabledScript;
            }
        }

        [Remote]
        public string ImageUrl
        {
            get
            {
                return this.m_imageUrl;
            }
        }

        [Remote]
        public string Location
        {
            get
            {
                return this.m_location;
            }
        }

        [Remote]
        public string RegistrationId
        {
            get
            {
                return this.m_registrationId;
            }
        }

        [Remote]
        public UserCustomActionRegistrationType RegistrationType
        {
            get
            {
                return this.m_registrationType;
            }
        }

        [Remote]
        public bool RequireSiteAdministrator
        {
            get
            {
                return this.m_requireSiteAdministrator;
            }
        }

        [Remote]
        public BasePermissions Rights
        {
            get
            {
                return this.m_rights;
            }
        }

        [Remote]
        public string Title
        {
            get
            {
                return this.m_title;
            }
        }

        [Remote]
        public string UrlAction
        {
            get
            {
                return this.m_urlAction;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string TypeId
        {
            get
            {
                return "{7295eb25-e721-42b6-aac9-cbb6c39afc54}";
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
            writer.WriteAttributeString("Name", "CommandUIExtension");
            DataConvert.WriteValueToXmlElement(writer, this.CommandUIExtension, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "EnabledScript");
            DataConvert.WriteValueToXmlElement(writer, this.EnabledScript, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "ImageUrl");
            DataConvert.WriteValueToXmlElement(writer, this.ImageUrl, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Location");
            DataConvert.WriteValueToXmlElement(writer, this.Location, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "RegistrationId");
            DataConvert.WriteValueToXmlElement(writer, this.RegistrationId, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "RegistrationType");
            DataConvert.WriteValueToXmlElement(writer, this.RegistrationType, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "RequireSiteAdministrator");
            DataConvert.WriteValueToXmlElement(writer, this.RequireSiteAdministrator, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Rights");
            DataConvert.WriteValueToXmlElement(writer, this.Rights, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Title");
            DataConvert.WriteValueToXmlElement(writer, this.Title, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "UrlAction");
            DataConvert.WriteValueToXmlElement(writer, this.UrlAction, serializationContext);
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
            switch (peekedName)
            {
                case "CommandUIExtension":
                    flag = true;
                    reader.ReadName();
                    this.m_commandUIExtension = reader.ReadString();
                    break;
                case "EnabledScript":
                    flag = true;
                    reader.ReadName();
                    this.m_enabledScript = reader.ReadString();
                    break;
                case "ImageUrl":
                    flag = true;
                    reader.ReadName();
                    this.m_imageUrl = reader.ReadString();
                    break;
                case "Location":
                    flag = true;
                    reader.ReadName();
                    this.m_location = reader.ReadString();
                    break;
                case "RegistrationId":
                    flag = true;
                    reader.ReadName();
                    this.m_registrationId = reader.ReadString();
                    break;
                case "RegistrationType":
                    flag = true;
                    reader.ReadName();
                    this.m_registrationType = reader.ReadEnum<UserCustomActionRegistrationType>();
                    break;
                case "RequireSiteAdministrator":
                    flag = true;
                    reader.ReadName();
                    this.m_requireSiteAdministrator = reader.ReadBoolean();
                    break;
                case "Rights":
                    flag = true;
                    reader.ReadName();
                    this.m_rights = reader.Read<BasePermissions>();
                    break;
                case "Title":
                    flag = true;
                    reader.ReadName();
                    this.m_title = reader.ReadString();
                    break;
                case "UrlAction":
                    flag = true;
                    reader.ReadName();
                    this.m_urlAction = reader.ReadString();
                    break;
            }
            return flag;
        }
    }
}