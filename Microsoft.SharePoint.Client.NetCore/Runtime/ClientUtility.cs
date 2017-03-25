using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    public static class ClientUtility
    {
        private const string REGKEY_CSOM = "SOFTWARE\\Microsoft\\Shared Tools\\Web Server Extensions\\16.0\\Csom";

        private const string REGVAL_CSOMDIR = "CsomDir";

        private static string s_setupDirectory;

        internal static string GetSetupDirectory()
        {
            string text = ClientUtility.s_setupDirectory;
            if (text == null)
            {
                //Edited for .NET Core
                //RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Shared Tools\\Web Server Extensions\\16.0\\Csom");
                //if (registryKey != null)
                //{
                //    text = (string)registryKey.GetValue("CsomDir");
                //    registryKey.Close();
                //}
                if (text == null)
                {
                    text = string.Empty;
                }
                ClientUtility.s_setupDirectory = text;
            }
            return text;
        }

        public static Exception CreateArgumentException(string argumentName)
        {
            return new ArgumentException(Resources.GetString("ArgumentExceptionMessage", new object[]
            {
                argumentName
            }));
        }

        public static Exception CreateArgumentNullException(string argumentName)
        {
            return new ArgumentNullException(argumentName, Resources.GetString("ArgumentNullExceptionMessage", new object[]
            {
                argumentName
            }));
        }
    }
}
