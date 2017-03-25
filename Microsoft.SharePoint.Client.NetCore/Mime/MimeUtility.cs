using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCoreMime
{
    internal static class MimeUtility
    {
        public static string GetBoundary(string contentType)
        {
            string text = null;
            if (!string.IsNullOrEmpty(contentType) && contentType.StartsWith("multipart/related", StringComparison.OrdinalIgnoreCase))
            {
                int num = contentType.IndexOf("boundary=", StringComparison.OrdinalIgnoreCase);
                if (num > 0)
                {
                    num += "boundary=".Length;
                    int num2 = contentType.IndexOf(';', num);
                    if (num2 > 0)
                    {
                        text = contentType.Substring(num, num2 - num);
                        text = text.Trim(new char[]
                        {
                            '"',
                            ' '
                        });
                    }
                }
            }
            return text;
        }

        public static string CreateBoundary()
        {
            return Guid.NewGuid().ToString("D").ToUpperInvariant() + "+id=1";
        }
    }
}
