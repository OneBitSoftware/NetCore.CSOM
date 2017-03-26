using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.ComponentModel;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore
{

    [ScriptType("SP.RenderListDataOverrideParameters", ValueObject = true, ServerTypeId = "{ad0885e6-0f16-4694-9397-058c65376fb7}")]
    public class RenderListDataOverrideParameters : ClientValueObject
    {
        private string m_cascDelWarnMessage;

        private string m_customAction;

        private string m_drillDown;

        private string m_field;

        private string m_fieldInternalName;

        private string m_filter;

        private string m_filterData;

        private string m_filterData1;

        private string m_filterData10;

        private string m_filterData2;

        private string m_filterData3;

        private string m_filterData4;

        private string m_filterData5;

        private string m_filterData6;

        private string m_filterData7;

        private string m_filterData8;

        private string m_filterData9;

        private string m_filterField;

        private string m_filterField1;

        private string m_filterField10;

        private string m_filterField2;

        private string m_filterField3;

        private string m_filterField4;

        private string m_filterField5;

        private string m_filterField6;

        private string m_filterField7;

        private string m_filterField8;

        private string m_filterField9;

        private string m_filterFields;

        private string m_filterFields1;

        private string m_filterFields10;

        private string m_filterFields2;

        private string m_filterFields3;

        private string m_filterFields4;

        private string m_filterFields5;

        private string m_filterFields6;

        private string m_filterFields7;

        private string m_filterFields8;

        private string m_filterFields9;

        private string m_filterLookupId;

        private string m_filterLookupId1;

        private string m_filterLookupId10;

        private string m_filterLookupId2;

        private string m_filterLookupId3;

        private string m_filterLookupId4;

        private string m_filterLookupId5;

        private string m_filterLookupId6;

        private string m_filterLookupId7;

        private string m_filterLookupId8;

        private string m_filterLookupId9;

        private string m_filterOp;

        private string m_filterOp1;

        private string m_filterOp10;

        private string m_filterOp2;

        private string m_filterOp3;

        private string m_filterOp4;

        private string m_filterOp5;

        private string m_filterOp6;

        private string m_filterOp7;

        private string m_filterOp8;

        private string m_filterOp9;

        private string m_filterValue;

        private string m_filterValue1;

        private string m_filterValue10;

        private string m_filterValue2;

        private string m_filterValue3;

        private string m_filterValue4;

        private string m_filterValue5;

        private string m_filterValue6;

        private string m_filterValue7;

        private string m_filterValue8;

        private string m_filterValue9;

        private string m_filterValues;

        private string m_filterValues1;

        private string m_filterValues10;

        private string m_filterValues2;

        private string m_filterValues3;

        private string m_filterValues4;

        private string m_filterValues5;

        private string m_filterValues6;

        private string m_filterValues7;

        private string m_filterValues8;

        private string m_filterValues9;

        private string m_groupString;

        private string m_hasOverrideSelectCommand;

        private string m_iD;

        private string m_inplaceFullListSearch;

        private string m_inplaceSearchQuery;

        private string m_isCSR;

        private string m_isGroupRender;

        private string m_isXslView;

        private string m_listViewPageUrl;

        private string m_overrideScope;

        private string m_overrideSelectCommand;

        private string m_pageFirstRow;

        private string m_pageLastRow;

        private string m_rootFolder;

        private string m_sortDir;

        private string m_sortDir1;

        private string m_sortDir10;

        private string m_sortDir2;

        private string m_sortDir3;

        private string m_sortDir4;

        private string m_sortDir5;

        private string m_sortDir6;

        private string m_sortDir7;

        private string m_sortDir8;

        private string m_sortDir9;

        private string m_sortField;

        private string m_sortField1;

        private string m_sortField10;

        private string m_sortField2;

        private string m_sortField3;

        private string m_sortField4;

        private string m_sortField5;

        private string m_sortField6;

        private string m_sortField7;

        private string m_sortField8;

        private string m_sortField9;

        private string m_sortFields;

        private string m_sortFieldValues;

        private string m_view;

        private string m_viewCount;

        private string m_viewId;

        private string m_webPartId;

        [Remote]
        public string CascDelWarnMessage
        {
            get
            {
                return this.m_cascDelWarnMessage;
            }
            set
            {
                this.m_cascDelWarnMessage = value;
            }
        }

        [Remote]
        public string CustomAction
        {
            get
            {
                return this.m_customAction;
            }
            set
            {
                this.m_customAction = value;
            }
        }

        [Remote]
        public string DrillDown
        {
            get
            {
                return this.m_drillDown;
            }
            set
            {
                this.m_drillDown = value;
            }
        }

        [Remote]
        public string Field
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
        public string FieldInternalName
        {
            get
            {
                return this.m_fieldInternalName;
            }
            set
            {
                this.m_fieldInternalName = value;
            }
        }

        [Remote]
        public string Filter
        {
            get
            {
                return this.m_filter;
            }
            set
            {
                this.m_filter = value;
            }
        }

        [Remote]
        public string FilterData
        {
            get
            {
                return this.m_filterData;
            }
            set
            {
                this.m_filterData = value;
            }
        }

        [Remote]
        public string FilterData1
        {
            get
            {
                return this.m_filterData1;
            }
            set
            {
                this.m_filterData1 = value;
            }
        }

        [Remote]
        public string FilterData10
        {
            get
            {
                return this.m_filterData10;
            }
            set
            {
                this.m_filterData10 = value;
            }
        }

        [Remote]
        public string FilterData2
        {
            get
            {
                return this.m_filterData2;
            }
            set
            {
                this.m_filterData2 = value;
            }
        }

        [Remote]
        public string FilterData3
        {
            get
            {
                return this.m_filterData3;
            }
            set
            {
                this.m_filterData3 = value;
            }
        }

        [Remote]
        public string FilterData4
        {
            get
            {
                return this.m_filterData4;
            }
            set
            {
                this.m_filterData4 = value;
            }
        }

        [Remote]
        public string FilterData5
        {
            get
            {
                return this.m_filterData5;
            }
            set
            {
                this.m_filterData5 = value;
            }
        }

        [Remote]
        public string FilterData6
        {
            get
            {
                return this.m_filterData6;
            }
            set
            {
                this.m_filterData6 = value;
            }
        }

        [Remote]
        public string FilterData7
        {
            get
            {
                return this.m_filterData7;
            }
            set
            {
                this.m_filterData7 = value;
            }
        }

        [Remote]
        public string FilterData8
        {
            get
            {
                return this.m_filterData8;
            }
            set
            {
                this.m_filterData8 = value;
            }
        }

        [Remote]
        public string FilterData9
        {
            get
            {
                return this.m_filterData9;
            }
            set
            {
                this.m_filterData9 = value;
            }
        }

        [Remote]
        public string FilterField
        {
            get
            {
                return this.m_filterField;
            }
            set
            {
                this.m_filterField = value;
            }
        }

        [Remote]
        public string FilterField1
        {
            get
            {
                return this.m_filterField1;
            }
            set
            {
                this.m_filterField1 = value;
            }
        }

        [Remote]
        public string FilterField10
        {
            get
            {
                return this.m_filterField10;
            }
            set
            {
                this.m_filterField10 = value;
            }
        }

        [Remote]
        public string FilterField2
        {
            get
            {
                return this.m_filterField2;
            }
            set
            {
                this.m_filterField2 = value;
            }
        }

        [Remote]
        public string FilterField3
        {
            get
            {
                return this.m_filterField3;
            }
            set
            {
                this.m_filterField3 = value;
            }
        }

        [Remote]
        public string FilterField4
        {
            get
            {
                return this.m_filterField4;
            }
            set
            {
                this.m_filterField4 = value;
            }
        }

        [Remote]
        public string FilterField5
        {
            get
            {
                return this.m_filterField5;
            }
            set
            {
                this.m_filterField5 = value;
            }
        }

        [Remote]
        public string FilterField6
        {
            get
            {
                return this.m_filterField6;
            }
            set
            {
                this.m_filterField6 = value;
            }
        }

        [Remote]
        public string FilterField7
        {
            get
            {
                return this.m_filterField7;
            }
            set
            {
                this.m_filterField7 = value;
            }
        }

        [Remote]
        public string FilterField8
        {
            get
            {
                return this.m_filterField8;
            }
            set
            {
                this.m_filterField8 = value;
            }
        }

        [Remote]
        public string FilterField9
        {
            get
            {
                return this.m_filterField9;
            }
            set
            {
                this.m_filterField9 = value;
            }
        }

        [Remote]
        public string FilterFields
        {
            get
            {
                return this.m_filterFields;
            }
            set
            {
                this.m_filterFields = value;
            }
        }

        [Remote]
        public string FilterFields1
        {
            get
            {
                return this.m_filterFields1;
            }
            set
            {
                this.m_filterFields1 = value;
            }
        }

        [Remote]
        public string FilterFields10
        {
            get
            {
                return this.m_filterFields10;
            }
            set
            {
                this.m_filterFields10 = value;
            }
        }

        [Remote]
        public string FilterFields2
        {
            get
            {
                return this.m_filterFields2;
            }
            set
            {
                this.m_filterFields2 = value;
            }
        }

        [Remote]
        public string FilterFields3
        {
            get
            {
                return this.m_filterFields3;
            }
            set
            {
                this.m_filterFields3 = value;
            }
        }

        [Remote]
        public string FilterFields4
        {
            get
            {
                return this.m_filterFields4;
            }
            set
            {
                this.m_filterFields4 = value;
            }
        }

        [Remote]
        public string FilterFields5
        {
            get
            {
                return this.m_filterFields5;
            }
            set
            {
                this.m_filterFields5 = value;
            }
        }

        [Remote]
        public string FilterFields6
        {
            get
            {
                return this.m_filterFields6;
            }
            set
            {
                this.m_filterFields6 = value;
            }
        }

        [Remote]
        public string FilterFields7
        {
            get
            {
                return this.m_filterFields7;
            }
            set
            {
                this.m_filterFields7 = value;
            }
        }

        [Remote]
        public string FilterFields8
        {
            get
            {
                return this.m_filterFields8;
            }
            set
            {
                this.m_filterFields8 = value;
            }
        }

        [Remote]
        public string FilterFields9
        {
            get
            {
                return this.m_filterFields9;
            }
            set
            {
                this.m_filterFields9 = value;
            }
        }

        [Remote]
        public string FilterLookupId
        {
            get
            {
                return this.m_filterLookupId;
            }
            set
            {
                this.m_filterLookupId = value;
            }
        }

        [Remote]
        public string FilterLookupId1
        {
            get
            {
                return this.m_filterLookupId1;
            }
            set
            {
                this.m_filterLookupId1 = value;
            }
        }

        [Remote]
        public string FilterLookupId10
        {
            get
            {
                return this.m_filterLookupId10;
            }
            set
            {
                this.m_filterLookupId10 = value;
            }
        }

        [Remote]
        public string FilterLookupId2
        {
            get
            {
                return this.m_filterLookupId2;
            }
            set
            {
                this.m_filterLookupId2 = value;
            }
        }

        [Remote]
        public string FilterLookupId3
        {
            get
            {
                return this.m_filterLookupId3;
            }
            set
            {
                this.m_filterLookupId3 = value;
            }
        }

        [Remote]
        public string FilterLookupId4
        {
            get
            {
                return this.m_filterLookupId4;
            }
            set
            {
                this.m_filterLookupId4 = value;
            }
        }

        [Remote]
        public string FilterLookupId5
        {
            get
            {
                return this.m_filterLookupId5;
            }
            set
            {
                this.m_filterLookupId5 = value;
            }
        }

        [Remote]
        public string FilterLookupId6
        {
            get
            {
                return this.m_filterLookupId6;
            }
            set
            {
                this.m_filterLookupId6 = value;
            }
        }

        [Remote]
        public string FilterLookupId7
        {
            get
            {
                return this.m_filterLookupId7;
            }
            set
            {
                this.m_filterLookupId7 = value;
            }
        }

        [Remote]
        public string FilterLookupId8
        {
            get
            {
                return this.m_filterLookupId8;
            }
            set
            {
                this.m_filterLookupId8 = value;
            }
        }

        [Remote]
        public string FilterLookupId9
        {
            get
            {
                return this.m_filterLookupId9;
            }
            set
            {
                this.m_filterLookupId9 = value;
            }
        }

        [Remote]
        public string FilterOp
        {
            get
            {
                return this.m_filterOp;
            }
            set
            {
                this.m_filterOp = value;
            }
        }

        [Remote]
        public string FilterOp1
        {
            get
            {
                return this.m_filterOp1;
            }
            set
            {
                this.m_filterOp1 = value;
            }
        }

        [Remote]
        public string FilterOp10
        {
            get
            {
                return this.m_filterOp10;
            }
            set
            {
                this.m_filterOp10 = value;
            }
        }

        [Remote]
        public string FilterOp2
        {
            get
            {
                return this.m_filterOp2;
            }
            set
            {
                this.m_filterOp2 = value;
            }
        }

        [Remote]
        public string FilterOp3
        {
            get
            {
                return this.m_filterOp3;
            }
            set
            {
                this.m_filterOp3 = value;
            }
        }

        [Remote]
        public string FilterOp4
        {
            get
            {
                return this.m_filterOp4;
            }
            set
            {
                this.m_filterOp4 = value;
            }
        }

        [Remote]
        public string FilterOp5
        {
            get
            {
                return this.m_filterOp5;
            }
            set
            {
                this.m_filterOp5 = value;
            }
        }

        [Remote]
        public string FilterOp6
        {
            get
            {
                return this.m_filterOp6;
            }
            set
            {
                this.m_filterOp6 = value;
            }
        }

        [Remote]
        public string FilterOp7
        {
            get
            {
                return this.m_filterOp7;
            }
            set
            {
                this.m_filterOp7 = value;
            }
        }

        [Remote]
        public string FilterOp8
        {
            get
            {
                return this.m_filterOp8;
            }
            set
            {
                this.m_filterOp8 = value;
            }
        }

        [Remote]
        public string FilterOp9
        {
            get
            {
                return this.m_filterOp9;
            }
            set
            {
                this.m_filterOp9 = value;
            }
        }

        [Remote]
        public string FilterValue
        {
            get
            {
                return this.m_filterValue;
            }
            set
            {
                this.m_filterValue = value;
            }
        }

        [Remote]
        public string FilterValue1
        {
            get
            {
                return this.m_filterValue1;
            }
            set
            {
                this.m_filterValue1 = value;
            }
        }

        [Remote]
        public string FilterValue10
        {
            get
            {
                return this.m_filterValue10;
            }
            set
            {
                this.m_filterValue10 = value;
            }
        }

        [Remote]
        public string FilterValue2
        {
            get
            {
                return this.m_filterValue2;
            }
            set
            {
                this.m_filterValue2 = value;
            }
        }

        [Remote]
        public string FilterValue3
        {
            get
            {
                return this.m_filterValue3;
            }
            set
            {
                this.m_filterValue3 = value;
            }
        }

        [Remote]
        public string FilterValue4
        {
            get
            {
                return this.m_filterValue4;
            }
            set
            {
                this.m_filterValue4 = value;
            }
        }

        [Remote]
        public string FilterValue5
        {
            get
            {
                return this.m_filterValue5;
            }
            set
            {
                this.m_filterValue5 = value;
            }
        }

        [Remote]
        public string FilterValue6
        {
            get
            {
                return this.m_filterValue6;
            }
            set
            {
                this.m_filterValue6 = value;
            }
        }

        [Remote]
        public string FilterValue7
        {
            get
            {
                return this.m_filterValue7;
            }
            set
            {
                this.m_filterValue7 = value;
            }
        }

        [Remote]
        public string FilterValue8
        {
            get
            {
                return this.m_filterValue8;
            }
            set
            {
                this.m_filterValue8 = value;
            }
        }

        [Remote]
        public string FilterValue9
        {
            get
            {
                return this.m_filterValue9;
            }
            set
            {
                this.m_filterValue9 = value;
            }
        }

        [Remote]
        public string FilterValues
        {
            get
            {
                return this.m_filterValues;
            }
            set
            {
                this.m_filterValues = value;
            }
        }

        [Remote]
        public string FilterValues1
        {
            get
            {
                return this.m_filterValues1;
            }
            set
            {
                this.m_filterValues1 = value;
            }
        }

        [Remote]
        public string FilterValues10
        {
            get
            {
                return this.m_filterValues10;
            }
            set
            {
                this.m_filterValues10 = value;
            }
        }

        [Remote]
        public string FilterValues2
        {
            get
            {
                return this.m_filterValues2;
            }
            set
            {
                this.m_filterValues2 = value;
            }
        }

        [Remote]
        public string FilterValues3
        {
            get
            {
                return this.m_filterValues3;
            }
            set
            {
                this.m_filterValues3 = value;
            }
        }

        [Remote]
        public string FilterValues4
        {
            get
            {
                return this.m_filterValues4;
            }
            set
            {
                this.m_filterValues4 = value;
            }
        }

        [Remote]
        public string FilterValues5
        {
            get
            {
                return this.m_filterValues5;
            }
            set
            {
                this.m_filterValues5 = value;
            }
        }

        [Remote]
        public string FilterValues6
        {
            get
            {
                return this.m_filterValues6;
            }
            set
            {
                this.m_filterValues6 = value;
            }
        }

        [Remote]
        public string FilterValues7
        {
            get
            {
                return this.m_filterValues7;
            }
            set
            {
                this.m_filterValues7 = value;
            }
        }

        [Remote]
        public string FilterValues8
        {
            get
            {
                return this.m_filterValues8;
            }
            set
            {
                this.m_filterValues8 = value;
            }
        }

        [Remote]
        public string FilterValues9
        {
            get
            {
                return this.m_filterValues9;
            }
            set
            {
                this.m_filterValues9 = value;
            }
        }

        [Remote]
        public string GroupString
        {
            get
            {
                return this.m_groupString;
            }
            set
            {
                this.m_groupString = value;
            }
        }

        [Remote]
        public string HasOverrideSelectCommand
        {
            get
            {
                return this.m_hasOverrideSelectCommand;
            }
            set
            {
                this.m_hasOverrideSelectCommand = value;
            }
        }

        [Remote]
        public string ID
        {
            get
            {
                return this.m_iD;
            }
            set
            {
                this.m_iD = value;
            }
        }

        [Remote]
        public string InplaceFullListSearch
        {
            get
            {
                return this.m_inplaceFullListSearch;
            }
            set
            {
                this.m_inplaceFullListSearch = value;
            }
        }

        [Remote]
        public string InplaceSearchQuery
        {
            get
            {
                return this.m_inplaceSearchQuery;
            }
            set
            {
                this.m_inplaceSearchQuery = value;
            }
        }

        [Remote]
        public string IsCSR
        {
            get
            {
                return this.m_isCSR;
            }
            set
            {
                this.m_isCSR = value;
            }
        }

        [Remote]
        public string IsGroupRender
        {
            get
            {
                return this.m_isGroupRender;
            }
            set
            {
                this.m_isGroupRender = value;
            }
        }

        [Remote]
        public string IsXslView
        {
            get
            {
                return this.m_isXslView;
            }
            set
            {
                this.m_isXslView = value;
            }
        }

        [Remote]
        public string ListViewPageUrl
        {
            get
            {
                return this.m_listViewPageUrl;
            }
            set
            {
                this.m_listViewPageUrl = value;
            }
        }

        [Remote]
        public string OverrideScope
        {
            get
            {
                return this.m_overrideScope;
            }
            set
            {
                this.m_overrideScope = value;
            }
        }

        [Remote]
        public string OverrideSelectCommand
        {
            get
            {
                return this.m_overrideSelectCommand;
            }
            set
            {
                this.m_overrideSelectCommand = value;
            }
        }

        [Remote]
        public string PageFirstRow
        {
            get
            {
                return this.m_pageFirstRow;
            }
            set
            {
                this.m_pageFirstRow = value;
            }
        }

        [Remote]
        public string PageLastRow
        {
            get
            {
                return this.m_pageLastRow;
            }
            set
            {
                this.m_pageLastRow = value;
            }
        }

        [Remote]
        public string RootFolder
        {
            get
            {
                return this.m_rootFolder;
            }
            set
            {
                this.m_rootFolder = value;
            }
        }

        [Remote]
        public string SortDir
        {
            get
            {
                return this.m_sortDir;
            }
            set
            {
                this.m_sortDir = value;
            }
        }

        [Remote]
        public string SortDir1
        {
            get
            {
                return this.m_sortDir1;
            }
            set
            {
                this.m_sortDir1 = value;
            }
        }

        [Remote]
        public string SortDir10
        {
            get
            {
                return this.m_sortDir10;
            }
            set
            {
                this.m_sortDir10 = value;
            }
        }

        [Remote]
        public string SortDir2
        {
            get
            {
                return this.m_sortDir2;
            }
            set
            {
                this.m_sortDir2 = value;
            }
        }

        [Remote]
        public string SortDir3
        {
            get
            {
                return this.m_sortDir3;
            }
            set
            {
                this.m_sortDir3 = value;
            }
        }

        [Remote]
        public string SortDir4
        {
            get
            {
                return this.m_sortDir4;
            }
            set
            {
                this.m_sortDir4 = value;
            }
        }

        [Remote]
        public string SortDir5
        {
            get
            {
                return this.m_sortDir5;
            }
            set
            {
                this.m_sortDir5 = value;
            }
        }

        [Remote]
        public string SortDir6
        {
            get
            {
                return this.m_sortDir6;
            }
            set
            {
                this.m_sortDir6 = value;
            }
        }

        [Remote]
        public string SortDir7
        {
            get
            {
                return this.m_sortDir7;
            }
            set
            {
                this.m_sortDir7 = value;
            }
        }

        [Remote]
        public string SortDir8
        {
            get
            {
                return this.m_sortDir8;
            }
            set
            {
                this.m_sortDir8 = value;
            }
        }

        [Remote]
        public string SortDir9
        {
            get
            {
                return this.m_sortDir9;
            }
            set
            {
                this.m_sortDir9 = value;
            }
        }

        [Remote]
        public string SortField
        {
            get
            {
                return this.m_sortField;
            }
            set
            {
                this.m_sortField = value;
            }
        }

        [Remote]
        public string SortField1
        {
            get
            {
                return this.m_sortField1;
            }
            set
            {
                this.m_sortField1 = value;
            }
        }

        [Remote]
        public string SortField10
        {
            get
            {
                return this.m_sortField10;
            }
            set
            {
                this.m_sortField10 = value;
            }
        }

        [Remote]
        public string SortField2
        {
            get
            {
                return this.m_sortField2;
            }
            set
            {
                this.m_sortField2 = value;
            }
        }

        [Remote]
        public string SortField3
        {
            get
            {
                return this.m_sortField3;
            }
            set
            {
                this.m_sortField3 = value;
            }
        }

        [Remote]
        public string SortField4
        {
            get
            {
                return this.m_sortField4;
            }
            set
            {
                this.m_sortField4 = value;
            }
        }

        [Remote]
        public string SortField5
        {
            get
            {
                return this.m_sortField5;
            }
            set
            {
                this.m_sortField5 = value;
            }
        }

        [Remote]
        public string SortField6
        {
            get
            {
                return this.m_sortField6;
            }
            set
            {
                this.m_sortField6 = value;
            }
        }

        [Remote]
        public string SortField7
        {
            get
            {
                return this.m_sortField7;
            }
            set
            {
                this.m_sortField7 = value;
            }
        }

        [Remote]
        public string SortField8
        {
            get
            {
                return this.m_sortField8;
            }
            set
            {
                this.m_sortField8 = value;
            }
        }

        [Remote]
        public string SortField9
        {
            get
            {
                return this.m_sortField9;
            }
            set
            {
                this.m_sortField9 = value;
            }
        }

        [Remote]
        public string SortFields
        {
            get
            {
                return this.m_sortFields;
            }
            set
            {
                this.m_sortFields = value;
            }
        }

        [Remote]
        public string SortFieldValues
        {
            get
            {
                return this.m_sortFieldValues;
            }
            set
            {
                this.m_sortFieldValues = value;
            }
        }

        [Remote]
        public string View
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
        public string ViewCount
        {
            get
            {
                return this.m_viewCount;
            }
            set
            {
                this.m_viewCount = value;
            }
        }

        [Remote]
        public string ViewId
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

        [Remote]
        public string WebPartId
        {
            get
            {
                return this.m_webPartId;
            }
            set
            {
                this.m_webPartId = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string TypeId
        {
            get
            {
                return "{ad0885e6-0f16-4694-9397-058c65376fb7}";
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
            writer.WriteAttributeString("Name", "CascDelWarnMessage");
            DataConvert.WriteValueToXmlElement(writer, this.CascDelWarnMessage, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "CustomAction");
            DataConvert.WriteValueToXmlElement(writer, this.CustomAction, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "DrillDown");
            DataConvert.WriteValueToXmlElement(writer, this.DrillDown, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Field");
            DataConvert.WriteValueToXmlElement(writer, this.Field, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FieldInternalName");
            DataConvert.WriteValueToXmlElement(writer, this.FieldInternalName, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Filter");
            DataConvert.WriteValueToXmlElement(writer, this.Filter, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterData");
            DataConvert.WriteValueToXmlElement(writer, this.FilterData, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterData1");
            DataConvert.WriteValueToXmlElement(writer, this.FilterData1, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterData10");
            DataConvert.WriteValueToXmlElement(writer, this.FilterData10, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterData2");
            DataConvert.WriteValueToXmlElement(writer, this.FilterData2, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterData3");
            DataConvert.WriteValueToXmlElement(writer, this.FilterData3, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterData4");
            DataConvert.WriteValueToXmlElement(writer, this.FilterData4, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterData5");
            DataConvert.WriteValueToXmlElement(writer, this.FilterData5, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterData6");
            DataConvert.WriteValueToXmlElement(writer, this.FilterData6, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterData7");
            DataConvert.WriteValueToXmlElement(writer, this.FilterData7, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterData8");
            DataConvert.WriteValueToXmlElement(writer, this.FilterData8, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterData9");
            DataConvert.WriteValueToXmlElement(writer, this.FilterData9, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterField");
            DataConvert.WriteValueToXmlElement(writer, this.FilterField, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterField1");
            DataConvert.WriteValueToXmlElement(writer, this.FilterField1, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterField10");
            DataConvert.WriteValueToXmlElement(writer, this.FilterField10, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterField2");
            DataConvert.WriteValueToXmlElement(writer, this.FilterField2, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterField3");
            DataConvert.WriteValueToXmlElement(writer, this.FilterField3, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterField4");
            DataConvert.WriteValueToXmlElement(writer, this.FilterField4, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterField5");
            DataConvert.WriteValueToXmlElement(writer, this.FilterField5, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterField6");
            DataConvert.WriteValueToXmlElement(writer, this.FilterField6, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterField7");
            DataConvert.WriteValueToXmlElement(writer, this.FilterField7, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterField8");
            DataConvert.WriteValueToXmlElement(writer, this.FilterField8, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterField9");
            DataConvert.WriteValueToXmlElement(writer, this.FilterField9, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterFields");
            DataConvert.WriteValueToXmlElement(writer, this.FilterFields, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterFields1");
            DataConvert.WriteValueToXmlElement(writer, this.FilterFields1, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterFields10");
            DataConvert.WriteValueToXmlElement(writer, this.FilterFields10, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterFields2");
            DataConvert.WriteValueToXmlElement(writer, this.FilterFields2, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterFields3");
            DataConvert.WriteValueToXmlElement(writer, this.FilterFields3, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterFields4");
            DataConvert.WriteValueToXmlElement(writer, this.FilterFields4, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterFields5");
            DataConvert.WriteValueToXmlElement(writer, this.FilterFields5, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterFields6");
            DataConvert.WriteValueToXmlElement(writer, this.FilterFields6, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterFields7");
            DataConvert.WriteValueToXmlElement(writer, this.FilterFields7, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterFields8");
            DataConvert.WriteValueToXmlElement(writer, this.FilterFields8, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterFields9");
            DataConvert.WriteValueToXmlElement(writer, this.FilterFields9, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterLookupId");
            DataConvert.WriteValueToXmlElement(writer, this.FilterLookupId, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterLookupId1");
            DataConvert.WriteValueToXmlElement(writer, this.FilterLookupId1, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterLookupId10");
            DataConvert.WriteValueToXmlElement(writer, this.FilterLookupId10, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterLookupId2");
            DataConvert.WriteValueToXmlElement(writer, this.FilterLookupId2, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterLookupId3");
            DataConvert.WriteValueToXmlElement(writer, this.FilterLookupId3, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterLookupId4");
            DataConvert.WriteValueToXmlElement(writer, this.FilterLookupId4, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterLookupId5");
            DataConvert.WriteValueToXmlElement(writer, this.FilterLookupId5, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterLookupId6");
            DataConvert.WriteValueToXmlElement(writer, this.FilterLookupId6, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterLookupId7");
            DataConvert.WriteValueToXmlElement(writer, this.FilterLookupId7, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterLookupId8");
            DataConvert.WriteValueToXmlElement(writer, this.FilterLookupId8, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterLookupId9");
            DataConvert.WriteValueToXmlElement(writer, this.FilterLookupId9, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterOp");
            DataConvert.WriteValueToXmlElement(writer, this.FilterOp, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterOp1");
            DataConvert.WriteValueToXmlElement(writer, this.FilterOp1, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterOp10");
            DataConvert.WriteValueToXmlElement(writer, this.FilterOp10, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterOp2");
            DataConvert.WriteValueToXmlElement(writer, this.FilterOp2, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterOp3");
            DataConvert.WriteValueToXmlElement(writer, this.FilterOp3, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterOp4");
            DataConvert.WriteValueToXmlElement(writer, this.FilterOp4, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterOp5");
            DataConvert.WriteValueToXmlElement(writer, this.FilterOp5, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterOp6");
            DataConvert.WriteValueToXmlElement(writer, this.FilterOp6, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterOp7");
            DataConvert.WriteValueToXmlElement(writer, this.FilterOp7, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterOp8");
            DataConvert.WriteValueToXmlElement(writer, this.FilterOp8, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterOp9");
            DataConvert.WriteValueToXmlElement(writer, this.FilterOp9, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterValue");
            DataConvert.WriteValueToXmlElement(writer, this.FilterValue, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterValue1");
            DataConvert.WriteValueToXmlElement(writer, this.FilterValue1, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterValue10");
            DataConvert.WriteValueToXmlElement(writer, this.FilterValue10, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterValue2");
            DataConvert.WriteValueToXmlElement(writer, this.FilterValue2, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterValue3");
            DataConvert.WriteValueToXmlElement(writer, this.FilterValue3, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterValue4");
            DataConvert.WriteValueToXmlElement(writer, this.FilterValue4, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterValue5");
            DataConvert.WriteValueToXmlElement(writer, this.FilterValue5, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterValue6");
            DataConvert.WriteValueToXmlElement(writer, this.FilterValue6, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterValue7");
            DataConvert.WriteValueToXmlElement(writer, this.FilterValue7, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterValue8");
            DataConvert.WriteValueToXmlElement(writer, this.FilterValue8, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterValue9");
            DataConvert.WriteValueToXmlElement(writer, this.FilterValue9, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterValues");
            DataConvert.WriteValueToXmlElement(writer, this.FilterValues, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterValues1");
            DataConvert.WriteValueToXmlElement(writer, this.FilterValues1, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterValues10");
            DataConvert.WriteValueToXmlElement(writer, this.FilterValues10, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterValues2");
            DataConvert.WriteValueToXmlElement(writer, this.FilterValues2, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterValues3");
            DataConvert.WriteValueToXmlElement(writer, this.FilterValues3, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterValues4");
            DataConvert.WriteValueToXmlElement(writer, this.FilterValues4, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterValues5");
            DataConvert.WriteValueToXmlElement(writer, this.FilterValues5, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterValues6");
            DataConvert.WriteValueToXmlElement(writer, this.FilterValues6, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterValues7");
            DataConvert.WriteValueToXmlElement(writer, this.FilterValues7, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterValues8");
            DataConvert.WriteValueToXmlElement(writer, this.FilterValues8, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FilterValues9");
            DataConvert.WriteValueToXmlElement(writer, this.FilterValues9, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "GroupString");
            DataConvert.WriteValueToXmlElement(writer, this.GroupString, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "HasOverrideSelectCommand");
            DataConvert.WriteValueToXmlElement(writer, this.HasOverrideSelectCommand, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "ID");
            DataConvert.WriteValueToXmlElement(writer, this.ID, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "InplaceFullListSearch");
            DataConvert.WriteValueToXmlElement(writer, this.InplaceFullListSearch, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "InplaceSearchQuery");
            DataConvert.WriteValueToXmlElement(writer, this.InplaceSearchQuery, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "IsCSR");
            DataConvert.WriteValueToXmlElement(writer, this.IsCSR, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "IsGroupRender");
            DataConvert.WriteValueToXmlElement(writer, this.IsGroupRender, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "IsXslView");
            DataConvert.WriteValueToXmlElement(writer, this.IsXslView, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "ListViewPageUrl");
            DataConvert.WriteValueToXmlElement(writer, this.ListViewPageUrl, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "OverrideScope");
            DataConvert.WriteValueToXmlElement(writer, this.OverrideScope, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "OverrideSelectCommand");
            DataConvert.WriteValueToXmlElement(writer, this.OverrideSelectCommand, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "PageFirstRow");
            DataConvert.WriteValueToXmlElement(writer, this.PageFirstRow, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "PageLastRow");
            DataConvert.WriteValueToXmlElement(writer, this.PageLastRow, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "RootFolder");
            DataConvert.WriteValueToXmlElement(writer, this.RootFolder, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "SortDir");
            DataConvert.WriteValueToXmlElement(writer, this.SortDir, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "SortDir1");
            DataConvert.WriteValueToXmlElement(writer, this.SortDir1, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "SortDir10");
            DataConvert.WriteValueToXmlElement(writer, this.SortDir10, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "SortDir2");
            DataConvert.WriteValueToXmlElement(writer, this.SortDir2, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "SortDir3");
            DataConvert.WriteValueToXmlElement(writer, this.SortDir3, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "SortDir4");
            DataConvert.WriteValueToXmlElement(writer, this.SortDir4, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "SortDir5");
            DataConvert.WriteValueToXmlElement(writer, this.SortDir5, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "SortDir6");
            DataConvert.WriteValueToXmlElement(writer, this.SortDir6, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "SortDir7");
            DataConvert.WriteValueToXmlElement(writer, this.SortDir7, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "SortDir8");
            DataConvert.WriteValueToXmlElement(writer, this.SortDir8, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "SortDir9");
            DataConvert.WriteValueToXmlElement(writer, this.SortDir9, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "SortField");
            DataConvert.WriteValueToXmlElement(writer, this.SortField, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "SortField1");
            DataConvert.WriteValueToXmlElement(writer, this.SortField1, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "SortField10");
            DataConvert.WriteValueToXmlElement(writer, this.SortField10, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "SortField2");
            DataConvert.WriteValueToXmlElement(writer, this.SortField2, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "SortField3");
            DataConvert.WriteValueToXmlElement(writer, this.SortField3, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "SortField4");
            DataConvert.WriteValueToXmlElement(writer, this.SortField4, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "SortField5");
            DataConvert.WriteValueToXmlElement(writer, this.SortField5, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "SortField6");
            DataConvert.WriteValueToXmlElement(writer, this.SortField6, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "SortField7");
            DataConvert.WriteValueToXmlElement(writer, this.SortField7, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "SortField8");
            DataConvert.WriteValueToXmlElement(writer, this.SortField8, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "SortField9");
            DataConvert.WriteValueToXmlElement(writer, this.SortField9, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "SortFields");
            DataConvert.WriteValueToXmlElement(writer, this.SortFields, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "SortFieldValues");
            DataConvert.WriteValueToXmlElement(writer, this.SortFieldValues, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "View");
            DataConvert.WriteValueToXmlElement(writer, this.View, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "ViewCount");
            DataConvert.WriteValueToXmlElement(writer, this.ViewCount, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "ViewId");
            DataConvert.WriteValueToXmlElement(writer, this.ViewId, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "WebPartId");
            DataConvert.WriteValueToXmlElement(writer, this.WebPartId, serializationContext);
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
                case "CascDelWarnMessage":
                    flag = true;
                    reader.ReadName();
                    this.m_cascDelWarnMessage = reader.ReadString();
                    break;
                case "CustomAction":
                    flag = true;
                    reader.ReadName();
                    this.m_customAction = reader.ReadString();
                    break;
                case "DrillDown":
                    flag = true;
                    reader.ReadName();
                    this.m_drillDown = reader.ReadString();
                    break;
                case "Field":
                    flag = true;
                    reader.ReadName();
                    this.m_field = reader.ReadString();
                    break;
                case "FieldInternalName":
                    flag = true;
                    reader.ReadName();
                    this.m_fieldInternalName = reader.ReadString();
                    break;
                case "Filter":
                    flag = true;
                    reader.ReadName();
                    this.m_filter = reader.ReadString();
                    break;
                case "FilterData":
                    flag = true;
                    reader.ReadName();
                    this.m_filterData = reader.ReadString();
                    break;
                case "FilterData1":
                    flag = true;
                    reader.ReadName();
                    this.m_filterData1 = reader.ReadString();
                    break;
                case "FilterData10":
                    flag = true;
                    reader.ReadName();
                    this.m_filterData10 = reader.ReadString();
                    break;
                case "FilterData2":
                    flag = true;
                    reader.ReadName();
                    this.m_filterData2 = reader.ReadString();
                    break;
                case "FilterData3":
                    flag = true;
                    reader.ReadName();
                    this.m_filterData3 = reader.ReadString();
                    break;
                case "FilterData4":
                    flag = true;
                    reader.ReadName();
                    this.m_filterData4 = reader.ReadString();
                    break;
                case "FilterData5":
                    flag = true;
                    reader.ReadName();
                    this.m_filterData5 = reader.ReadString();
                    break;
                case "FilterData6":
                    flag = true;
                    reader.ReadName();
                    this.m_filterData6 = reader.ReadString();
                    break;
                case "FilterData7":
                    flag = true;
                    reader.ReadName();
                    this.m_filterData7 = reader.ReadString();
                    break;
                case "FilterData8":
                    flag = true;
                    reader.ReadName();
                    this.m_filterData8 = reader.ReadString();
                    break;
                case "FilterData9":
                    flag = true;
                    reader.ReadName();
                    this.m_filterData9 = reader.ReadString();
                    break;
                case "FilterField":
                    flag = true;
                    reader.ReadName();
                    this.m_filterField = reader.ReadString();
                    break;
                case "FilterField1":
                    flag = true;
                    reader.ReadName();
                    this.m_filterField1 = reader.ReadString();
                    break;
                case "FilterField10":
                    flag = true;
                    reader.ReadName();
                    this.m_filterField10 = reader.ReadString();
                    break;
                case "FilterField2":
                    flag = true;
                    reader.ReadName();
                    this.m_filterField2 = reader.ReadString();
                    break;
                case "FilterField3":
                    flag = true;
                    reader.ReadName();
                    this.m_filterField3 = reader.ReadString();
                    break;
                case "FilterField4":
                    flag = true;
                    reader.ReadName();
                    this.m_filterField4 = reader.ReadString();
                    break;
                case "FilterField5":
                    flag = true;
                    reader.ReadName();
                    this.m_filterField5 = reader.ReadString();
                    break;
                case "FilterField6":
                    flag = true;
                    reader.ReadName();
                    this.m_filterField6 = reader.ReadString();
                    break;
                case "FilterField7":
                    flag = true;
                    reader.ReadName();
                    this.m_filterField7 = reader.ReadString();
                    break;
                case "FilterField8":
                    flag = true;
                    reader.ReadName();
                    this.m_filterField8 = reader.ReadString();
                    break;
                case "FilterField9":
                    flag = true;
                    reader.ReadName();
                    this.m_filterField9 = reader.ReadString();
                    break;
                case "FilterFields":
                    flag = true;
                    reader.ReadName();
                    this.m_filterFields = reader.ReadString();
                    break;
                case "FilterFields1":
                    flag = true;
                    reader.ReadName();
                    this.m_filterFields1 = reader.ReadString();
                    break;
                case "FilterFields10":
                    flag = true;
                    reader.ReadName();
                    this.m_filterFields10 = reader.ReadString();
                    break;
                case "FilterFields2":
                    flag = true;
                    reader.ReadName();
                    this.m_filterFields2 = reader.ReadString();
                    break;
                case "FilterFields3":
                    flag = true;
                    reader.ReadName();
                    this.m_filterFields3 = reader.ReadString();
                    break;
                case "FilterFields4":
                    flag = true;
                    reader.ReadName();
                    this.m_filterFields4 = reader.ReadString();
                    break;
                case "FilterFields5":
                    flag = true;
                    reader.ReadName();
                    this.m_filterFields5 = reader.ReadString();
                    break;
                case "FilterFields6":
                    flag = true;
                    reader.ReadName();
                    this.m_filterFields6 = reader.ReadString();
                    break;
                case "FilterFields7":
                    flag = true;
                    reader.ReadName();
                    this.m_filterFields7 = reader.ReadString();
                    break;
                case "FilterFields8":
                    flag = true;
                    reader.ReadName();
                    this.m_filterFields8 = reader.ReadString();
                    break;
                case "FilterFields9":
                    flag = true;
                    reader.ReadName();
                    this.m_filterFields9 = reader.ReadString();
                    break;
                case "FilterLookupId":
                    flag = true;
                    reader.ReadName();
                    this.m_filterLookupId = reader.ReadString();
                    break;
                case "FilterLookupId1":
                    flag = true;
                    reader.ReadName();
                    this.m_filterLookupId1 = reader.ReadString();
                    break;
                case "FilterLookupId10":
                    flag = true;
                    reader.ReadName();
                    this.m_filterLookupId10 = reader.ReadString();
                    break;
                case "FilterLookupId2":
                    flag = true;
                    reader.ReadName();
                    this.m_filterLookupId2 = reader.ReadString();
                    break;
                case "FilterLookupId3":
                    flag = true;
                    reader.ReadName();
                    this.m_filterLookupId3 = reader.ReadString();
                    break;
                case "FilterLookupId4":
                    flag = true;
                    reader.ReadName();
                    this.m_filterLookupId4 = reader.ReadString();
                    break;
                case "FilterLookupId5":
                    flag = true;
                    reader.ReadName();
                    this.m_filterLookupId5 = reader.ReadString();
                    break;
                case "FilterLookupId6":
                    flag = true;
                    reader.ReadName();
                    this.m_filterLookupId6 = reader.ReadString();
                    break;
                case "FilterLookupId7":
                    flag = true;
                    reader.ReadName();
                    this.m_filterLookupId7 = reader.ReadString();
                    break;
                case "FilterLookupId8":
                    flag = true;
                    reader.ReadName();
                    this.m_filterLookupId8 = reader.ReadString();
                    break;
                case "FilterLookupId9":
                    flag = true;
                    reader.ReadName();
                    this.m_filterLookupId9 = reader.ReadString();
                    break;
                case "FilterOp":
                    flag = true;
                    reader.ReadName();
                    this.m_filterOp = reader.ReadString();
                    break;
                case "FilterOp1":
                    flag = true;
                    reader.ReadName();
                    this.m_filterOp1 = reader.ReadString();
                    break;
                case "FilterOp10":
                    flag = true;
                    reader.ReadName();
                    this.m_filterOp10 = reader.ReadString();
                    break;
                case "FilterOp2":
                    flag = true;
                    reader.ReadName();
                    this.m_filterOp2 = reader.ReadString();
                    break;
                case "FilterOp3":
                    flag = true;
                    reader.ReadName();
                    this.m_filterOp3 = reader.ReadString();
                    break;
                case "FilterOp4":
                    flag = true;
                    reader.ReadName();
                    this.m_filterOp4 = reader.ReadString();
                    break;
                case "FilterOp5":
                    flag = true;
                    reader.ReadName();
                    this.m_filterOp5 = reader.ReadString();
                    break;
                case "FilterOp6":
                    flag = true;
                    reader.ReadName();
                    this.m_filterOp6 = reader.ReadString();
                    break;
                case "FilterOp7":
                    flag = true;
                    reader.ReadName();
                    this.m_filterOp7 = reader.ReadString();
                    break;
                case "FilterOp8":
                    flag = true;
                    reader.ReadName();
                    this.m_filterOp8 = reader.ReadString();
                    break;
                case "FilterOp9":
                    flag = true;
                    reader.ReadName();
                    this.m_filterOp9 = reader.ReadString();
                    break;
                case "FilterValue":
                    flag = true;
                    reader.ReadName();
                    this.m_filterValue = reader.ReadString();
                    break;
                case "FilterValue1":
                    flag = true;
                    reader.ReadName();
                    this.m_filterValue1 = reader.ReadString();
                    break;
                case "FilterValue10":
                    flag = true;
                    reader.ReadName();
                    this.m_filterValue10 = reader.ReadString();
                    break;
                case "FilterValue2":
                    flag = true;
                    reader.ReadName();
                    this.m_filterValue2 = reader.ReadString();
                    break;
                case "FilterValue3":
                    flag = true;
                    reader.ReadName();
                    this.m_filterValue3 = reader.ReadString();
                    break;
                case "FilterValue4":
                    flag = true;
                    reader.ReadName();
                    this.m_filterValue4 = reader.ReadString();
                    break;
                case "FilterValue5":
                    flag = true;
                    reader.ReadName();
                    this.m_filterValue5 = reader.ReadString();
                    break;
                case "FilterValue6":
                    flag = true;
                    reader.ReadName();
                    this.m_filterValue6 = reader.ReadString();
                    break;
                case "FilterValue7":
                    flag = true;
                    reader.ReadName();
                    this.m_filterValue7 = reader.ReadString();
                    break;
                case "FilterValue8":
                    flag = true;
                    reader.ReadName();
                    this.m_filterValue8 = reader.ReadString();
                    break;
                case "FilterValue9":
                    flag = true;
                    reader.ReadName();
                    this.m_filterValue9 = reader.ReadString();
                    break;
                case "FilterValues":
                    flag = true;
                    reader.ReadName();
                    this.m_filterValues = reader.ReadString();
                    break;
                case "FilterValues1":
                    flag = true;
                    reader.ReadName();
                    this.m_filterValues1 = reader.ReadString();
                    break;
                case "FilterValues10":
                    flag = true;
                    reader.ReadName();
                    this.m_filterValues10 = reader.ReadString();
                    break;
                case "FilterValues2":
                    flag = true;
                    reader.ReadName();
                    this.m_filterValues2 = reader.ReadString();
                    break;
                case "FilterValues3":
                    flag = true;
                    reader.ReadName();
                    this.m_filterValues3 = reader.ReadString();
                    break;
                case "FilterValues4":
                    flag = true;
                    reader.ReadName();
                    this.m_filterValues4 = reader.ReadString();
                    break;
                case "FilterValues5":
                    flag = true;
                    reader.ReadName();
                    this.m_filterValues5 = reader.ReadString();
                    break;
                case "FilterValues6":
                    flag = true;
                    reader.ReadName();
                    this.m_filterValues6 = reader.ReadString();
                    break;
                case "FilterValues7":
                    flag = true;
                    reader.ReadName();
                    this.m_filterValues7 = reader.ReadString();
                    break;
                case "FilterValues8":
                    flag = true;
                    reader.ReadName();
                    this.m_filterValues8 = reader.ReadString();
                    break;
                case "FilterValues9":
                    flag = true;
                    reader.ReadName();
                    this.m_filterValues9 = reader.ReadString();
                    break;
                case "GroupString":
                    flag = true;
                    reader.ReadName();
                    this.m_groupString = reader.ReadString();
                    break;
                case "HasOverrideSelectCommand":
                    flag = true;
                    reader.ReadName();
                    this.m_hasOverrideSelectCommand = reader.ReadString();
                    break;
                case "ID":
                    flag = true;
                    reader.ReadName();
                    this.m_iD = reader.ReadString();
                    break;
                case "InplaceFullListSearch":
                    flag = true;
                    reader.ReadName();
                    this.m_inplaceFullListSearch = reader.ReadString();
                    break;
                case "InplaceSearchQuery":
                    flag = true;
                    reader.ReadName();
                    this.m_inplaceSearchQuery = reader.ReadString();
                    break;
                case "IsCSR":
                    flag = true;
                    reader.ReadName();
                    this.m_isCSR = reader.ReadString();
                    break;
                case "IsGroupRender":
                    flag = true;
                    reader.ReadName();
                    this.m_isGroupRender = reader.ReadString();
                    break;
                case "IsXslView":
                    flag = true;
                    reader.ReadName();
                    this.m_isXslView = reader.ReadString();
                    break;
                case "ListViewPageUrl":
                    flag = true;
                    reader.ReadName();
                    this.m_listViewPageUrl = reader.ReadString();
                    break;
                case "OverrideScope":
                    flag = true;
                    reader.ReadName();
                    this.m_overrideScope = reader.ReadString();
                    break;
                case "OverrideSelectCommand":
                    flag = true;
                    reader.ReadName();
                    this.m_overrideSelectCommand = reader.ReadString();
                    break;
                case "PageFirstRow":
                    flag = true;
                    reader.ReadName();
                    this.m_pageFirstRow = reader.ReadString();
                    break;
                case "PageLastRow":
                    flag = true;
                    reader.ReadName();
                    this.m_pageLastRow = reader.ReadString();
                    break;
                case "RootFolder":
                    flag = true;
                    reader.ReadName();
                    this.m_rootFolder = reader.ReadString();
                    break;
                case "SortDir":
                    flag = true;
                    reader.ReadName();
                    this.m_sortDir = reader.ReadString();
                    break;
                case "SortDir1":
                    flag = true;
                    reader.ReadName();
                    this.m_sortDir1 = reader.ReadString();
                    break;
                case "SortDir10":
                    flag = true;
                    reader.ReadName();
                    this.m_sortDir10 = reader.ReadString();
                    break;
                case "SortDir2":
                    flag = true;
                    reader.ReadName();
                    this.m_sortDir2 = reader.ReadString();
                    break;
                case "SortDir3":
                    flag = true;
                    reader.ReadName();
                    this.m_sortDir3 = reader.ReadString();
                    break;
                case "SortDir4":
                    flag = true;
                    reader.ReadName();
                    this.m_sortDir4 = reader.ReadString();
                    break;
                case "SortDir5":
                    flag = true;
                    reader.ReadName();
                    this.m_sortDir5 = reader.ReadString();
                    break;
                case "SortDir6":
                    flag = true;
                    reader.ReadName();
                    this.m_sortDir6 = reader.ReadString();
                    break;
                case "SortDir7":
                    flag = true;
                    reader.ReadName();
                    this.m_sortDir7 = reader.ReadString();
                    break;
                case "SortDir8":
                    flag = true;
                    reader.ReadName();
                    this.m_sortDir8 = reader.ReadString();
                    break;
                case "SortDir9":
                    flag = true;
                    reader.ReadName();
                    this.m_sortDir9 = reader.ReadString();
                    break;
                case "SortField":
                    flag = true;
                    reader.ReadName();
                    this.m_sortField = reader.ReadString();
                    break;
                case "SortField1":
                    flag = true;
                    reader.ReadName();
                    this.m_sortField1 = reader.ReadString();
                    break;
                case "SortField10":
                    flag = true;
                    reader.ReadName();
                    this.m_sortField10 = reader.ReadString();
                    break;
                case "SortField2":
                    flag = true;
                    reader.ReadName();
                    this.m_sortField2 = reader.ReadString();
                    break;
                case "SortField3":
                    flag = true;
                    reader.ReadName();
                    this.m_sortField3 = reader.ReadString();
                    break;
                case "SortField4":
                    flag = true;
                    reader.ReadName();
                    this.m_sortField4 = reader.ReadString();
                    break;
                case "SortField5":
                    flag = true;
                    reader.ReadName();
                    this.m_sortField5 = reader.ReadString();
                    break;
                case "SortField6":
                    flag = true;
                    reader.ReadName();
                    this.m_sortField6 = reader.ReadString();
                    break;
                case "SortField7":
                    flag = true;
                    reader.ReadName();
                    this.m_sortField7 = reader.ReadString();
                    break;
                case "SortField8":
                    flag = true;
                    reader.ReadName();
                    this.m_sortField8 = reader.ReadString();
                    break;
                case "SortField9":
                    flag = true;
                    reader.ReadName();
                    this.m_sortField9 = reader.ReadString();
                    break;
                case "SortFields":
                    flag = true;
                    reader.ReadName();
                    this.m_sortFields = reader.ReadString();
                    break;
                case "SortFieldValues":
                    flag = true;
                    reader.ReadName();
                    this.m_sortFieldValues = reader.ReadString();
                    break;
                case "View":
                    flag = true;
                    reader.ReadName();
                    this.m_view = reader.ReadString();
                    break;
                case "ViewCount":
                    flag = true;
                    reader.ReadName();
                    this.m_viewCount = reader.ReadString();
                    break;
                case "ViewId":
                    flag = true;
                    reader.ReadName();
                    this.m_viewId = reader.ReadString();
                    break;
                case "WebPartId":
                    flag = true;
                    reader.ReadName();
                    this.m_webPartId = reader.ReadString();
                    break;
            }
            return flag;
        }
    }
}
