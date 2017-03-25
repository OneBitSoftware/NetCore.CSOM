using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore
{

    [ScriptType("SP.BasePermissions", ValueObject = true, ServerTypeId = "{db780e5a-6bc6-41ad-8e64-9dfa761afb6d}")]
    public class BasePermissions : ClientValueObject
    {
        private uint m_high;

        private uint m_low;

        [Remote]
        internal uint High
        {
            get
            {
                return this.m_high;
            }
            set
            {
                this.m_high = value;
            }
        }

        [Remote]
        internal uint Low
        {
            get
            {
                return this.m_low;
            }
            set
            {
                this.m_low = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string TypeId
        {
            get
            {
                return "{db780e5a-6bc6-41ad-8e64-9dfa761afb6d}";
            }
        }

        public void Set(PermissionKind perm)
        {
            if (perm == PermissionKind.FullMask)
            {
                this.m_low = 65535u;
                this.m_high = 32767u;
                return;
            }
            if (perm == PermissionKind.EmptyMask)
            {
                this.m_low = 0u;
                this.m_high = 0u;
                return;
            }
            int num = perm - PermissionKind.ViewListItems;
            uint num2 = 1u;
            if (num >= 0 && num < 32)
            {
                num2 <<= num;
                this.m_low |= num2;
                return;
            }
            if (num >= 32 && num < 64)
            {
                num2 <<= num - 32;
                this.m_high |= num2;
            }
        }

        public void Clear(PermissionKind perm)
        {
            int num = perm - PermissionKind.ViewListItems;
            uint num2 = 1u;
            if (num >= 0 && num < 32)
            {
                num2 <<= num;
                num2 = ~num2;
                this.m_low &= num2;
                return;
            }
            if (num >= 32 && num < 64)
            {
                num2 <<= num - 32;
                num2 = ~num2;
                this.m_high &= num2;
            }
        }

        public void ClearAll()
        {
            this.m_high = 0u;
            this.m_low = 0u;
        }

        public bool Has(PermissionKind perm)
        {
            if (perm == PermissionKind.EmptyMask)
            {
                return true;
            }
            if (perm == PermissionKind.FullMask)
            {
                return (this.m_high & 32767u) == 32767u && this.m_low == 65535u;
            }
            int num = perm - PermissionKind.ViewListItems;
            uint num2 = 1u;
            if (num >= 0 && num < 32)
            {
                num2 <<= num;
                return 0u != (this.m_low & num2);
            }
            if (num >= 32 && num < 64)
            {
                num2 <<= num - 32;
                return 0u != (this.m_high & num2);
            }
            return false;
        }

        public override bool Equals(object obj)
        {
            BasePermissions basePermissions = obj as BasePermissions;
            return basePermissions != null && basePermissions.m_high == this.m_high && basePermissions.m_low == this.m_low;
        }

        public override int GetHashCode()
        {
            return this.m_high.GetHashCode() + this.m_low.GetHashCode();
        }

        public bool HasPermissions(uint high, uint low)
        {
            return (this.m_high & high) == high && (this.m_low & low) == low;
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
            writer.WriteAttributeString("Name", "High");
            DataConvert.WriteValueToXmlElement(writer, this.High, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Low");
            DataConvert.WriteValueToXmlElement(writer, this.Low, serializationContext);
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
                if (!(peekedName == "High"))
                {
                    if (peekedName == "Low")
                    {
                        flag = true;
                        reader.ReadName();
                        this.m_low = reader.ReadUInt32();
                    }
                }
                else
                {
                    flag = true;
                    reader.ReadName();
                    this.m_high = reader.ReadUInt32();
                }
            }
            return flag;
        }
    }
}
