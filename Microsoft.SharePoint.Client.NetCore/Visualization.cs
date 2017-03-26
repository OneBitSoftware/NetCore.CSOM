using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.ComponentModel;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.Visualization", ValueObject = true, ServerTypeId = "{e19fe976-fcf7-4e2b-a738-ae521f941767}")]
    public class Visualization : ClientValueObject
    {
        private VisualizationStyleSet m_defaultScreen;

        private VisualizationStyleSet m_detailView;

        private VisualizationStyleSet m_mediumScreen;

        private VisualizationStyleSet m_smallScreen;

        private VisualizationAppInfo m_visualizationAppInfo;

        private VisualizationType m_visualizationType;

        [Remote]
        public VisualizationStyleSet DefaultScreen
        {
            get
            {
                return this.m_defaultScreen;
            }
            set
            {
                this.m_defaultScreen = value;
            }
        }

        [Remote]
        public VisualizationStyleSet DetailView
        {
            get
            {
                return this.m_detailView;
            }
            set
            {
                this.m_detailView = value;
            }
        }

        [Remote]
        public VisualizationStyleSet MediumScreen
        {
            get
            {
                return this.m_mediumScreen;
            }
            set
            {
                this.m_mediumScreen = value;
            }
        }

        [Remote]
        public VisualizationStyleSet SmallScreen
        {
            get
            {
                return this.m_smallScreen;
            }
            set
            {
                this.m_smallScreen = value;
            }
        }

        [Remote]
        public VisualizationAppInfo VisualizationAppInfo
        {
            get
            {
                return this.m_visualizationAppInfo;
            }
            set
            {
                this.m_visualizationAppInfo = value;
            }
        }

        [Remote]
        public VisualizationType VisualizationType
        {
            get
            {
                return this.m_visualizationType;
            }
            set
            {
                this.m_visualizationType = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string TypeId
        {
            get
            {
                return "{e19fe976-fcf7-4e2b-a738-ae521f941767}";
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
            writer.WriteAttributeString("Name", "DefaultScreen");
            DataConvert.WriteValueToXmlElement(writer, this.DefaultScreen, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "DetailView");
            DataConvert.WriteValueToXmlElement(writer, this.DetailView, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "MediumScreen");
            DataConvert.WriteValueToXmlElement(writer, this.MediumScreen, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "SmallScreen");
            DataConvert.WriteValueToXmlElement(writer, this.SmallScreen, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "VisualizationAppInfo");
            DataConvert.WriteValueToXmlElement(writer, this.VisualizationAppInfo, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "VisualizationType");
            DataConvert.WriteValueToXmlElement(writer, this.VisualizationType, serializationContext);
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
                if (!(peekedName == "DefaultScreen"))
                {
                    if (!(peekedName == "DetailView"))
                    {
                        if (!(peekedName == "MediumScreen"))
                        {
                            if (!(peekedName == "SmallScreen"))
                            {
                                if (!(peekedName == "VisualizationAppInfo"))
                                {
                                    if (peekedName == "VisualizationType")
                                    {
                                        flag = true;
                                        reader.ReadName();
                                        this.m_visualizationType = reader.ReadEnum<VisualizationType>();
                                    }
                                }
                                else
                                {
                                    flag = true;
                                    reader.ReadName();
                                    this.m_visualizationAppInfo = reader.Read<VisualizationAppInfo>();
                                }
                            }
                            else
                            {
                                flag = true;
                                reader.ReadName();
                                this.m_smallScreen = reader.Read<VisualizationStyleSet>();
                            }
                        }
                        else
                        {
                            flag = true;
                            reader.ReadName();
                            this.m_mediumScreen = reader.Read<VisualizationStyleSet>();
                        }
                    }
                    else
                    {
                        flag = true;
                        reader.ReadName();
                        this.m_detailView = reader.Read<VisualizationStyleSet>();
                    }
                }
                else
                {
                    flag = true;
                    reader.ReadName();
                    this.m_defaultScreen = reader.Read<VisualizationStyleSet>();
                }
            }
            return flag;
        }
    }
}
