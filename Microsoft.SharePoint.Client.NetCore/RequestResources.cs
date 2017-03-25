using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    public class RequestResources
    {
        private Guid m_listId;

        private Guid m_viewId;

        private bool m_userInfoList;

        private bool m_webProperties;

        private bool m_features;

        private bool m_navigationStructure;

        public Guid ListId
        {
            get
            {
                return this.m_listId;
            }
            set
            {
                this.m_listId = value;
            }
        }

        public bool UserInformationList
        {
            get
            {
                return this.m_userInfoList;
            }
            set
            {
                this.m_userInfoList = value;
            }
        }

        public bool WebProperties
        {
            get
            {
                return this.m_webProperties;
            }
            set
            {
                this.m_webProperties = value;
            }
        }

        public bool Features
        {
            get
            {
                return this.m_features;
            }
            set
            {
                this.m_features = value;
            }
        }

        public bool NavigationStructure
        {
            get
            {
                return this.m_navigationStructure;
            }
            set
            {
                this.m_navigationStructure = value;
            }
        }

        public Guid ViewId
        {
            get
            {
                return this.m_viewId;
            }
            set
            {
                this.m_viewId = value;
            }
        }

        internal RequestResources()
        {
        }

        internal string ToHttpHeaderValue()
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            if (this.UserInformationList)
            {
                stringBuilder.Append("USERINFOLIST");
            }
            if (this.WebProperties)
            {
                if (stringBuilder.Length > 0)
                {
                    stringBuilder.Append(",");
                }
                stringBuilder.Append("WEBPROPERTIES");
            }
            if (this.Features)
            {
                if (stringBuilder.Length > 0)
                {
                    stringBuilder.Append(",");
                }
                stringBuilder.Append("FEATURES");
            }
            if (this.NavigationStructure)
            {
                if (stringBuilder.Length > 0)
                {
                    stringBuilder.Append(",");
                }
                stringBuilder.Append("NAVIGATIONSTRUCTURE");
            }
            if (this.ListId != Guid.Empty)
            {
                if (stringBuilder.Length > 0)
                {
                    stringBuilder.Append(",");
                }
                stringBuilder.Append("LIST");
                stringBuilder.Append("=");
                stringBuilder.Append(this.ListId.ToString());
            }
            if (this.ViewId != Guid.Empty)
            {
                if (stringBuilder.Length > 0)
                {
                    stringBuilder.Append(",");
                }
                stringBuilder.Append("VIEW");
                stringBuilder.Append("=");
                stringBuilder.Append(this.ViewId.ToString());
            }
            return stringBuilder.ToString();
        }
    }
}
