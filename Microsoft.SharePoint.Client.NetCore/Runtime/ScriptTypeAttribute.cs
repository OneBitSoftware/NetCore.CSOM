using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ScriptTypeAttribute : Attribute
    {
        private string m_scriptType;

        private bool m_valueObject;

        public string ScriptType
        {
            get
            {
                return this.m_scriptType;
            }
            set
            {
                this.m_scriptType = value;
            }
        }

        public string TypeAlias
        {
            get;
            set;
        }

        public bool ValueObject
        {
            get
            {
                return this.m_valueObject;
            }
            set
            {
                this.m_valueObject = value;
            }
        }

        public string ServerTypeId
        {
            get;
            set;
        }

        public ScriptTypeAttribute(string scriptType)
        {
            this.m_scriptType = scriptType;
        }
    }
}
