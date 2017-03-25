using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCoreMime
{
    internal static class MtomGlobals
    {
        internal static string XopIncludeLocalName = "Include";

        internal static string XopIncludeNamespace = "http://www.w3.org/2004/08/xop/include";

        internal static string XopIncludePrefix = "xop";

        internal static string XopIncludeHrefLocalName = "href";

        internal static string XopIncludeHrefNamespace = string.Empty;

        internal static string MediaType = "multipart";

        internal static string MediaSubtype = "related";

        internal static string BoundaryParam = "boundary";

        internal static string TypeParam = "type";

        internal static string XopMediaType = "application";

        internal static string XopMediaSubtype = "xop+xml";

        internal static string XopType = "application/xop+xml";

        internal static string StartParam = "start";

        internal static string StartInfoParam = "start-info";

        internal static string ActionParam = "action";

        internal static string CharsetParam = "charset";

        internal static string MimeContentTypeLocalName = "contentType";

        internal static string MimeContentTypeNamespace200406 = "http://www.w3.org/2004/06/xmlmime";

        internal static string MimeContentTypeNamespace200505 = "http://www.w3.org/2005/05/xmlmime";

        internal static string DefaultContentTypeForBinary = "application/octet-stream";
    }
}
