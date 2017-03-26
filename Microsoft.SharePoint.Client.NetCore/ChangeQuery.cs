using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.ChangeQuery", ValueObject = true, ServerTypeId = "{887a7218-1232-4cfc-b78f-88d54e9d8ec7}")]
    public sealed class ChangeQuery : ClientValueObject
    {
        private bool m_activity;

        private bool m_add;

        private bool m_alert;

        private ChangeToken m_changeTokenEnd;

        private ChangeToken m_changeTokenStart;

        private bool m_contentType;

        private bool m_deleteObject;

        private long m_fetchLimit = 1000L;

        private bool m_field;

        private bool m_file;

        private bool m_folder;

        private bool m_group;

        private bool m_groupMembershipAdd;

        private bool m_groupMembershipDelete;

        private bool m_item;

        private bool m_latestFirst;

        private bool m_list;

        private bool m_move;

        private bool m_navigation;

        private bool m_recursiveAll;

        private bool m_rename;

        private bool m_requireSecurityTrim;

        private bool m_restore;

        private bool m_roleAssignmentAdd;

        private bool m_roleAssignmentDelete;

        private bool m_roleDefinitionAdd;

        private bool m_roleDefinitionDelete;

        private bool m_roleDefinitionUpdate;

        private bool m_securityPolicy;

        private bool m_site;

        private bool m_systemUpdate;

        private bool m_update;

        private bool m_user;

        private bool m_view;

        private bool m_web;

        [Remote]
        public bool Activity
        {
            get
            {
                return this.m_activity;
            }
            set
            {
                this.m_activity = value;
            }
        }

        [Remote]
        public bool Add
        {
            get
            {
                return this.m_add;
            }
            set
            {
                this.m_add = value;
            }
        }

        [Remote]
        public bool Alert
        {
            get
            {
                return this.m_alert;
            }
            set
            {
                this.m_alert = value;
            }
        }

        [Remote]
        public ChangeToken ChangeTokenEnd
        {
            get
            {
                return this.m_changeTokenEnd;
            }
            set
            {
                this.m_changeTokenEnd = value;
            }
        }

        [Remote]
        public ChangeToken ChangeTokenStart
        {
            get
            {
                return this.m_changeTokenStart;
            }
            set
            {
                this.m_changeTokenStart = value;
            }
        }

        [Remote]
        public bool ContentType
        {
            get
            {
                return this.m_contentType;
            }
            set
            {
                this.m_contentType = value;
            }
        }

        [Remote]
        public bool DeleteObject
        {
            get
            {
                return this.m_deleteObject;
            }
            set
            {
                this.m_deleteObject = value;
            }
        }

        [Remote]
        public long FetchLimit
        {
            get
            {
                return this.m_fetchLimit;
            }
            set
            {
                this.m_fetchLimit = value;
            }
        }

        [Remote]
        public bool Field
        {
            get
            {
                return this.m_field;
            }
            set
            {
                this.m_field = value;
            }
        }

        [Remote]
        public bool File
        {
            get
            {
                return this.m_file;
            }
            set
            {
                this.m_file = value;
            }
        }

        [Remote]
        public bool Folder
        {
            get
            {
                return this.m_folder;
            }
            set
            {
                this.m_folder = value;
            }
        }

        [Remote]
        public bool Group
        {
            get
            {
                return this.m_group;
            }
            set
            {
                this.m_group = value;
            }
        }

        [Remote]
        public bool GroupMembershipAdd
        {
            get
            {
                return this.m_groupMembershipAdd;
            }
            set
            {
                this.m_groupMembershipAdd = value;
            }
        }

        [Remote]
        public bool GroupMembershipDelete
        {
            get
            {
                return this.m_groupMembershipDelete;
            }
            set
            {
                this.m_groupMembershipDelete = value;
            }
        }

        [Remote]
        public bool Item
        {
            get
            {
                return this.m_item;
            }
            set
            {
                this.m_item = value;
            }
        }

        [Remote]
        public bool LatestFirst
        {
            get
            {
                return this.m_latestFirst;
            }
            set
            {
                this.m_latestFirst = value;
            }
        }

        [Remote]
        public bool List
        {
            get
            {
                return this.m_list;
            }
            set
            {
                this.m_list = value;
            }
        }

        [Remote]
        public bool Move
        {
            get
            {
                return this.m_move;
            }
            set
            {
                this.m_move = value;
            }
        }

        [Remote]
        public bool Navigation
        {
            get
            {
                return this.m_navigation;
            }
            set
            {
                this.m_navigation = value;
            }
        }

        [Remote]
        public bool RecursiveAll
        {
            get
            {
                return this.m_recursiveAll;
            }
            set
            {
                this.m_recursiveAll = value;
            }
        }

        [Remote]
        public bool Rename
        {
            get
            {
                return this.m_rename;
            }
            set
            {
                this.m_rename = value;
            }
        }

        [Remote]
        public bool RequireSecurityTrim
        {
            get
            {
                return this.m_requireSecurityTrim;
            }
            set
            {
                this.m_requireSecurityTrim = value;
            }
        }

        [Remote]
        public bool Restore
        {
            get
            {
                return this.m_restore;
            }
            set
            {
                this.m_restore = value;
            }
        }

        [Remote]
        public bool RoleAssignmentAdd
        {
            get
            {
                return this.m_roleAssignmentAdd;
            }
            set
            {
                this.m_roleAssignmentAdd = value;
            }
        }

        [Remote]
        public bool RoleAssignmentDelete
        {
            get
            {
                return this.m_roleAssignmentDelete;
            }
            set
            {
                this.m_roleAssignmentDelete = value;
            }
        }

        [Remote]
        public bool RoleDefinitionAdd
        {
            get
            {
                return this.m_roleDefinitionAdd;
            }
            set
            {
                this.m_roleDefinitionAdd = value;
            }
        }

        [Remote]
        public bool RoleDefinitionDelete
        {
            get
            {
                return this.m_roleDefinitionDelete;
            }
            set
            {
                this.m_roleDefinitionDelete = value;
            }
        }

        [Remote]
        public bool RoleDefinitionUpdate
        {
            get
            {
                return this.m_roleDefinitionUpdate;
            }
            set
            {
                this.m_roleDefinitionUpdate = value;
            }
        }

        [Remote]
        public bool SecurityPolicy
        {
            get
            {
                return this.m_securityPolicy;
            }
            set
            {
                this.m_securityPolicy = value;
            }
        }

        [Remote]
        public bool Site
        {
            get
            {
                return this.m_site;
            }
            set
            {
                this.m_site = value;
            }
        }

        [Remote]
        public bool SystemUpdate
        {
            get
            {
                return this.m_systemUpdate;
            }
            set
            {
                this.m_systemUpdate = value;
            }
        }

        [Remote]
        public bool Update
        {
            get
            {
                return this.m_update;
            }
            set
            {
                this.m_update = value;
            }
        }

        [Remote]
        public bool User
        {
            get
            {
                return this.m_user;
            }
            set
            {
                this.m_user = value;
            }
        }

        [Remote]
        public bool View
        {
            get
            {
                return this.m_view;
            }
            set
            {
                this.m_view = value;
            }
        }

        [Remote]
        public bool Web
        {
            get
            {
                return this.m_web;
            }
            set
            {
                this.m_web = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string TypeId
        {
            get
            {
                return "{887a7218-1232-4cfc-b78f-88d54e9d8ec7}";
            }
        }

        private void InitQuery(bool allChangeObjectTypes, bool allChangeTypes)
        {
            if (allChangeObjectTypes)
            {
                this.m_item = true;
                this.m_list = true;
                this.m_web = true;
                this.m_site = true;
                this.m_file = true;
                this.m_folder = true;
                this.m_alert = true;
                this.m_user = true;
                this.m_group = true;
                this.m_contentType = true;
                this.m_field = true;
                this.m_securityPolicy = true;
                this.m_view = true;
            }
            if (allChangeTypes)
            {
                this.m_add = true;
                this.m_update = true;
                this.m_deleteObject = true;
                this.m_rename = true;
                this.m_move = true;
                this.m_restore = true;
                this.m_roleDefinitionAdd = true;
                this.m_roleDefinitionDelete = true;
                this.m_roleDefinitionUpdate = true;
                this.m_roleAssignmentAdd = true;
                this.m_roleAssignmentDelete = true;
                this.m_groupMembershipAdd = true;
                this.m_groupMembershipDelete = true;
                this.m_systemUpdate = true;
                this.m_navigation = true;
            }
        }

        public ChangeQuery()
        {
        }

        public ChangeQuery(bool allChangeObjectTypes, bool allChangeTypes)
        {
            this.InitQuery(allChangeObjectTypes, allChangeTypes);
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
            writer.WriteAttributeString("Name", "Activity");
            DataConvert.WriteValueToXmlElement(writer, this.Activity, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Add");
            DataConvert.WriteValueToXmlElement(writer, this.Add, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Alert");
            DataConvert.WriteValueToXmlElement(writer, this.Alert, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "ChangeTokenEnd");
            DataConvert.WriteValueToXmlElement(writer, this.ChangeTokenEnd, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "ChangeTokenStart");
            DataConvert.WriteValueToXmlElement(writer, this.ChangeTokenStart, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "ContentType");
            DataConvert.WriteValueToXmlElement(writer, this.ContentType, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "DeleteObject");
            DataConvert.WriteValueToXmlElement(writer, this.DeleteObject, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FetchLimit");
            DataConvert.WriteValueToXmlElement(writer, this.FetchLimit, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Field");
            DataConvert.WriteValueToXmlElement(writer, this.Field, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "File");
            DataConvert.WriteValueToXmlElement(writer, this.File, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Folder");
            DataConvert.WriteValueToXmlElement(writer, this.Folder, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Group");
            DataConvert.WriteValueToXmlElement(writer, this.Group, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "GroupMembershipAdd");
            DataConvert.WriteValueToXmlElement(writer, this.GroupMembershipAdd, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "GroupMembershipDelete");
            DataConvert.WriteValueToXmlElement(writer, this.GroupMembershipDelete, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Item");
            DataConvert.WriteValueToXmlElement(writer, this.Item, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "LatestFirst");
            DataConvert.WriteValueToXmlElement(writer, this.LatestFirst, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "List");
            DataConvert.WriteValueToXmlElement(writer, this.List, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Move");
            DataConvert.WriteValueToXmlElement(writer, this.Move, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Navigation");
            DataConvert.WriteValueToXmlElement(writer, this.Navigation, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "RecursiveAll");
            DataConvert.WriteValueToXmlElement(writer, this.RecursiveAll, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Rename");
            DataConvert.WriteValueToXmlElement(writer, this.Rename, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "RequireSecurityTrim");
            DataConvert.WriteValueToXmlElement(writer, this.RequireSecurityTrim, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Restore");
            DataConvert.WriteValueToXmlElement(writer, this.Restore, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "RoleAssignmentAdd");
            DataConvert.WriteValueToXmlElement(writer, this.RoleAssignmentAdd, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "RoleAssignmentDelete");
            DataConvert.WriteValueToXmlElement(writer, this.RoleAssignmentDelete, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "RoleDefinitionAdd");
            DataConvert.WriteValueToXmlElement(writer, this.RoleDefinitionAdd, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "RoleDefinitionDelete");
            DataConvert.WriteValueToXmlElement(writer, this.RoleDefinitionDelete, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "RoleDefinitionUpdate");
            DataConvert.WriteValueToXmlElement(writer, this.RoleDefinitionUpdate, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "SecurityPolicy");
            DataConvert.WriteValueToXmlElement(writer, this.SecurityPolicy, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Site");
            DataConvert.WriteValueToXmlElement(writer, this.Site, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "SystemUpdate");
            DataConvert.WriteValueToXmlElement(writer, this.SystemUpdate, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Update");
            DataConvert.WriteValueToXmlElement(writer, this.Update, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "User");
            DataConvert.WriteValueToXmlElement(writer, this.User, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "View");
            DataConvert.WriteValueToXmlElement(writer, this.View, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Web");
            DataConvert.WriteValueToXmlElement(writer, this.Web, serializationContext);
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
                case "Activity":
                    flag = true;
                    reader.ReadName();
                    this.m_activity = reader.ReadBoolean();
                    break;
                case "Add":
                    flag = true;
                    reader.ReadName();
                    this.m_add = reader.ReadBoolean();
                    break;
                case "Alert":
                    flag = true;
                    reader.ReadName();
                    this.m_alert = reader.ReadBoolean();
                    break;
                case "ChangeTokenEnd":
                    flag = true;
                    reader.ReadName();
                    this.m_changeTokenEnd = reader.Read<ChangeToken>();
                    break;
                case "ChangeTokenStart":
                    flag = true;
                    reader.ReadName();
                    this.m_changeTokenStart = reader.Read<ChangeToken>();
                    break;
                case "ContentType":
                    flag = true;
                    reader.ReadName();
                    this.m_contentType = reader.ReadBoolean();
                    break;
                case "DeleteObject":
                    flag = true;
                    reader.ReadName();
                    this.m_deleteObject = reader.ReadBoolean();
                    break;
                case "FetchLimit":
                    flag = true;
                    reader.ReadName();
                    this.m_fetchLimit = reader.ReadInt64();
                    break;
                case "Field":
                    flag = true;
                    reader.ReadName();
                    this.m_field = reader.ReadBoolean();
                    break;
                case "File":
                    flag = true;
                    reader.ReadName();
                    this.m_file = reader.ReadBoolean();
                    break;
                case "Folder":
                    flag = true;
                    reader.ReadName();
                    this.m_folder = reader.ReadBoolean();
                    break;
                case "Group":
                    flag = true;
                    reader.ReadName();
                    this.m_group = reader.ReadBoolean();
                    break;
                case "GroupMembershipAdd":
                    flag = true;
                    reader.ReadName();
                    this.m_groupMembershipAdd = reader.ReadBoolean();
                    break;
                case "GroupMembershipDelete":
                    flag = true;
                    reader.ReadName();
                    this.m_groupMembershipDelete = reader.ReadBoolean();
                    break;
                case "Item":
                    flag = true;
                    reader.ReadName();
                    this.m_item = reader.ReadBoolean();
                    break;
                case "LatestFirst":
                    flag = true;
                    reader.ReadName();
                    this.m_latestFirst = reader.ReadBoolean();
                    break;
                case "List":
                    flag = true;
                    reader.ReadName();
                    this.m_list = reader.ReadBoolean();
                    break;
                case "Move":
                    flag = true;
                    reader.ReadName();
                    this.m_move = reader.ReadBoolean();
                    break;
                case "Navigation":
                    flag = true;
                    reader.ReadName();
                    this.m_navigation = reader.ReadBoolean();
                    break;
                case "RecursiveAll":
                    flag = true;
                    reader.ReadName();
                    this.m_recursiveAll = reader.ReadBoolean();
                    break;
                case "Rename":
                    flag = true;
                    reader.ReadName();
                    this.m_rename = reader.ReadBoolean();
                    break;
                case "RequireSecurityTrim":
                    flag = true;
                    reader.ReadName();
                    this.m_requireSecurityTrim = reader.ReadBoolean();
                    break;
                case "Restore":
                    flag = true;
                    reader.ReadName();
                    this.m_restore = reader.ReadBoolean();
                    break;
                case "RoleAssignmentAdd":
                    flag = true;
                    reader.ReadName();
                    this.m_roleAssignmentAdd = reader.ReadBoolean();
                    break;
                case "RoleAssignmentDelete":
                    flag = true;
                    reader.ReadName();
                    this.m_roleAssignmentDelete = reader.ReadBoolean();
                    break;
                case "RoleDefinitionAdd":
                    flag = true;
                    reader.ReadName();
                    this.m_roleDefinitionAdd = reader.ReadBoolean();
                    break;
                case "RoleDefinitionDelete":
                    flag = true;
                    reader.ReadName();
                    this.m_roleDefinitionDelete = reader.ReadBoolean();
                    break;
                case "RoleDefinitionUpdate":
                    flag = true;
                    reader.ReadName();
                    this.m_roleDefinitionUpdate = reader.ReadBoolean();
                    break;
                case "SecurityPolicy":
                    flag = true;
                    reader.ReadName();
                    this.m_securityPolicy = reader.ReadBoolean();
                    break;
                case "Site":
                    flag = true;
                    reader.ReadName();
                    this.m_site = reader.ReadBoolean();
                    break;
                case "SystemUpdate":
                    flag = true;
                    reader.ReadName();
                    this.m_systemUpdate = reader.ReadBoolean();
                    break;
                case "Update":
                    flag = true;
                    reader.ReadName();
                    this.m_update = reader.ReadBoolean();
                    break;
                case "User":
                    flag = true;
                    reader.ReadName();
                    this.m_user = reader.ReadBoolean();
                    break;
                case "View":
                    flag = true;
                    reader.ReadName();
                    this.m_view = reader.ReadBoolean();
                    break;
                case "Web":
                    flag = true;
                    reader.ReadName();
                    this.m_web = reader.ReadBoolean();
                    break;
            }
            return flag;
        }
    }
}
