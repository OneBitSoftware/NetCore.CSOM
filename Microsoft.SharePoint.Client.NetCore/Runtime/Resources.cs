using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    public static class Resources
    {
        //Edited for .NET Core
        //private const string ResourceFileId = "Microsoft.SharePoint.Client.Runtime";

        private static SPResourceManager s_resourceManager =
        //Edited for .NET Core
            //new SPResourceManager("Microsoft.SharePoint.Client.Runtime", Assembly.GetExecutingAssembly());
            new SPResourceManager("Microsoft.SharePoint.Client.Runtime", Assembly.GetEntryAssembly());//GetExecutingAssembly());

        public static string GetString(string resourceId)
        {
            //Edited for .NET Core
            //return Resources.s_resourceManager.GetString(resourceId);
            return Resources.s_resourceManager.GetString(resourceId, CultureInfo.InvariantCulture);
        }

        public static string GetString(string resourceId, params object[] args)
        {
        //Edited for .NET Core
            //string @string = Resources.s_resourceManager.GetString(resourceId);
            string @string = Resources.s_resourceManager.GetString(resourceId, CultureInfo.InvariantCulture);
            return string.Format(@string, args);
        }
    }
}
